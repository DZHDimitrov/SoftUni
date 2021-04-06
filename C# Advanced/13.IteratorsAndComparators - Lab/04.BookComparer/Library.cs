using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        public Library(params Book[] books)
        {
            book = new SortedSet<Book>(books, new BookComparator());
        }

        public SortedSet<Book> book { get; set; }

        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryIterator(book.ToList());
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class LibraryIterator : IEnumerator<Book>
        {
            private int index = -1;
            public List<Book> Book { get; set; }

            public LibraryIterator(List<Book> books)
            {
                Book = books;
            }
            public Book Current => Book[index];

            object IEnumerator.Current => Current;

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                return ++index < Book.Count;
            }

            public void Reset()
            {
                index = -1;
            }
        }


    }
}
