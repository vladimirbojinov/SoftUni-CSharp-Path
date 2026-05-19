using System.Collections;

namespace _02.Collection;

internal class ListyIterator<T> : IEnumerable<T>
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

	public void PrintAll()
	{
		if (list.Count == 0) throw new InvalidOperationException("Invalid Operation!");

		Console.WriteLine(string.Join(" ", list));
	}

	public IEnumerator<T> GetEnumerator()
	{
		for (int i = 0; i < list.Count; i++)
			yield return list[i];
	}

	IEnumerator IEnumerable.GetEnumerator()
		=> GetEnumerator();
}
