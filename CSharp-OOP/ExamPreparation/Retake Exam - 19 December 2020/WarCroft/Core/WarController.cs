using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
    public class WarController
    {
        private List<Character> party;
        private Stack<Item> pool;
        public WarController()
        {
            this.party = new List<Character>();
            this.pool = new Stack<Item>();
        }

        public string JoinParty(string[] args)
        {
            string characterType = args[0];
            string name = args[1];

            Character character;
            if (characterType == nameof(Priest))
            {
                character = new Priest(name);
            }
            else if (characterType == nameof(Warrior))
            {
                character = new Warrior(name);
            }
            else
            {
                throw new ArgumentException($"Invalid character type \"{characterType}\"!");
            }

            party.Add(character);
            return $"{name} joined the party!";
        }

        public string AddItemToPool(string[] args)
        {
            string itemName = args[0];

            Item item;
            if (itemName == nameof(FirePotion))
            {
                item = new FirePotion();
            }
            else if (itemName == nameof(HealthPotion))
            {
                item = new HealthPotion();
            }
            else
            {
                throw new ArgumentException($"Invalid item \"{itemName}\"!");
            }

            pool.Push(item);
            return $"{itemName} added to pool.";
        }

        public string PickUpItem(string[] args)
        {
            string characterName = args[0];

            Character character = party.FirstOrDefault(ch => ch.Name == characterName);
            if (character == null)
            {
                throw new ArgumentException($"Character {characterName} not found!");
            }

            if (pool.Count == 0)
            {
                throw new InvalidOperationException("No items left in pool!");
            }

            Item currentItem = pool.Pop();
            character.Bag.AddItem(currentItem);
            return $"{characterName} picked up {currentItem.GetType().Name}!";
        }

        public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];

            Character character = party.FirstOrDefault(ch => ch.Name == characterName);
            if (character == null)
            {
                throw new ArgumentException($"Character {characterName} not found!");
            }

            var item = character.Bag.GetItem(itemName);
            character.UseItem(item);
            return $"{character.Name} used {itemName}.";
        }

        public string GetStats()
        {
            StringBuilder sb = new StringBuilder();
            var orederdCharacters = party
                .OrderByDescending(ch => ch.IsAlive)
                .ThenByDescending(ch => ch.Health);

            foreach (var character in orederdCharacters)
            {
                string status = character.IsAlive ? "Alive" : "Dead";

                sb.AppendLine($"{character.Name} - HP: {character.Health}/{character.BaseHealth}, " +
                       $"AP: {character.Armor}/{character.BaseArmor}, Status: {status}");
            }

            return sb.ToString().TrimEnd();
        }

        public string Attack(string[] args)
        {
            string attackerName = args[0];
            string receiverName = args[1];

            Character attacker = party.FirstOrDefault(a => a.Name == attackerName);
            Character receiver = party.FirstOrDefault(a => a.Name == receiverName);
            if (attacker == null)
            {
                throw new ArgumentException($"Character {attackerName} not found!");
            }

            if (receiver == null)
            {
                throw new ArgumentException($"Character {receiverName} not found!");
            }

            if (party.FirstOrDefault(a => a.Name == attackerName).GetType().Name != nameof(Warrior))
            {
                throw new ArgumentException($"{attacker.Name} cannot attack!");
            }

            Warrior currentAttacher = (Warrior)party.FirstOrDefault(a => a.Name == attackerName);
            currentAttacher.Attack(receiver);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{attackerName} attacks {receiverName} for {attacker.AbilityPoints} hit points! " +
                $"{receiverName} has {receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!");

            if (!receiver.IsAlive)
            {
                sb.AppendLine($"{receiver.Name} is dead!");
            }

            return sb.ToString().TrimEnd();
        }

        public string Heal(string[] args)
        {
            string healerName = args[0];
            string healingReceiverName = args[1];

            Character healer = party.FirstOrDefault(a => a.Name == healerName);
            Character receiver = party.FirstOrDefault(a => a.Name == healingReceiverName);
            if (healer == null)
            {
                throw new ArgumentException($"Character {healerName} not found!");
            }

            if (healer == null)
            {
                throw new ArgumentException($"Character {healingReceiverName} not found!");
            }

            if (party.FirstOrDefault(a => a.Name == healerName).GetType().Name != nameof(Priest))
            {
                throw new ArgumentException($"{healerName} cannot heal!");
            }

            Priest currentHealer = (Priest)party.FirstOrDefault(a => a.Name == healerName);
            currentHealer.Heal(receiver);

            return $"{currentHealer.Name} heals {receiver.Name} for {currentHealer.AbilityPoints}! {receiver.Name} has {receiver.Health} health now!";
        }
    }
}
