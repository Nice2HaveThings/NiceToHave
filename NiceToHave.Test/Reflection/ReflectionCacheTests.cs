using FluentAssertions;
using NiceToHave.Reflection;
using NUnit.Framework;
using System.Linq;

namespace NiceToHave.Test.Reflection
{
    [TestFixture]
    public class ReflectionCacheTests
    {
        [Test]
        public void LoadTypeShouldWork()
        {
            ReflectionCache<ReflectionTest> cache = new ReflectionCache<ReflectionTest>();

            cache.Properties.Should().HaveCount(2);
            cache.Properties.Select(p => p.Name).Should().BeEquivalentTo(new[] { "PublicProperty", "PrivateProperty" });
            cache.Fields.Should().HaveCount(2);
            cache.Fields.Select(p => p.Name).Should().BeEquivalentTo(new[] { "PublicField", "PrivateField" });
        }
    
        private class ReflectionTest
        {
            public string PublicProperty { get; }

            private string PrivateProperty { get; }

            public string PublicField;

            public string PrivateField;
        }
    }
}
