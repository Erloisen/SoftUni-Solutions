namespace Book.Tests
{
    using System;

    using NUnit.Framework;

    [TestFixture]
    public class Tests
    {
        [Test]
        [TestCase("", "Author")]
        [TestCase(null, "Author")]
        public void BookNameShouldThrowExceptionWhenNameIsNullOrEmpty(string name, string author)
        {
            Assert.Throws<ArgumentException>(() => new Book(name, author));
        }

        [Test]
        [TestCase("BookName", "")]
        [TestCase("BookName", null)]
        public void BookAuthorShouldThrowExceptionWhenAuthorIsNullOrEmpty(string name, string author)
        {
            Assert.Throws<ArgumentException>(() => new Book(name, author));
        }

        [Test]
        public void BookShouldWorkProperly()
        {
            string name = "Name";
            string author = "Author";
            Book book = new Book(name, author);
            Assert.AreEqual(book.BookName, name);
            Assert.AreEqual(book.Author, author);
        }

        [Test]
        public void BookShouldHaveFoodNoteWithCountMethod()
        {
            string name = "Name";
            string author = "Author";
            Book book = new Book(name, author);
            Assert.AreEqual(book.FootnoteCount, 0);
        }

        [Test]
        public void AddFootNoteMethodShouldThrowExceptionWhenNoteExcists()
        {
            string name = "Name";
            string author = "Author";
            Book book = new Book(name, author);
            int footNoteNumber = 1;
            string text = "FoodNote";
            book.AddFootnote(footNoteNumber, text);
            Assert.Throws<InvalidOperationException>(() => book.AddFootnote(footNoteNumber, text));
        }

        [Test]
        public void AddFootNoteMethodShouldWorkProperly()
        {
            string name = "Name";
            string author = "Author";
            Book book = new Book(name, author);
            int footNoteNumber = 1;
            string text = "FoodNote";
            book.AddFootnote(footNoteNumber, text);
            Assert.AreEqual($"Footnote #{footNoteNumber}: {text}", book.FindFootnote(footNoteNumber));
        }

        [Test]
        public void FindFootNoteMethodShouldThrowExceptionWhenFootnoteDoesnotExists()
        {
            string name = "Name";
            string author = "Author";
            int footNoteNumber = 1;
            Book book = new Book(name, author);
            Assert.Throws<InvalidOperationException>(() => book.FindFootnote(footNoteNumber));
        }

        [Test]
        public void AlterFootNoteMethodShouldThrowExceptionWhenFootnoteDoesnotExists()
        {
            string name = "Name";
            string author = "Author";
            Book book = new Book(name, author);
            int footNoteNumber = 1;
            string text = "FoodNote";
            Assert.Throws<InvalidOperationException>(() => book.AlterFootnote(footNoteNumber, text));
        }

        [Test]
        public void AlterFootNoteMethodShouldWorkProperly()
        {
            string name = "Name";
            string author = "Author";
            Book book = new Book(name, author);
            int footNoteNumber = 1;
            string text = "FoodNote";
            book.AddFootnote(footNoteNumber, text);
            book.AlterFootnote(footNoteNumber, "NewFoodNote");
            Assert.AreEqual($"Footnote #{footNoteNumber}: NewFoodNote", book.FindFootnote(footNoteNumber));
        }
    }
}