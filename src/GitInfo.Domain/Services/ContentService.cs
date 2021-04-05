using System.Collections.Generic;
using GitInfo.Domain.Models;
using GitInfo.Domain.Services.Interfaces;
using System.Linq;

namespace GitInfo.Domain.Services
{
    public class ContentService : IContentService
    {
        private readonly IPageService pageService;

        public ContentService(IPageService pageService)
        {
            this.pageService = pageService;
        }
        public IEnumerable<Content> MakeContents(IEnumerable<string> routes)
        {
            List<Content> contents = new List<Content>();
            routes.ToList().ForEach(route => { });

            foreach (string route in routes)
            {
                contents.Add(Initialize(route));
            }
            return GroupByExtension(contents);
        }

        private Content Initialize(string route)
        {
            string page = this.pageService.GetHtmlRaw(route);
            return new Content(page);
        }

        private IEnumerable<Content> GroupByExtension(IEnumerable<Content> contents)
        {
            return from content in contents
                   group content by new { content.Extension } into g
                   select new Content(g.Key.Extension, g.Count(), g.Sum(content => content.Lines), g.Sum(content => content.Bytes));
        }
    }
}