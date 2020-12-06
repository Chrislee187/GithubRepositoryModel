using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace GithubRepositoryModel
{
    public class ApiResultCache
    {
        private readonly IDictionary<CacheKey, object> _cache
            = new ConcurrentDictionary<CacheKey, object>();

        public bool TryGetValue<T>(CacheKey cacheKey, out T result)
        {
            var tryGetValue = _cache.TryGetValue(cacheKey,out var result2);
            result = (T) result2;
            return tryGetValue;
        }

        public T Get<T>(CacheKey cacheKey) => 
            (T) _cache[cacheKey];

        public void Add<T>(CacheKey cacheKey, T repo) => 
            _cache?.Add(cacheKey, repo);

        public void Clear(CacheKey cacheKey) => 
            _cache.Remove(cacheKey);
    }

    public class CacheKey
    {
        public readonly string UserName;
        public readonly string RepoName;
        public readonly string BranchName;
        public readonly string Path;

        public readonly Type Type;

        public string Key()
        {
            var sb = new StringBuilder();

            if (!string.IsNullOrEmpty(UserName))
            {
                sb.Append($"{UserName}.");
            }

            if (!string.IsNullOrEmpty(RepoName))
            {
                sb.Append($"{UserName}.");
            }

            return sb.ToString(0, sb.Length - 1);
        }
        public CacheKey(string userName, Type cachedObjectType) : this(userName, "", cachedObjectType)
        {
        }
        public CacheKey(string userName, string repoName, Type cachedObjectType) : this(userName, repoName,"", cachedObjectType)
        {
        }
        public CacheKey(string userName, string repoName, string branchName, Type cachedObjectType) 
            : this(userName, repoName, branchName, "", cachedObjectType)
        {
        }
        public CacheKey(string userName, string repoName, string branchName, string path, Type cachedObjectType)
        {
            RepoName = repoName;
            UserName = userName;
            BranchName = branchName;
            Path = path;
            Type = cachedObjectType;
        }
        protected bool Equals(CacheKey other)
        {
            return UserName == other.UserName 
                   && RepoName == other.RepoName 
                   && BranchName == other.BranchName
                   && Path == other.Path
                   && Type == other.Type;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CacheKey) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(UserName, RepoName, Type);
        }

        public override string ToString()
        {
            return $"{UserName}.{RepoName}.{BranchName}.{Path}.{nameof(Type)}";
        }
    }
}