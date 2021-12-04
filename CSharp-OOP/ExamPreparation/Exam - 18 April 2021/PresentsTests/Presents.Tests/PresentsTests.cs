namespace Presents.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class PresentsTests
    {
        [Test]
        public void ConstructorShouldInitializeAllValues()
        {
            Bag bagOfPresents = new Bag();
            Assert.IsNotNull(bagOfPresents.GetPresents());
        }

        [Test]
        public void CreateMethodShouldThrowAnExceptionWhenPresentNameIsNull()
        {
            Bag bagOfPresents = new Bag();
            Assert.Throws<ArgumentNullException>(() => bagOfPresents.Create(null));
        }

        [Test]
        public void CreateMethodShouldThrowAnExceptionWhenPresentsAreDuplicate()
        {
            Bag bagOfPresents = new Bag();
            Present present = new Present("Present", 10);
            bagOfPresents.Create(present);
            Assert.Throws<InvalidOperationException>(() => bagOfPresents.Create(present));
        }

        [Test]
        public void CreateMethodShouldCreateBagOfPresents()
        {
            Bag bagOfPresents = new Bag();
            Present present = new Present("Present", 10);
            bagOfPresents.Create(present);
            Assert.AreEqual(1, bagOfPresents.GetPresents().Count);
        }

        [Test]
        public void CreateMethodShouldReturnAMessageWhenCreateBagOfPresents()
        {
            Bag bagOfPresents = new Bag();
            Present present = new Present("Present", 10);
            string expected = "Successfully added present Present.";
            string message = bagOfPresents.Create(present);
            Assert.AreEqual(expected, message);
        }

        [Test]
        public void CreateShouldReturnValidNameAndMagicFromCollection()
        {
            Bag bagOfPresents = new Bag();
            Present present = new Present("Present", 10);
            bagOfPresents.Create(present);
            Assert.IsTrue(bagOfPresents.GetPresents().Any(p => p.Name == "Present" && p.Magic == 10));
        }

        [Test]
        public void RemoveMethodOfBagShouldReturnTrue()
        {
            Bag bagOfPresents = new Bag();
            Present present = new Present("Present", 0.5);
            bagOfPresents.Create(present);
            var result = bagOfPresents.Remove(present);
            Assert.AreEqual(0, bagOfPresents.GetPresents().Count);
        }

        [Test]
        public void RemoveMethodOfBagShouldReturnFalse()
        {
            Bag bagOfPresents = new Bag();
            var result = bagOfPresents.Remove(null);
            Assert.IsFalse(result);
        }

        [Test]
        public void GetPresentWithLeastMagicShouldWorkProperly()
        {
            Bag bagOfPresents = new Bag();
            Present present1 = new Present("Present1", 0.6);
            Present present2 = new Present("Present2", 0.7);
            bagOfPresents.Create(present1);
            bagOfPresents.Create(present2);
            var result = bagOfPresents.GetPresentWithLeastMagic();
            Assert.AreSame(present1, result);
        }

        [Test]
        public void GetPresentMethodShouldReturnPresentWhithGevenName()
        {
            Bag bagOfPresents = new Bag();
            Present present = new Present("Present", 0.5);
            bagOfPresents.Create(present);
            var result = bagOfPresents.GetPresent("Present");
            Assert.AreSame(present, result);
        }
    }
}
