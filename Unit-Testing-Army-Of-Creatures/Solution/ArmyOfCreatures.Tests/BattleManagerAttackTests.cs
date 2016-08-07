using ArmyOfCreatures.Logic;
using ArmyOfCreatures.Logic.Battles;
using ArmyOfCreatures.Logic.Creatures;
using ArmyOfCreatures.Tests.MockedClasses;
using Moq;
using NUnit.Framework;
using System;
using System.Linq;

namespace ArmyOfCreatures.Tests
{
    [TestFixture]
    class BattleManagerAttackTests
    {
        [Test]

        public void AttackBattleManager_WhenAttackerCreatureIsNull_ShouldThrowArgumentNullException()
        {
            var mockedFactory = new Mock<ICreaturesFactory>();
            var mockedLogger = new Mock<ILogger>();

            var battleManager = new BattleManager(mockedFactory.Object, mockedLogger.Object);

            var identifier = CreatureIdentifier.CreatureIdentifierFromString("Angel(1)");
            Assert.Throws<ArgumentException>(() => battleManager.Attack(identifier, identifier));
        }

        [Test]

        public void AttackBattleManager_WhendefenderCreatureIsNull_ShouldThrowArgumentNullException()
        {
            var mockedFactory = new Mock<ICreaturesFactory>();
            var mockedLogger = new Mock<ILogger>();

            var battleManager = new BattleManager(mockedFactory.Object, mockedLogger.Object);

            var identifier = CreatureIdentifier.CreatureIdentifierFromString("Angel(1)");
            Assert.Throws<ArgumentException>(() => battleManager.Attack(identifier, identifier));
        }

        [Test]

        public void AttackBattleManager_WhenAttackIsSuccessful_ShouldCallWriteLineFourTimes()
        {
            // Arrange
            var mockedFactory = new Mock<ICreaturesFactory>();
            var mockedLogger = new Mock<ILogger>();

            var battleManager = new MockedBattleManager(mockedFactory.Object, mockedLogger.Object);

            var identifierAttacker = CreatureIdentifier.CreatureIdentifierFromString("Angel(1)");
            var identifierDefender = CreatureIdentifier.CreatureIdentifierFromString("Angel(2)");

            var creature = new Angel();

            mockedFactory.Setup(x => x.CreateCreature(It.IsAny<string>())).Returns(creature);

            mockedLogger.Setup(x => x.WriteLine(It.IsAny<string>()));

            battleManager.AddCreatures(identifierAttacker, 1);
            battleManager.AddCreatures(identifierDefender, 1);

            // Act
            battleManager.Attack(identifierAttacker, identifierDefender);

            // Assert
            mockedLogger.Verify(x => x.WriteLine(It.IsAny<string>()), Times.Exactly(4));
        }

        [Test]

        public void AttackBattleManager_WhenAttackingOwnArmy_ShouldThrowArgumentException()
        {
            // Arrange
            var mockedFactory = new Mock<ICreaturesFactory>();
            var mockedLogger = new Mock<ILogger>();

            var battleManager = new MockedBattleManager(mockedFactory.Object, mockedLogger.Object);

            var identifierAttacker = CreatureIdentifier.CreatureIdentifierFromString("Angel(1)");
            var identifierDefender = CreatureIdentifier.CreatureIdentifierFromString("Angel(1)");

            var creature = new Angel();

            mockedFactory.Setup(x => x.CreateCreature(It.IsAny<string>())).Returns(creature);

            mockedLogger.Setup(x => x.WriteLine(It.IsAny<string>()));

            battleManager.AddCreatures(identifierAttacker, 1);
            battleManager.AddCreatures(identifierDefender, 1);

            // Assert
            Assert.Throws<ArgumentException>(() => battleManager.Attack(identifierAttacker, identifierDefender));
        }

        
    }
}
