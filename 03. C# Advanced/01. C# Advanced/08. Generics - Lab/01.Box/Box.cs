namespace BoxOfT;

public class Box<T>
{
	public Box()
	{
		List = new List<T>();
	}

	public List<T> List { get; set; }

	public int Count => List.Count;

	public void Add(T item)
	{
		List.Add(item);
	}

	public T Remove()
	{
		T lastValue = List.Last();
		List.RemoveAt(List.Count - 1);
		return lastValue;
	}

}
