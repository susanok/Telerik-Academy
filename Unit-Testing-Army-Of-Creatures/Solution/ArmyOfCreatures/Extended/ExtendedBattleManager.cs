﻿using ArmyOfCreatures.Logic;
using ArmyOfCreatures.Logic.Battles;
using System.Collections.Generic;
using System.Linq;

namespace ArmyOfCreatures.Extended
{
    public class ExtendedBattleManager : BattleManager, IBattleManager
    {
        private readonly ICollection<ICreaturesInBattle> thirdArmyCreatures;

        public ExtendedBattleManager(ICreaturesFactory creaturesFactory, ILogger logger) : base(creaturesFactory, logger)
        {
            this.thirdArmyCreatures = new List<ICreaturesInBattle>();
        }

        public ExtendedBattleManager(ExtendedCreaturesFactory creaturesFactory, ILogger logger)
            :base(creaturesFactory, logger)
        {
        }

        protected override void AddCreaturesByIdentifier(CreatureIdentifier creatureIdentifier, ICreaturesInBattle creaturesInBattle)
        {
            if (creatureIdentifier.ArmyNumber == 3)
            {
                this.thirdArmyCreatures.Add(creaturesInBattle);
            }
            else
            {
                base.AddCreaturesByIdentifier(creatureIdentifier, creaturesInBattle);
            }
        }

        protected override ICreaturesInBattle GetByIdentifier(CreatureIdentifier identifier)
        {
            if (identifier.ArmyNumber == 3)
            {
                return this.thirdArmyCreatures.FirstOrDefault(x => x.Creature.GetType().Name == identifier.CreatureType);
            }
            else
            {
                return base.GetByIdentifier(identifier);
            }
        }
    }
}
