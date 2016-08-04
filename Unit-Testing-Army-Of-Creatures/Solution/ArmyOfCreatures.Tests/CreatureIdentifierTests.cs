namespace ArmyOfCreatures.Tests
{
    using Logic.Battles;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CreatureIdentifierTests
    {
        [Test]
        public void CreatureIdentifierFromString_WhenNullValueIsPassed_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => CreatureIdentifier.CreatureIdentifierFromString(null));
        }

        [Test]
        public void CreatureIdentifierFromString_WhenInvalidValueToParseIntIsPassed_ShouldThrowFormatException()
        {
            Assert.Throws<FormatException>(() => CreatureIdentifier.CreatureIdentifierFromString("Angel(test)"));
        }

        [Test]
        public void CreatureIdentifierFromString_WhenInvalidValueIsPassed_ShouldThrowIndexOutOfRangeException()
        {
            Assert.Throws<IndexOutOfRangeException>(() => CreatureIdentifier.CreatureIdentifierFromString("Angel"));
        }

        [Test]
        public void CreatureIdentifierFromString_WhenValueIsPassed_ShouldReturnExpectedType()
        {
            var identifier = CreatureIdentifier.CreatureIdentifierFromString("Angel(1)");

            Assert.IsInstanceOf<CreatureIdentifier>(identifier);
        }

    }
}
