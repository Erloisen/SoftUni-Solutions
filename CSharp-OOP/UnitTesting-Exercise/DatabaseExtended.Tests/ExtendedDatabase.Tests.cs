using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Test
{
    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase exdb;
        [SetUp]
        public void SetUp()
        {
            this.exdb = new ExtendedDatabase();
        }

        [Test]
        public void ConstructrOfPersonShouldHaveNameAndId()
        {
            Person person = new Person(112233445566778899, "Elsiaveta");
            Assert.AreEqual(person.Id, 112233445566778899);
            Assert.AreEqual(person.UserName, "Elsiaveta");
        }

        [Test]
        [TestCase(0)]
        [TestCase(5)]
        [TestCase(16)]
        public void ConstructorExtendedDatabaseShoulAdd16PrsonsInARange(int amount)
        {
            var people = new Person[amount];

            for (int i = 0; i < amount; i++)
            {
                people[i] = new Person(i, i.ToString());
            }

            this.exdb = new ExtendedDatabase(people);

            Assert.IsNotNull(this.exdb);
        }

        

        [Test]
        public void AddRangeMethodShouldThrowExceptionWhenElementsAreMoreThen16()
        {
            for (int i = 0; i < 16; i++)
            {
                this.exdb.Add(new Person(i, i.ToString()));
            }

            var error = Assert.Throws<InvalidOperationException>(() => this.exdb.Add(new Person(16, "InvalidUserName")));
            Assert.AreEqual("Array's capacity must be exactly 16 integers!", error.Message);
        }

        [Test]
        public void RemoveShouldThrowExceptionWhenRangeIsEmpthy()
        {
            Assert.Throws<InvalidOperationException>(() => this.exdb.Remove());
        }

        [Test]
        [TestCase(5)]
        [TestCase(16)]
        public void RemoveMethodShouldRemoveElementsFromDatabase(int capasity)
        {
            for (int i = 0; i < capasity; i++)
            {
                this.exdb.Add(new Person(i, $"UserName{i}"));
            }

            this.exdb.Remove();
            Assert.That(this.exdb.Count, Is.EqualTo(capasity - 1));
            Assert.Throws<InvalidOperationException>(() => this.exdb.FindById(capasity - 1));
        }

        [Test]
        public void AddRangeMethodShouldThrowExceptionIfTryToAddSamePersonId()
        {
            this.exdb.Add(new Person(0000, "Agent007"));

            var error = Assert.Throws<InvalidOperationException>(() => this.exdb.Add(new Person(0000, "Agent006")));
            Assert.AreEqual("There is already user with this Id!", error.Message);
        }

        [Test]
        public void AddRangeMethodShouldThrowExceptionIfTryToAddSamePersonName()
        {
            this.exdb.Add(new Person(0000, "Agent007"));

            var error = Assert.Throws<InvalidOperationException>(() => this.exdb.Add(new Person(0001, "Agent007")));
            Assert.AreEqual("There is already user with this username!", error.Message);
        }

        [Test]
        public void FindByUserNameMethodShouldFindUserByItsName()
        {
            Person expectedResult = new Person(0003, "Agent003");

            this.exdb.Add(new Person(0001, "Agent001"));
            this.exdb.Add(new Person(0002, "Agent002"));
            this.exdb.Add(expectedResult); 
            this.exdb.Add(new Person(0004, "Agent004"));

            Person actualResult = this.exdb.FindByUsername(expectedResult.UserName);
            Assert.That(expectedResult, Is.EqualTo(actualResult));
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void FindByUserNameShouldThrowExceptionWhenNameIsNull(string userName)
        {
            Assert.Throws<ArgumentNullException>(() => this.exdb.FindByUsername(userName));
        }

        [Test]
        public void FindByUserNameMethodShouldThrowExceptionWhenUserDosentExist()
        {
            Assert.Throws<InvalidOperationException>(() => this.exdb.FindByUsername("UserName"));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(-3)]
        [TestCase(-15)]
        public void FindByIdShouldThrowExceptionWhenIdIsNegativeNumber(int userId)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => this.exdb.FindById(userId));
        }

        [Test]
        public void FindByIdMethodShouldThrowExceptionWhenUserIdDosentExist()
        {
            Assert.Throws<InvalidOperationException>(() => this.exdb.FindById(0001));
        }

        [Test]
        public void FindByIdNameMethodShouldFindUserByItsId()
        {
            Person expectedResult = new Person(0003, "Agent003");

            this.exdb.Add(new Person(0001, "Agent001"));
            this.exdb.Add(new Person(0002, "Agent002"));
            this.exdb.Add(expectedResult);
            this.exdb.Add(new Person(0004, "Agent004"));

            Person actualResult = this.exdb.FindById(expectedResult.Id);
            Assert.That(expectedResult, Is.EqualTo(actualResult));
        }
    }
}