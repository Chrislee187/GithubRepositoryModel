using System;
using System.Threading.Tasks;

namespace GithubRepositoryModel.InMemoryCache
{
    public static class ApiHelper
    {
        private static readonly ApiResultCache ApiResultCache = new ApiResultCache();

        public static async Task<TMapperResult> CachedApiCall<TMapperResult, TApiResult>(CacheKey key,
            Func<Task<TApiResult>> apiCall,
            Func<TApiResult, TMapperResult> mapper,
            string logMessage)
        {
            if (ApiResultCache.TryGetValue<TMapperResult>(key, out var r))
                return r;

            var (apiResult, _) = await GhLogging.LogAsyncTask(apiCall, logMessage);

            var model = mapper(apiResult);

            ApiResultCache.Add(key, model);
            return model;
        }
    }
}