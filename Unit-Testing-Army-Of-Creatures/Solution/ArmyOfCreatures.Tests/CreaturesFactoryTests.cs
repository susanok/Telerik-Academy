namespace ArmyOfCreatures.Tests
{
    using Extended;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CreaturesFactoryTests
    {
        [TestCase("Angel")]
        [TestCase("Archangel")]
        [TestCase("ArchDevil")]
        [TestCase("Behemoth")]
        [TestCase("Devil")]
        [TestCase("Goblin")]
        [TestCase("WolfRaider")]
        [TestCase("Griffin")]
        [TestCase("CyclopsKing")]
        
        public void ExtendedCreaturesFactory_WhenValidNameIsPassed_ShouldReturnExpectedType(string name)
        {
            //Arrange
            var factory = new ExtendedCreaturesFactory();

            //Act
            var creature = factory.CreateCreature(name);

            //Assert
            Assert.AreEqual(name,
                creature.GetType().Name, "Creature is not initialized properly");
        }

        [Test]

        public void ExtendedCreaturesFactory_WhenInValidNameIsPassed_ShouldThrowArgumentException()
        {
            //Arrange
            var factory = new ExtendedCreaturesFactory();

            //Act & Assert
            Assert.Throws<ArgumentException>(() => factory.CreateCreature(""));
        }

        [Test]

        public void ExtendedCreaturesFactory_WhenInValidNameIsPassed_ShouldThrowArgumentExceptionWithExpectedMessage()
        {
            var factory = new ExtendedCreaturesFactory();

            try
            {
                factory.CreateCreature(""); 
            }
            catch (ArgumentException exception)
            {

                Assert.AreEqual($"Invalid creature type \"\"!", exception.Message, "Exception's message is not correct");
            }
        }
    }
}
