using NUnit.Framework;
using System;
using System.Linq;

namespace Test
{
    public class DatabaseTests
    {
        private Database db;
        [SetUp]
        public void Setup()
        {
            this.db = new Database();
        }

        [Test]
        public void ConstructorThrowsExceptionWhenDatabaseCapacityIsExceeded()
        {
            Assert.Throws<InvalidOperationException>(() => this.db = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17));
        }

        [Test]
        [TestCase(16)]
        public void ConstructorAddElementsToDatabase(int capasity)
        {
            int[] arr = new[] { 1, 2, 3 };
            this.db = new Database(arr);

            Assert.That(this.db.Count, Is.EqualTo(arr.Length));
            Assert.That(this.db.Fetch, Is.EquivalentTo(arr));
        }

        [Test]
        public void CountReturnsZeroWhenDatabaseIsEmpty()
        {
            Assert.That(db.Count, Is.EqualTo(0));
        }

        [Test]
        public void AddMethodThrowExceprionWhenCapasityIsExceeded()
        {
            for (int i = 0; i < 16; i++)
            {
                this.db.Add(i);
            }

            Assert.Throws<InvalidOperationException>(() => this.db.Add(17));
        }

        [Test]
        [TestCase(10)]
        [TestCase(16)]
        public void AddIncreasesDatabaseCountWhenAddIsValideOparation(int capasity)
        {
            for (int i = 0; i < capasity; i++)
            {
                this.db.Add(i);
            }

            Assert.That(this.db.Count, Is.EqualTo(capasity));
        }

        [Test]
        public void AddMethodAddsElementToDatabase()
        {
            int element = 123;
            this.db.Add(element);

            int[] elements = this.db.Fetch();
            Assert.IsTrue(elements.Contains(element));
        }

        [Test]
        public void RemoveMethodThowsExceptionWhenDatabaseIsEmpty()
        {
            Assert.Throws<InvalidOperationException>(() => db.Remove());
        }

        [Test]
        [TestCase(1, 0)]
        [TestCase(16, 15)]
        public void RemoveMethodRemoveElementsFromTheCollection(int capasty, int result)
        {
            for (int i = 0; i < capasty; i++)
            {
                this.db.Add(i);
            }

            db.Remove();
            Assert.That(this.db.Count, Is.EqualTo(result));
        }

        [Test]
        [TestCase(3)]
        public void RemoveMethodShouldRemoveCurrentElement(int currentElement)
        {
            this.db.Add(1);
            this.db.Add(2);
            this.db.Add(currentElement);

            db.Remove();

            int[] elements = this.db.Fetch();
            Assert.IsFalse(elements.Contains(currentElement));
        }

        [Test]
        public void FecthMethodReturnsDatabaseCopyInstedOfReference()
        {
            for (int i = 0; i < 10; i++)
            {
                db.Add(i);
            }

            int[] firstCopy = this.db.Fetch();

            this.db.Remove();
            this.db.Remove();

            int[] secondCopy = this.db.Fetch();

            Assert.That(firstCopy, Is.Not.EqualTo(secondCopy));
        }
    }
}