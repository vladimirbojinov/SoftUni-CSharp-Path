namespace IteratorsAndComparators;

public class BookComparator : IComparer<Book>
{
	public int Compare(Book? x, Book? y)
	{
		if (x == null || y == null) return -1;

		int result = Comparer<int>.Default.Compare(y.Year, x.Year);
		if (result == 0) result = Comparer<string>.Default.Compare(x.Title, y.Title);

		return result;
	}
}
