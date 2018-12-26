using FluentAssertions;
using System;
using NiceToHave.Desicion;
using NUnit.Framework;

namespace NiceToHave.Test.DesicionTest
{
    [TestFixture]
    public class StatemachineTests
    {
        [Test]
        public void StatemachineShouldWork()
        {
            Statemachine<TestClass> machine = new Statemachine<TestClass>();

            machine.InitialiState.TransitToState("1", (element) => element.FuBar == null, (element) => element.FuBar = "1");
            machine.GetState("1").TransitToEnd((element) => element.FuBar == "2", (element) => element.FuBar = "end");
            machine.GetState("1").TransitToEnd((element) => element.FuBar == "1", (element) => element.FuBar = "2");

            TestClass test = new TestClass();
            machine.Execute(test);

            test.FuBar.Should().Be("2");
        }

        private class TestClass
        {
            public string FuBar { get; set; }
        }
    }
}
