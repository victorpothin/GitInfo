using System.Net.Http;
using GitInfo.Domain.Repositories.Interfaces;

namespace GitInfo.Data.Repositories
{
    public class GithubRepository : IGithubRepository
    {
        private readonly HttpClient client;
        public GithubRepository(IHttpClientFactory httpClientFactory)
        {
            this.client = httpClientFactory.CreateClient("Github.API");
        }

        public string GetPage(string route)
        {
            HttpResponseMessage responseMessage = client.GetAsync(client.BaseAddress + route).Result;
            return responseMessage.Content.ReadAsStringAsync().Result;
        }
    }
}