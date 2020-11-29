using Emma.Core.Cache;
using Emma.Core.Github;
using Emma.Core.MethodSources;
using Emma.Core.Tests.Github;
using Emma.Core.Tests.Support;
using NUnit.Framework;

namespace Emma.Core.Tests
{
    public class Spikes : GithubTestsBase
    {
        [SetUp]
        public void Setup()
        {

        }


        [Test]
        public void Spike()
        {
            var emSource = new GithubRepoExtensionMethodsSource(GithubClient, 
                new GithubLocation("chrislee187", "UsefulStuff", "UsefullStuff"), 
                new AppDataExtensionMethodJsonCache(),
                "github.emma.spike" );

            foreach (var m in emSource.Methods)
            {
                ConsoleX.Dump(m);
            }
        }
    }
}