using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GithubRepositoryModel.InMemoryCache;
using Octokit;
namespace GithubRepositoryModel
{
    public class GhBranch : Branch, IGhBranch
    {
        public readonly IGhRepository Repository;

        public GhFolder Root { get; }

        
        private GhBranch(IGithub github, IGhRepository repository, Branch branch) 
            : base(branch.Name, branch.Commit, branch.Protected)
        {
            Repository = repository;
            Root = new GhFolder(github, Repository, this);
        }

        #region Api Helpers
        public static async Task<IGhBranch> Get(IGithub github, GhRepository repository, string branchName) => 
            await ApiHelper.CachedApiCall<IGhBranch, Branch>(
                new CacheKey(repository.Owner.Login, repository.Name, branchName, typeof(IGhBranch)),
            () => github.ApiClient.Repository.Branch.Get(repository.Id, branchName), 
            (b) => new GhBranch(github, repository,b), $"{nameof(Github)}.{nameof(GhBranch)}.{nameof(Get)}");

        public static async Task<IEnumerable<IGhBranch>> All(IGithub github, GhRepository repository) => 
            await ApiHelper.CachedApiCall<IEnumerable<IGhBranch>, IReadOnlyList<Branch>>(
                new CacheKey(repository.Owner.Login, repository.Name, typeof(IEnumerable<IGhBranch>)),
            () => github.ApiClient.Repository.Branch.GetAll(repository.Id),
            (branches) => branches.Select(b => new GhBranch(github, repository, b)), $"{nameof(Github)}.{nameof(GhBranch)}.{nameof(All)}");

        #endregion

    }
}