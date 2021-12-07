using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;

namespace WarCroft.Entities.Characters
{
    public class Warrior : Character, IAttacker
    {
        private const double InitialHealth = 100;
        private const double InitialArmor = 50;
        private const double InitialAbilityPoints = 40;
        public Warrior(string name)
            : base(name, InitialHealth, InitialArmor, InitialAbilityPoints, new Satchel())
        {
        }

        public void Attack(Character character)
        {
            this.EnsureAlive();

            if (character.Equals(this))
            {
                throw new InvalidOperationException("Cannot attack self!");
            }

            character.TakeDamage(this.AbilityPoints);
        }
    }
}
