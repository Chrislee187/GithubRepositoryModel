using System.Threading.Tasks;
using GithubRepositoryModel.Tests.GithubRepoModel;
using NUnit.Framework;
using Shouldly;

namespace GithubRepositoryModel.Tests
{
    public class GhBranchTests : GithubTestsBase
    {
        private IGhRepository _repo;
        private IGhBranch _branch;

        [OneTimeSetUp]
        public async Task OneTimeSetUp()
        {
            _repo = await Github.Repository(UserName, RepoName);
            _branch = await _repo.GetBranch(_repo.DefaultBranch);
        }

        [Test]
        public void Can_get_default_branch()
        {
            _branch.Name.ShouldBe(_repo.DefaultBranch);
        }

        [Test]
        public void Can_get_branch_root()
        {
            _branch.Root.ShouldNotBeNull();
        }
    }
}
