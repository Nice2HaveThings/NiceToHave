using FluentAssertions;
using NUnit.Framework;
using System;
using NiceToHave.Utils;

namespace NiceToHave.Test.Utils
{
    [TestFixture]
    public class RequireTests
    {
        [Test]
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

        [Test]
        public void NotNullShouldThrowIfNull()
        {
            Action fail = () => Require.NotNull(null);

            fail.Should().Throw<ArgumentException>();
        }

        [Test]
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

        [Test]
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
                Action fail = () => Require.NotEmpty(input);

                fail.Should().Throw<ArgumentException>();
            }
        }
    }
}
