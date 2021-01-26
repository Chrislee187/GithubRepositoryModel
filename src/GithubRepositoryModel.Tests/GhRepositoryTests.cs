using System;
using System.Linq;
using System.Threading.Tasks;
using GithubRepositoryModel.Tests.GithubRepoModel;
using NUnit.Framework;
using Shouldly;

namespace GithubRepositoryModel.Tests
{
    public class GhRepositoryTests : GithubTestsBase
    {
        private IGhRepository _repo;

        [OneTimeSetUp]
        public async Task OneTimeSetUp()
        {
            _repo = await Github.Repository(UserName, RepoName);
        }

        [TestCase(RepoName)]
        public void Can_get_Repository(string repoName)
        {
            _repo.Name.ShouldBe(RepoName);
            _repo.PushedAt.HasValue.ShouldBeTrue();
            _repo.PushedAt.Value.ShouldBeGreaterThan(DateTimeOffset.MinValue);
        }
        [Test]
        public async Task Can_get_default_branch()
        {
            var branch = await _repo.GetBranch(_repo.DefaultBranch);

            branch.Name.ShouldBe(DefaultBranchName);
        }        
        
        [Test]
        public async Task Spike()
        {
            var repositoryCommitsClient = Github.ApiClient.Repository.Commit;
            var gitHubCommits = await repositoryCommitsClient.GetAll(UserName, RepoName);
            var firstCommit = gitHubCommits.First();
            var lastCommit = gitHubCommits.Last();
            
            var files = lastCommit.Files;
        }

    }
}
