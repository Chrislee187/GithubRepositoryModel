using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GithubRepositoryModel.Tests.GithubRepoModel;
using NUnit.Framework;
using Shouldly;

namespace GithubRepositoryModel.Tests
{
    public class GhFileTests : GithubTestsBase
    {
        private GhFile _file;
        private IEnumerable<GhFile> _files;

        [OneTimeSetUp]
        public async Task OneTimeSetUp()
        {
            var repo = await Github.Repository(UserName, RepoName);
            var branch = await repo.GetBranch(repo.DefaultBranch);
            var folder = branch.Root;
            _files = await folder.GetFiles();
        }

        [Test]
        public void Can_get_file_content()
        {
            _files.Count().ShouldBeGreaterThan(1);
            Console.WriteLine(_files.First().Content.Length);
            Console.WriteLine(_files.Last().Content.Length);
            _files.First().Content.ShouldNotBe(_files.Last().Content);
        }
    }
}
