namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class AquariumsTests
    {
        [Test]
        public void ConstructorShouldSetAquariumsNameAndCapacity()
        {
            string name = "Aquarium";
            int capasity = 10;
            Aquarium aquarium = new Aquarium(name, capasity);
            Assert.That(name, Is.EqualTo(aquarium.Name));
            Assert.That(capasity, Is.EqualTo(aquarium.Capacity));
        }

        [Test]
        [TestCase(null, 10)]
        public void NameShoulThrowExceptionWhenIsNullOrEmpty(string name, int capacity)
        {
            Assert.Throws<ArgumentNullException>(() => new Aquarium(name, capacity));
        }

        [Test]
        [TestCase("SaltWater", -1)]
        [TestCase("FreshWater", -10)]
        public void CapacityShoulThrowExceptionWhenIsBelowZero(string name, int capacity)
        {
            Assert.Throws<ArgumentException>(() => new Aquarium(name, capacity));
        }

        [Test]
        public void CountMethodShouldWorkProperly()
        {
            string name = "Aquarium";
            int capasity = 10;
            Aquarium aquarium = new Aquarium(name, capasity);
            Fish fish = new Fish("Nemo");
            aquarium.Add(fish);
            Assert.That(1, Is.EqualTo(aquarium.Count));
        }

        [Test]
        public void AddMethodShouldThrowExceptionWhenTryToAddFishOverTheCapacity()
        {
            string name = "Aquarium";
            int capasity = 0;
            Aquarium aquarium = new Aquarium(name, capasity);
            Fish fish = new Fish("Nemo");
            Assert.Throws<InvalidOperationException>(() => aquarium.Add(fish));
        }

        [Test]
        public void RemoveMethodShouldWorkProperly()
        {
            Aquarium aquarium = new Aquarium("Aquarium", 10);
            aquarium.Add(new Fish("Nemo"));
            aquarium.RemoveFish("Nemo");
            Assert.That(0, Is.EqualTo(aquarium.Count));
        }

        [Test]
        public void RemoveMethodShouldThrowExceptionWhenThereIsNoFishWithSubmittedName()
        {
            Aquarium aquarium = new Aquarium("Aquarium", 10);
            aquarium.Add(new Fish("Nemo"));
            Assert.Throws<InvalidOperationException>(() => aquarium.RemoveFish("Loli"));
        }

        [Test]
        public void SellFishMethodShouldWorkProperly()
        {
            Aquarium aquarium = new Aquarium("Aquarium", 10);
            Fish fish = new Fish("Nemo");
            aquarium.Add(fish);
            var sealdFish = aquarium.SellFish("Nemo");
            Assert.That("Nemo", Is.EqualTo(sealdFish.Name));
            Assert.IsFalse(fish.Available);
        }

        [Test]
        public void SellFishMethodShouldThrowAnExceptionWhenTryToSellNonExcistingFish()
        {
            Aquarium aquarium = new Aquarium("Aquarium", 10);
            aquarium.Add(new Fish("Nemo"));
            Assert.Throws<InvalidOperationException>(() => aquarium.SellFish("Loli"));
        }

        [Test]
        public void ReportMethodShouldWorkProperly()
        {
            Aquarium aquarium = new Aquarium("Aquarium", 10);
            aquarium.Add(new Fish("Nemo"));
            aquarium.Add(new Fish("Loli"));
            aquarium.Add(new Fish("Poly"));
            string message = "Fish available at Aquarium: Nemo, Loli, Poly";
            Assert.That(message, Is.EqualTo(aquarium.Report()));
        }
    }
}
