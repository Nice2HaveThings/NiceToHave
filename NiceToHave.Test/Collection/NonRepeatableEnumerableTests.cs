using FluentAssertions;
using NiceToHave.Collection;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace NiceToHave.Test.Collection
{
    [TestFixture]
    public class NonRepeatableEnumerableTests
    {
        [Test]
        public void ShouldEnumerateOnlyOnce()
        {
            NonRepeatableEnumerable<int> col = new NonRepeatableEnumerable<int>(Enumerable.Range(1, 5));

            List<int> list = col.ToList();

            list.Should().BeEquivalentTo(new[] { 1, 2, 3, 4, 5 });
            col.ToList().Should().BeEmpty();
        }

        [Test]
        public void ShouldEnumeratePartial()
        {
            NonRepeatableEnumerable<int> col = new NonRepeatableEnumerable<int>(Enumerable.Range(1, 5));

            List<int> list = col.Take(3).ToList();

            list.Should().BeEquivalentTo(new[] { 1, 2, 3 });
            col.ToList().Should().BeEquivalentTo(new[] { 4, 5 });
        }
    }
}
