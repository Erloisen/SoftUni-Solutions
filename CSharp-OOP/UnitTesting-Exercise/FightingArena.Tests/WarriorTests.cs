using NUnit.Framework;
using System;

namespace Tests
{
    public class WarriorTests
    {
        [Test]
        public void CtorShouldWorksCorrectly()
        {
            string expectedName = "WarriorName";
            int expectedDamage = 50;
            int expectedHP = 100;

            var warrior = new Warrior(expectedName, expectedDamage, expectedHP);

            Assert.That(expectedName, Is.EqualTo(warrior.Name));
            Assert.That(expectedDamage, Is.EqualTo(warrior.Damage));
            Assert.That(expectedHP, Is.EqualTo(warrior.HP));
        }

        [Test]
        [TestCase("", 50, 100)]
        [TestCase("  ", 50, 100)]
        [TestCase(null, 50, 100)]
        [TestCase("WarriorName", 0, 100)]
        [TestCase("WarriorName", -10, 100)]
        [TestCase("WarriorName", 50, -10)]
        public void CtorThrowsExceptionWhenDataIsInvalide(string name, int damage, int hp)
        {
            Assert.Throws<ArgumentException>(() => new Warrior(name, damage, hp));
        }

        [Test]
        [TestCase(30, 55)]
        [TestCase(15, 55)]
        [TestCase(55, 30)]
        [TestCase(55, 15)]
        public void AttackThrowsExceptionWhenHpIsLessThenMinimum(int attackerHp, int warriorHp)
        {
            var attacker = new Warrior("Attacker", 50, attackerHp);
            var warrior = new Warrior("Warrior", 10, warriorHp);
            Assert.Throws<InvalidOperationException>(() => attacker.Attack(warrior));
        }

        [Test]
        public void AttackThrowsExceptionWhenWarriorKillsTheAttacker()
        {
            var attacker = new Warrior("Attacker", 50, 100);
            var warrior = new Warrior("Warrior", attacker.HP + 1, 100);
            Assert.Throws<InvalidOperationException>(() => attacker.Attack(warrior));
        }

        [Test]
        public void AttackDecreasesHealthPointsForBothSides()
        {
            int initialAttackerHp = 100;
            int warriorInitialHp = 100;
            var attacker = new Warrior("Attacker", 50, initialAttackerHp);
            var warrior = new Warrior("Warrior", 30, warriorInitialHp);
            attacker.Attack(warrior);
            Assert.That(attacker.HP, Is.EqualTo(initialAttackerHp - warrior.Damage));
            Assert.That(warrior.HP, Is.EqualTo(warriorInitialHp - attacker.Damage));
        }

        [Test]
        public void AttackSetEnemyHealthPointsToZeroWhenAttackerDamegeIsGreaterThanEnemyHp()
        {
            var attacker = new Warrior("Attacker", 50, 100);
            var warrior = new Warrior("Warrior", 30, 40);
            attacker.Attack(warrior);
            Assert.That(warrior.HP, Is.EqualTo(0));
        }
    }
}