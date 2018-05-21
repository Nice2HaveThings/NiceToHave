using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiceToHave.Utils;

namespace NiceToHave.Test.Utils
{
    [TestClass]
    public class RequireTests
    {
        [TestMethod]
        public void NotNullShouldNotThrowIfNotNull()
        {
            object[] validInputs =
            {
                string.Empty,
                new object(),
                typeof(RequireTests),
                int.MinValue,
                0
            };

            foreach(object input in validInputs)
            {
                Require.NotNull(input);
            }
        }

        [TestMethod]
        public void NotNullShouldThrowIfNull()
        {
            Assert.ThrowsException<ArgumentException>(() => Require.NotNull(null));
        }

        [TestMethod]
        public void NotEmptyShouldNotThrowOnValidInput()
        {
            string[] validInputs =
            {
                "abc"
            };

            foreach(string input in validInputs)
            {
                Require.NotEmpty(input);
            }
        }

        [TestMethod]
        public void NotEmptyShouldThrowOnInvalidInput()
        {
            string[] invalidInputs =
            {
                string.Empty,
                " ",
                null
            };

            foreach(string input in invalidInputs)
            {
                Assert.ThrowsException<ArgumentException>(() => Require.NotEmpty(input));
            }
        }
    }
}
