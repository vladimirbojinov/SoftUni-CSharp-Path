namespace _04.Generi_SwapMethodInteger;

internal class Box<T> where T : IComparable<T>
{
	public Box(T value)
	{
		Value = value;
	}

	public T Value { get; set; }

	public static void GreaterThanCount(List<Box<T>> boxList, T compareValue)
	{
		int count = 0;

		foreach (Box<T> box in boxList)
		{
			int comparison = box.Value.CompareTo(compareValue);

			if (comparison == 1) count++;
		}

        Console.WriteLine(count);
    }

	public override string ToString()
	{
		return $"{typeof(T).FullName}: {Value}";
	}
}
