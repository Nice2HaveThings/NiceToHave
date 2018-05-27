using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiceToHave.Threading;

namespace NiceToHave.Test.ThreadingTest
{
    [TestClass]
    public class ThreadsafePromiseTests
    {
        [TestMethod]
        public void ShouldWork()
        {
            int test = 0;
            ThreadsafePromise<int> promise = new ThreadsafePromise<int>();

            promise.Done(i => test = test + i, ex => Assert.Fail());
            Assert.AreEqual(test, 0);
            promise.Done(i => test = test + i, ex => Assert.Fail());
            Assert.AreEqual(test, 0);

            promise.Resolve(1);

            Assert.AreEqual(test, 2);

            promise.Done(i => test = test + i, ex => Assert.Fail());
            Assert.AreEqual(test, 3);
        }
    }
}
