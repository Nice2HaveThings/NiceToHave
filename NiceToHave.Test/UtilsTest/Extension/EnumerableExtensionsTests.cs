using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiceToHave.Utils.Extension;

namespace NiceToHave.Test.UtilsTest.Extension
{
    [TestClass]
    public class EnumerableExtensionsTests
    {
        [TestMethod]
        public void SecondShouldWork()
        {
            Dictionary<string, int> values = new Dictionary<string, int>
            {
                { "element1", 1 },
                { "element2", 1 },
                { "element3", 1 },
            };

            Assert.AreEqual(values.Second(v => v.Value == 1).Key, "element2");
        }

        [TestMethod]
        public void SecondOrDefaultShouldWork()
        {
            Dictionary<string, int> values = new Dictionary<string, int>
            {
                { "element1", 1 },
                { "element2", 1 },
                { "element3", 1 },
            };

            Assert.AreEqual(values.SecondOrDefault(v => v.Value == 2).Key, null);
        }
    }
}
