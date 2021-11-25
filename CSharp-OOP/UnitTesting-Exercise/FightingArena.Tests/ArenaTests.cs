using NUnit.Framework;
using System;
using System.Linq;

namespace Tests
{
    public class ArenaTests
    {
        private Arena arena;
        [SetUp]
        public void Setup()
        {
            this.arena = new Arena();
        }

        [Test]
        public void CtorInitializeWarrior()
        {
            Assert.That(this.arena.Warriors, Is.Not.Null);
        }

        [Test]
        public void CountIsZeroWhenArenaIsEmpty()
        {
            Assert.That(this.arena.Count, Is.EqualTo(0));
        }

        [Test]
        public void EnrollThrowsExceptionWhenWarriorExists()
        {
            string name = "Warrior";
            this.arena.Enroll(new Warrior(name, 50, 50));
            Assert.Throws<InvalidOperationException>(() => this.arena.Enroll(new Warrior(name, 55, 55)));
        }

        [Test]
        public void EnrollIncreasesArenaCount()
        {
            this.arena.Enroll(new Warrior("Warrior", 50, 50));
            Assert.That(this.arena.Count, Is.EqualTo(1));
        }

        [Test]
        public void EnrollAddsWarriorToWarriors()
        {
            string name = "Warrior";
            this.arena.Enroll(new Warrior(name, 50, 50));
            Assert.That(this.arena.Warriors.Any(w => w.Name == name), Is.True);
        }

        [Test]
        public void FightThrowsExceptionWhenDefenderDoesNotExcist()
        {
            string attacker = "Attacker";
            this.arena.Enroll(new Warrior(attacker, 50, 100));
            Assert.Throws<InvalidOperationException>(() => this.arena.Fight(attacker, "Defender"));
        }

        [Test]
        public void FightThrowsExceptionWhenAttacerDoesNotExcist()
        {
            string defender = "Defender";
            this.arena.Enroll(new Warrior(defender, 50, 100));
            Assert.Throws<InvalidOperationException>(() => this.arena.Fight("Attacker", defender));
        }

        [Test]
        public void FightThrowsExceptionWhenBothDoesNotExcist()
        {
            Assert.Throws<InvalidOperationException>(() => this.arena.Fight("Attacker", "Defender"));
        }

        [Test]
        public void FightBothWarriorsLoseHealthPointsInFight()
        {
            int initialHP = 100;
            var attacker = new Warrior("Attacker", 50, initialHP);
            var defender = new Warrior("Defender", 60, initialHP);

            this.arena.Enroll(attacker);
            this.arena.Enroll(defender);
            this.arena.Fight(attacker.Name, defender.Name);

            Assert.That(attacker.HP, Is.EqualTo(initialHP - defender.Damage));
            Assert.That(defender.HP, Is.EqualTo(initialHP - attacker.Damage));
        }
    }
}
