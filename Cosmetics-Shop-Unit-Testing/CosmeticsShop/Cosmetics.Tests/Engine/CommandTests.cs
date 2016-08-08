using Cosmetics.Engine;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Cosmetics.Tests.Engine
{
    [TestFixture]
    public class CommandTests
    {
        [Test]
        public void Parse_WhenTheInputStringIsValid_ShouldReturnNewCommand()
        {
            var validInput = "CreateShampoo Cool Nivea 0.50 men 500 everyday";

            var command = Command.Parse(validInput);

            Assert.IsInstanceOf<Command>(command);
        }

        [TestCase("CreateShampoo Cool Nivea 0.50 men 500 everyday", "CreateShampoo")]
        [TestCase("CreateToothpaste White+ Colgate 15.50 men fluor,bqla,golqma", "CreateToothpaste")]
        [TestCase("ShowCategory ForMale", "ShowCategory")]
        public void Parse_WhenTheInputStringIsValid_ShouldSetProperlyTheNamePropertyOfTheReturnedCommand(string input, string expectedOutput)
        {
            var command = Command.Parse(input);

            Assert.AreEqual(expectedOutput, command.Name);
        }

        [TestCase("CreateShampoo Cool Nivea 0.50 men 500 everyday", new[] { "Cool", "Nivea", "0.50", "men", "500", "everyday" })]
        [TestCase("CreateCategory ForMale", new[] { "ForMale" })]
        [TestCase("ShowCategory ForMale", new[] { "ForMale" })]
        public void Parse_WhenTheInputStringIsValid_ShouldSetProperlyTheParametersPropertyOfTheReturnedCommand(string input, string[] expectedOutput)
        { 
            var command = Command.Parse(input);

            Assert.AreEqual(expectedOutput, command.Parameters);
        }

        [Test]
        public void Parse_WhenTheInputStringIsNull_ShouldThrowNullreferenceException()
        {
            Assert.Throws<NullReferenceException>(() => Command.Parse(null));
        }

        [Test]
        public void Parse_WhenTheInputParamsHasInvalidName_ShouldThrowArgumentNullException()
        {
            string invalidInput = " ForMale";

            Assert.That(() => Command.Parse(invalidInput), Throws.ArgumentNullException.With.Message.Contains("Name"));
        }

        [Test]
        public void Parse_WhenTheInputParamsHasInvalidParameters_ShouldThrowArgumentNullException()
        {
            string invalidInput = "AddToCategory ";
            Assert.That(() => Command.Parse(invalidInput), Throws.ArgumentNullException.With.Message.Contains("List"));
        }
    }
}
