using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiceToHave.Utils.Extension;

namespace NiceToHave.Test.UtilsTest.Extension
{
    [TestClass]
    public class TypeExtensionsTests
    {
        [TestMethod]
        public void IsReferenceTypeShouldWork()
        {
            Assert.IsFalse(typeof(TypeExtensionsTests).IsSimple());
            Assert.IsTrue(typeof(string).IsSimple());
            Assert.IsTrue(typeof(int).IsSimple());
        }
    }
}
