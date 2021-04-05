using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using GitInfo.Domain.Models;
using GitInfo.Domain.Repositories.Interfaces;
using GitInfo.Domain.Services.Interfaces;

namespace GitInfo.Domain.Services
{
    public class TreeNodeService : ITreeNodeService
    {
        private readonly IGithubRepository githubRepository;

        public TreeNodeService(IGithubRepository githubRepository)
        {
            this.githubRepository = githubRepository;
        }

        public TreeNode MakeTreeNodes(string page)
        {
            List<string> nodes = new List<string>();
            MakeNodes(page, ref nodes);
            return new TreeNode(nodes);
        }

        public void MakeNodes(string page, ref List<string> nodes)
        {
            string nodesPattern = @"(?<=(data-pjax=""#repo-content-pjax-container"" href=""\/))(\w|\d|\n|[().,\-:;@#$%^&*\[\]""'+–/\/®°⁰!?{}|`~]| )+?(?=(""))";
            nodes.AddRange(Regex.Matches(page, nodesPattern).Cast<Match>().Select(p => p.Value).ToList().Where(node => node.Contains("/blob/")));
            List<string> treeNodes = new List<string>();
            treeNodes.AddRange(Regex.Matches(page, nodesPattern).Cast<Match>().Select(p => p.Value).ToList().Where(node => node.Contains("/tree/")));
            foreach (string tree in treeNodes)
            {
                string newPage = this.githubRepository.GetPage(tree);
                MakeNodes(newPage, ref nodes);
            }
        }

    }
}