

using System.Collections;

namespace CustomStack;

internal class CustomStack<T> : IEnumerable<T>
{
	private T[] items;
	private const int InitialCapacity = 4;

	public CustomStack()
	{
		items = new T[InitialCapacity];
	}

	public int Count { get; private set; }

	public void Push(T value)
	{
		if (Count == InitialCapacity) Resize();

		items[Count++] = value;
	}

	public void Pop()
	{
		if (Count == 0) throw new InvalidOperationException("Stack is empty");
		if (Count <= items.Length / 4) Shrink();

		items[Count--] = default;
	}

	public T Peek()
	{
		if (Count == 0) throw new InvalidOperationException("Stack is empty");

		return items[Count - 1];
	}

	public bool Contains<T2>(T2 value) where T2 : IComparable<T2>
	{
		for (int i = 0; i < Count; i++)
		{
			if (items[i]!.Equals(value)) return true;
		}

		return false;
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

	public IEnumerator<T> GetEnumerator()
	{
		for (int i = Count - 1; i >= 0; i--)
		{
			yield return items[i];
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
		=> GetEnumerator();
}
