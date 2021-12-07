using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;

namespace WarCroft.Entities.Characters
{
    public class Priest : Character, IHealer
    {
        private const double InitialHealth = 50;
        private const double InitialArmor = 25;
        private const double InitialAbilityPoints = 40;
        public Priest(string name)
            : base(name, InitialHealth, InitialArmor, InitialAbilityPoints, new Backpack())
        {
        }

        public void Heal(Character character)
        {
            this.EnsureAlive();
            if (!character.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }

            character.Health += this.AbilityPoints;
        }
    }
}
