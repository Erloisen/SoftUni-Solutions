using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skeleton.Test
{
    [TestFixture]
    public class DummyTest
    {
        [Test]
        [TestCase(30, 10)]
        public void CtorSetDummy(int health, int experience)
        {
            Dummy dummy = new Dummy(health, experience);
            Assert.That(health, Is.EqualTo(dummy.Health));
        }

        [Test]
        [TestCase(0, 10)]
        [TestCase(-10, 10)]
        public void IsThatMethodWorkingProperlyWhenHealthIsZeroOrLess(int health, int experience)
        {
            Dummy dummy = new Dummy(health, experience);
            Assert.That(dummy.IsDead, Is.True);
        }

        [Test]
        [TestCase(0, 10, 10)]
        [TestCase(-10, 10, 20)]
        public void TakeAttackeMethodThrowExceptionWhenHealthIsZeroOrLess(int health, int experience, int attackPoints)
        {
            Dummy dummy = new Dummy(health, experience);
            Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(attackPoints));
        }

        [Test]
        [TestCase(40, 10, 10)]
        [TestCase(30, 10, 20)]
        public void TakeAttackeMethodDecreasesHealthByItsAttackPoints(int health, int experience, int attackPoints)
        {
            //this.health -= attackPoints;
            Dummy dummy = new Dummy(health, experience);
            dummy.TakeAttack(attackPoints);
            Assert.That(dummy.Health, Is.EqualTo(health - attackPoints));
        }

        [Test]
        public void GiveExperienceMethodThrowExceptionWhenDummysHealthIsMoreThanZero()
        {
            Dummy dummy = new Dummy(10, 0);
            Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience());
        }

        [Test]
        [TestCase(0, 1)]
        [TestCase(-1, 2)]
        public void GiveExperienceMethodIncreasesExperiencePointsWhenDummysHealthIsZeroOrLess(int health, int experience)
        {
            Dummy dummy = new Dummy(health, experience);
            Assert.That(dummy.GiveExperience(), Is.EqualTo(experience));
        }
    }
}
