using GitInfo.Domain.Repositories.Interfaces;
using GitInfo.Domain.Services.Interfaces;

namespace GitInfo.Domain.Services
{
    public class PageService : IPageService
    {
        private readonly IGithubRepository githubRepository;

        public PageService(IGithubRepository githubRepository)
        {
            this.githubRepository = githubRepository;
        }

        public string GetHtmlRaw(string route)
        {
            var page = this.githubRepository.GetPage(route);
            return page;
        }
    }
}