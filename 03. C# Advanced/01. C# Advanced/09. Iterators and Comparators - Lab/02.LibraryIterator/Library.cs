using System.Collections;

namespace IteratorsAndComparators;

public class Library : IEnumerable<Book>
{
	private List<Book> books;

	public Library(params Book[] arrayBooks)
	{
		books = new List<Book>(arrayBooks);
	}

	public IEnumerator<Book> GetEnumerator()
	{
		return new LibraryIterator(books);
	}

	IEnumerator IEnumerable.GetEnumerator() 
		=> GetEnumerator();

	private class LibraryIterator : IEnumerator<Book>
	{
		private readonly List<Book> books;
		private int currentIndex;

		public LibraryIterator(List<Book> books)
		{
			Reset();
			this.books = new List<Book>(books);
		}

		public Book Current => books[currentIndex];

		object IEnumerator.Current => Current;

		public void Dispose() { }

		public bool MoveNext()
			=> ++currentIndex < books.Count;

		public void Reset() 
			=> currentIndex = -1;
	}
}
