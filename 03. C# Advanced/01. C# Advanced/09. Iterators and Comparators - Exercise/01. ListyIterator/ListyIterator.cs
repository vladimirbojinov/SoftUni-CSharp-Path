namespace _01.ListyIterator;

internal class ListyIterator<T>
{
	public ListyIterator(IEnumerable<T> values)
	{
		list = new List<T>(values);
	}

	private readonly List<T> list;
	private int index;

	public bool Move()
	{
		if (HasNext())
		{
			index++;
			return true;
		}

		return false;
	}

	public bool HasNext()
		=> index + 1 < list.Count;

	public void Print()
	{	
		if (list.Count == 0) throw new InvalidOperationException("Invalid Operation!");

		Console.WriteLine(list[index]);		
	}
}
