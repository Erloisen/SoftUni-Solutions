﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        public readonly SortedSet<Book> books;

        private class LibraryIterator : IEnumerator<Book>
        {
            private List<Book> books;

            private int index;

            public LibraryIterator(IEnumerable<Book> books)
            {
                this.Reset();
                this.books = new List<Book>(books);
                index = -1;
            }

            public Book Current => books[index];

            object IEnumerator.Current => this.Current;

            public bool MoveNext()
            {
                index++;
                return index < books.Count;
            }

            public void Reset()
            {
                this.index = -1;
            }

            public void Dispose() { }
        }

        public Library(params Book[] books)
        {
            this.books = new SortedSet<Book>(books, new BookComparator());
        }

        public void Add(Book book) 
        {
            books.Add(book);
        }

        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryIterator(this.books);
        }

        public void Remove(Book book)
        {
            books.Remove(book);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
