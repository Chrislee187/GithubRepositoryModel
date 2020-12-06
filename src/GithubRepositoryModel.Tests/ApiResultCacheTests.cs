using System;
using NUnit.Framework;
using Shouldly;

namespace GithubRepositoryModel.Tests
{
    public class ApiResultCacheTests 
    {
        private ApiResultCache _cache;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _cache = new ApiResultCache();
        }

        [Test]
        public void Can_store_different_objects_for_same_repo()
        {
            var obj1 = new TestCacheObjectType1();
            var obj2 = new TestCacheObjectType2();

            var key1 = new CacheKey("user", "repo", typeof(TestCacheObjectType1));
            var key2 = new CacheKey("user", "repo", typeof(TestCacheObjectType2));
            _cache.Add(key1, obj1);


            _cache.TryGetValue<TestCacheObjectType1>(key1, out _)
                .ShouldBeTrue();
            _cache.TryGetValue<TestCacheObjectType2>(key2, out _ )
                .ShouldBeFalse();
            
            _cache.Add(key2, obj2);
            _cache.TryGetValue<TestCacheObjectType2>(key2, out _).ShouldBeTrue();

            _cache.Get<TestCacheObjectType1>(key1)
                .Id.ShouldBe(obj1.Id);
            _cache.Get<TestCacheObjectType2>(key2)
                .Id.ShouldBe(obj2.Id);

            _cache.Clear(key2);
            _cache.TryGetValue<TestCacheObjectType2>(key2, out _).ShouldBeFalse();

        }
    }

    public class TestCacheObjectType1
    {
        public TestCacheObjectType1()
        {
        }

        public Guid Id { get; } = Guid.NewGuid();
    }
    public class TestCacheObjectType2
    {
        public TestCacheObjectType2()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; } = Guid.NewGuid();
    }
}
