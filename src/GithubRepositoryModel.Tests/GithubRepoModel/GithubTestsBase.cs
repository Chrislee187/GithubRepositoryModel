using Octokit;


namespace GithubRepositoryModel.Tests.GithubRepoModel
{
    public class GithubTestsBase
    {
        protected readonly GitHubClient ApiClient;
        protected IGithub Github;

        protected const string UserName = "ChrisLee187";
        protected const string RepoName = "GithubRepositoryModel";
        protected const string DefaultBranchName = "main";

        protected GithubTestsBase()
        {
            ApiClient = new GitHubClient(new ProductHeaderValue("EmmaTests"))
            {
                Connection = { Credentials = new Octokit.Credentials(Credentials.AppKey()) }
            };

            Github = new Github(ApiClient);
        }
    }
}