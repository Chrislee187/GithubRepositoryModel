using System;
using System.Threading.Tasks;
using GithubRepositoryModel.Tests.GithubRepoModel;
using NUnit.Framework;
using Shouldly;

namespace GithubRepositoryModel.Tests
{
    public class GhUserTests : GithubTestsBase
    {
        private IGithub _github;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _github = new Github(ApiClient);
        }


        [TestCase(UserName)]
        public async Task GetAGithubUser(string loginName)
        {
            var user = await _github.User(loginName);

            user.Login.ToLower().ShouldBe(loginName.ToLower());
        }

        [TestCase(RepoName)]
        public async Task Can_get_a_Repository(string repoName)
        {
            var repo = await _github.Repository(UserName, repoName);

            repo.Name.ShouldBe(RepoName);
            repo.PushedAt.HasValue.ShouldBeTrue();
            repo.PushedAt.Value.ShouldBeGreaterThan(DateTimeOffset.MinValue);
        }

    }
}
