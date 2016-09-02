using ArmyOfCreatures.Console.Commands;
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
    public class CommandManagerTests
    {
        [Test]
        public void ProcessCommand_WhenInvalidCommandLineIsPassed_ShouldThrowArgumentNullException()
        {
            var commandManager = new CommandManager();
            var mockedFactory = new Mock<ICreaturesFactory>();
            var mockedLogger = new Mock<ILogger>();

            var battleManager = new MockedBattleManager(mockedFactory.Object, mockedLogger.Object);

            Assert.Throws<ArgumentNullException>(() => commandManager.ProcessCommand(null, battleManager));
        }

       
    }
}
