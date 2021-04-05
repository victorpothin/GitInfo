using GitInfo.Domain.Services.Interfaces;
using System.Collections.Generic;
using GitInfo.Domain.Models;

namespace GitInfo.Domain.Services
{
    public class FileInfoService : IFileInfoService
    {
        private readonly ITreeNodeService treeNodeService;
        private readonly IPageService pageService;
        private readonly IContentService contentService;

        public FileInfoService(ITreeNodeService treeNodeService, IPageService pageService, IContentService contentService)
        {
            this.treeNodeService = treeNodeService;
            this.pageService = pageService;
            this.contentService = contentService;
        }

        public IEnumerable<Content> GetInfo(string route)
        {
            string page = this.pageService.GetHtmlRaw(route);
            TreeNode tree = this.treeNodeService.MakeTreeNodes(page);
            return this.contentService.MakeContents(tree.Nodes);
        }

    }
}