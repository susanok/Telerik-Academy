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
    public class CreaturesInBattleTests
    {
        [Test]
        public void CreaturesInBattleDealDamage_WhenInvalidDefenderIsPassed_ShouldThrowArgumentNullException()
        {
            var creature = new Angel();
            var creaturesInBattle = new CreaturesInBattle(creature, 1);

            Assert.Throws<ArgumentNullException>(() => creaturesInBattle.DealDamage(null));
        }

        //TODO: other tests
    }
}
