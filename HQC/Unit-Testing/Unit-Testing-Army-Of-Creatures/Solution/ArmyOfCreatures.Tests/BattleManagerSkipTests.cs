using ArmyOfCreatures.Logic;
using ArmyOfCreatures.Logic.Battles;
using ArmyOfCreatures.Logic.Creatures;
using ArmyOfCreatures.Tests.MockedClasses;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyOfCreatures.Tests
{
    [TestFixture]
    public class BattleManagerSkipTests
    {
        [Test]
        public void Skip_WhenNullIsPassed_ShouldThrowArgumentException()
        {
            var mockedFactory = new Mock<ICreaturesFactory>();
            var mockedLogger = new Mock<ILogger>();

            var identifier = CreatureIdentifier.CreatureIdentifierFromString("Angel(1)");

            var battleManager = new BattleManager(mockedFactory.Object, mockedLogger.Object);

            Assert.Throws<ArgumentException>(() => battleManager.Skip(identifier));
        }

        [Test]
        public void Skip_WhenValidCreatureIdentifierIsPassed_ShouldCallWriteLineTwoTimes()
        {
            // Arrange
            var mockedFactory = new Mock<ICreaturesFactory>();
            var mockedLogger = new Mock<ILogger>();

            var identifier = CreatureIdentifier.CreatureIdentifierFromString("Angel(1)");

            var creature = new Angel();

            mockedFactory.Setup(x => x.CreateCreature(It.IsAny<string>())).Returns(creature);
            mockedLogger.Setup(x => x.WriteLine(It.IsAny<string>()));

            var battleManager = new MockedBattleManager(mockedFactory.Object, mockedLogger.Object);

            battleManager.AddCreatures(identifier, 1);

            // Act
            battleManager.Skip(identifier);

            // Assert
            mockedLogger.Verify(x => x.WriteLine(It.IsAny<string>()), Times.Exactly(2));
        }
    }
}
