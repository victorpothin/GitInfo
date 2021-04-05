namespace GitInfo.Domain.Repositories.Interfaces
{
    public interface IGithubRepository
    {
        string GetPage(string route);
    }
}