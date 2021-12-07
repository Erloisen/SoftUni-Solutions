using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
        private string name;
        private double health;
        private double armor;

        public Character(string name, double health, double armor, double abilityPoints, IBag bag)
        {
            this.Name = name;
            this.BaseHealth = health;
            this.Health = health;
            this.BaseArmor = armor;
            this.Armor = armor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
        }
        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }

                this.name = value;
            }
        }

        public double BaseHealth { get; private set; }

        public double Health
        {
            get => this.health;
            set
            {
                if (value > this.BaseHealth)
                {
                    this.health = this.BaseHealth;
                }
                else if (value < 0)
                {
                    this.health = 0;
                }
                else
                {
                    this.health = value;
                }
            }
        }

        public double BaseArmor { get; private set; }

        public double Armor
        {
            get => this.armor;
            private set
            {
                if (value < 0)
                {
                    this.armor = 0;
                }
                else if (value > this.BaseArmor)
                {
                    this.armor = this.BaseArmor;
                }
                else
                {
                    this.armor = value;
                }
            }
        }

        public double AbilityPoints { get; private set; }

        public IBag Bag { get; set; }

        public bool IsAlive { get; set; } = true;

        public void TakeDamage(double hitPoints)
        {
            this.EnsureAlive();
            double healthReduce = hitPoints - this.Armor;
            this.Armor -= hitPoints;

            if (healthReduce > 0)
            {
                this.Health -= healthReduce;
            }

            if (this.Health == 0)
            {
                this.IsAlive = false;
            }
        }

        public void UseItem(Item item)
        {
            this.EnsureAlive();
            item.AffectCharacter(this);
        }

        protected void EnsureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }
    }
}