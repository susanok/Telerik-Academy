using ArmyOfCreatures.Logic.Battles;
using NUnit.Framework;
using Moq;
using ArmyOfCreatures.Logic;
using System;
using Ploeh.AutoFixture;
using ArmyOfCreatures.Logic.Creatures;

namespace ArmyOfCreatures.Tests
{
    [TestFixture]
    public class BattleManagerAddCreaturesTests
    {
        [Test]

        public void AddCreatures_WhenCreatureIdentifierIsNull_ShouldThrowArgumentNullException()
        {
            var mockedFactory = new Mock<ICreaturesFactory>();
            var mockedLogger = new Mock<ILogger>();

            var battleManager = new BattleManager(mockedFactory.Object, mockedLogger.Object);

            Assert.Throws<ArgumentNullException>(() => battleManager.AddCreatures(null, 1));
        }

        [Test]

        public void AddCreatures_WhenValidIdentifierIsPassed_FactoryShouldCallCreateCreature()
        {
            var mockedFactory = new Mock<ICreaturesFactory>();
            var mockedLogger = new Mock<ILogger>();

            var battleManager = new BattleManager(mockedFactory.Object, mockedLogger.Object);

            //var fixture = new Fixture();

            //var identifier = fixture.Create<CreatureIdentifier>();

            var creature = new Angel();

            mockedFactory.Setup(x => x.CreateCreature(It.IsAny<string>())).Returns(creature);

            var identifier = CreatureIdentifier.CreatureIdentifierFromString("Angel(1)");
            
            battleManager.AddCreatures(identifier, 1);

            mockedFactory.Verify(x => x.CreateCreature(It.IsAny<string>()), Times.Exactly(1));
        }

        [Test]

        public void AddCreatures_WhenValidIdentifierIsPassed_WriteLineShouldbeCalled()
        {
            var mockedFactory = new Mock<ICreaturesFactory>();
            var mockedLogger = new Mock<ILogger>();

            var battleManager = new BattleManager(mockedFactory.Object, mockedLogger.Object);

            //var fixture = new Fixture();

            //var identifier = fixture.Create<CreatureIdentifier>();

            var creature = new Angel();

            mockedFactory.Setup(x => x.CreateCreature(It.IsAny<string>())).Returns(creature);

            mockedLogger.Setup(x => x.WriteLine(It.IsAny<string>()));

            var identifier = CreatureIdentifier.CreatureIdentifierFromString("Angel(1)");

            battleManager.AddCreatures(identifier, 1);

            mockedLogger.Verify();
        }
    }
}
