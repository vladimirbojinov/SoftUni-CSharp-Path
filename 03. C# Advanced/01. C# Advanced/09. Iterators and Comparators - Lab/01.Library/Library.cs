using System.Collections;

namespace IteratorsAndComparators
{
	public class Library
	{
		private List<Book> books;

		public Library(params Book[] arrayBooks)
		{
			books = new List<Book>(arrayBooks);
		}
	}
}
