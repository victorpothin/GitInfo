using System;
using System.Text.RegularExpressions;
namespace GitInfo.Domain.Models
{
    public class Content
    {
        public string Extension { get; set; }
        public int Count { get; set; }
        public int Lines { get; set; }
        public long Bytes { get; set; }
        public Content(string page)
        {
            this.Extension = GetExtension(page);
            this.Lines = GetLines(page);
            this.Bytes = GetBytes(page);
        }
        public Content(string extension, int count, int lines, long bytes)
        {
            this.Extension = extension;
            this.Count = count;
            this.Lines = lines;
            this.Bytes = bytes;
        }

        private string GetExtension(string page)
        {
            string patternFile = @"(?<=(clipboard-copy value=""))(\w|\d|\n|[().,\-:;@#$%^&*\[\]""'+–/\/®°⁰!?{}|`~]| )+?(?=(""))";
            string filename = Regex.Match(page, patternFile).Value;
            string patternExtension = @"[^.]+$";
            return Regex.Match(filename, patternExtension).Value;
        }

        private int GetLines(string page)
        {
            try
            {
                string getLinesNoFormattedPattern = @"(\d+).(lines \()";
                string removeStringPattern = @"(\d+)";
                string linesNoformatted = Regex.Match(page, getLinesNoFormattedPattern).Value;
                int lines = Convert.ToInt32(Regex.Match(linesNoformatted, removeStringPattern).Value);
                return lines;
            }
            catch
            {
                return 0;
            }
        }

        private long GetBytes(string page)
        {
            try
            {
                string getBytesPattern = @"(?<=(class=""file-info-divider""><\/span>))(\w|\d|\n|[().,\-:;@#$%^&*\[\]""'+–/\/®°⁰!?{}|`~]| )+?(?=(<\/div>))";
                string multiplierPattern = @"[a-zA-Z]+";
                string bytesNoformatted = Regex.Match(page, getBytesPattern).Value;
                double bytes = Convert.ToDouble(Regex.Replace(bytesNoformatted, multiplierPattern, ""));
                string multiplier = Regex.Match(bytesNoformatted, multiplierPattern).Value;
                return ConvertToBytes(bytes, multiplier);
            }
            catch
            {

                return 0;
            }
        }

        private long ConvertToBytes(double value, string unit)
        {
            double cache;
            switch (unit)
            {
                case "Bytes":
                    cache = (value * (double)Math.Pow(1024, 0));
                    break;
                case "KB":
                    cache = (value * (double)Math.Pow(1024, 1));
                    break;
                case "MB":
                    cache = (value * (double)Math.Pow(1024, 2));
                    break;
                case "GB":
                    cache = (value * (double)Math.Pow(1024, 3));
                    break;
                case "TB":
                    cache = (value * (double)Math.Pow(1024, 4));
                    break;
                case "PB":
                    cache = (value * (double)Math.Pow(1024, 5));
                    break;
                default: return 0;
            }
            return Convert.ToInt64(cache);
        }
    }

}