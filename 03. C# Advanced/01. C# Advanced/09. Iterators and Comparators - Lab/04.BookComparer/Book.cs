namespace IteratorsAndComparators;

public class Book : IComparable<Book>
{
	public Book(string title, int year, params string[] arrayAuthors)
	{
		Title = title;
		Year = year;
		Authors = new List<string>(arrayAuthors);
	}

	public string Title { get; set; }
	public int Year { get; set; }
	public IReadOnlyList<string> Authors { get; set; }

	public int CompareTo(Book book)
	{
		if (book is null) return -1;

		int result = Comparer<int>.Default.Compare(book.Year, Year);
		if (result == 0) result = Comparer<string>.Default.Compare(Title, book.Title);

		return result;
	}

	public override string ToString()
	{
		return $"{Title} - {Year}";
	}
}
