using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Library : IEnumerable<Book>
{
    private SortedSet<Book> books;
    private BookComparator comparator;

    public Library(params Book[] books)
    {
        this.comparator = new BookComparator();
        this.books = new SortedSet<Book>(books, comparator);
    }

    public IReadOnlyCollection<Book> Books
    {
        get
        {
            return (IReadOnlyCollection<Book>)this.books;
        }
    }

    public IEnumerator<Book> GetEnumerator()
    {
        return new LibraryIterator(this.books);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    private class LibraryIterator : IEnumerator<Book>
    {
        private SortedSet<Book> books;
        private int currentIndex;

        public LibraryIterator(SortedSet<Book> books)
        {
            this.books = books;
            this.currentIndex = -1;
        }

        public Book Current => this.books.ToList()[currentIndex];

        object IEnumerator.Current => this.Current;

        public void Dispose()
        { }

        public bool MoveNext()
        {
            this.currentIndex++;

            return this.currentIndex < this.books.Count;
        }

        public void Reset()
        { }
    }
}
