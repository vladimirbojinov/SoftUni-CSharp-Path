using System.Collections;

namespace CustomList;

internal class CustomList<T> : IEnumerable<T>
{
	private T[] items;
	private const int InitialCapacity = 2;

	public CustomList()
	{
		items = new T[InitialCapacity];
	}

	public int Count { get; private set; }

	public T this[int index]
	{
		get
		{
			if (index >= Count)
			{
				throw new ArgumentOutOfRangeException();
			}

			return items[index];
		}
		set
		{
			if (index >= Count)
			{
				throw new ArgumentOutOfRangeException();
			}

			items[index] = value;
		}
	}

	public void Add(T value)
	{
		if (Count == items.Length) Resize();

		items[Count++] = value;
	}

	public void RemoveAt(int index)
	{
		IsIndexValid(index);
		ShiftLeft(index);

		Count--;
		if (Count <= items.Length / 4) Shrink();
	}

	public void InsertAt(int index, T value)
	{
		IsIndexValid(index);
		if (Count == items.Length) Resize();

		ShiftRight(index);
		items[index] = value;
		Count++;
	}

	public bool Contains<T2>(T2 value) where T2 : IComparable<T2>
	{
		for (int i = 0; i < Count; i++)
		{
			if (items[i]!.Equals(value)) return true;
		}

		return false;
	}

	public void Swap(int indexOne, int indexTwo)
	{
		IsIndexValid(indexOne);
		IsIndexValid(indexTwo);

		(items[indexOne], items[indexTwo]) = (items[indexTwo], items[indexOne]);
	}

	public void Reverse()
	{
		T[] reverseCopy = new T[items.Length];

		for (int i = 0; i < Count; i++)
		{
			reverseCopy[i] = items[Count - 1 - i];
		}

		items = reverseCopy;
	}

	private void IsIndexValid(int index)
	{
		if (index >= Count || index < 0) throw new ArgumentOutOfRangeException();
	}

	private void Resize()
	{
		T[] arrayCopy = new T[items.Length * 2];

		items.CopyTo(arrayCopy, 0);
		items = arrayCopy;
	}

	private void Shrink()
	{
		T[] arrayCopy = new T[items.Length / 2];

		items.CopyTo(arrayCopy, 0);
		items = arrayCopy;
	}

	private void ShiftLeft(int index)
	{
		for (int i = index; i < Count - 1; i++)
		{
			items[i] = items[i + 1];
		}
	}

	private void ShiftRight(int index)
	{
		for (int i = Count; i > index - 1; i--)
		{
			items[i] = items[i - 1];
		}
	}

	public IEnumerator<T> GetEnumerator()
	{
		for (int i = 0; i < Count; i++)
		{
			yield return items[i];
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
		=> GetEnumerator();
}
