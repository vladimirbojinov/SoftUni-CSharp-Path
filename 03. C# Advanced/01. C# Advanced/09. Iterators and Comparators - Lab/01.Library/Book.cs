namespace IteratorsAndComparators;

public class Book
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
}
