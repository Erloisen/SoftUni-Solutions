using NUnit.Framework;
using System;

namespace Skeleton.Test
{
    [TestFixture]
    public class AxeTests
    {
        private const int AttackPoints = 10;
        private const int DurabilityPoints = 1;
        private const int DummyHealth = 30;
        private const int DummyExperience = 10;

        private Axe axe;
        private Dummy dummy;

        [SetUp]
        public void SetUp()
        {
            this.axe = new Axe(AttackPoints, DurabilityPoints);
            this.dummy = new Dummy(DummyHealth, DummyExperience);
        }

        [Test]
        public void AxeLoosesDurabilityAfterAttack()
        {
            this.axe.Attack(dummy);
            Assert.That(this.axe.DurabilityPoints, Is.EqualTo(0), "Axe Durability doesn't change after attack.");
        }

        [Test]
        public void BrockenAxeCanNotAttack_ThrowInvalidOperationException()
        {
            axe.Attack(dummy);
            Assert.Throws<InvalidOperationException>(() => this.axe.Attack(this.dummy), "Axe does not throw InvalidOperationException when attacking with 0 Durability.");
        }
    }
}