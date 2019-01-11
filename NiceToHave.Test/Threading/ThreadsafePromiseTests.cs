using FluentAssertions;
using NUnit.Framework;
using NiceToHave.Threading;

namespace NiceToHave.Test.Threading
{
    [TestFixture]
    public class ThreadsafePromiseTests
    {
        [Test]
        public void ShouldWork()
        {
            int test = 0;
            ThreadsafePromise<int> promise = new ThreadsafePromise<int>();

            promise.Done(i => test = test + i, ex => Assert.Fail());
            test.Should().Be(0);
            promise.Done(i => test = test + i, ex => Assert.Fail());
            test.Should().Be(0);

            promise.Resolve(1);

            test.Should().Be(2);

            promise.Done(i => test = test + i, ex => Assert.Fail());
            test.Should().Be(3);
        }
    }
}
