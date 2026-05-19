using System.Numerics;
using System.Threading;

namespace CustomDoublyLinkedList;

public class MyLinkedList<T>
{
	private class Node
	{
		public Node(T value)
		{
			Value = value;
		}

		public T Value { get; set; }
		public Node NextNode { get; set; }
		public Node PreviousNode { get; set; }
	}
	private Node head;
	private Node tail;

	public int Count { get; private set; }

	public void AddFirst(T element)
	{
		if (Count == 0)
		{
			head = tail = new Node(element);
		}
		else
		{
			Node newHead = new Node(element);
			newHead.NextNode = head;
			head.PreviousNode = newHead;
			head = newHead;
		}

		Count++;
	}

	public void AddLast(T element)
	{
		if (Count == 0)
		{
			head = tail = new Node(element);
		}
		else
		{
			Node newTail = new Node(element);
			newTail.PreviousNode = tail;
			tail.NextNode = newTail;
			tail = newTail;
		}

		Count++;
	}

	public T RemoveFirst()
	{
		if (Count == 0)
		{
			throw new InvalidOperationException("List is empty!");
		}

		T firstElement = head.Value;
		head = head.NextNode;

		if (head != null)
		{
			head.PreviousNode = null;
		}
		else
		{
			tail = null;
		}

		Count--;
		return firstElement;
	}

	public T RemoveLast()
	{
		if (Count == 0)
		{
			throw new InvalidOperationException("List is empty!");
		}

		T lastElement = tail.Value;
		tail = tail.PreviousNode;

		if (tail != null)
		{
			tail.NextNode = null;
		}
		else
		{
			head = null;
		}

		Count--;
		return lastElement;
	}

	public void ForEach(Action<T> action)
	{
		Node currentNode = head;
		while (currentNode != null)
		{
			action(currentNode.Value);
			currentNode = currentNode.NextNode;
		}
	}

	public T[] ToArray()
	{
		T[] array = new T[Count];
		int counter = 0;
		Node currentNode = head;

		while (currentNode != null)
		{
			array[counter++] = currentNode.Value;
			currentNode = currentNode.NextNode;
		}

		return array;
	}

	public T2 Sum<T2>(Func<T, T2> selector) where T2 : INumber<T2>
	{
		T2 sum = T2.Zero;
		Node currentNode = head;

		while (currentNode != null)
		{
			sum += selector(currentNode.Value);
			currentNode = currentNode.NextNode;
		}

		return sum;
	}

	public T2 Max<T2>(Func<T, T2> selector) where T2 : INumber<T2>, IMinMaxValue<T2>
	{
		T2 max = T2.MinValue;
		Node currentNode = head;

		while (currentNode != null)
		{
			if (max < selector(currentNode.Value))
			{
				max = selector(currentNode.Value);
			}

			currentNode = currentNode.NextNode;
		}

		return max;
	}

	public T2 Min<T2>(Func<T, T2> selector) where T2 : INumber<T2>, IMinMaxValue<T2>
	{
		T2 min = T2.MaxValue;
		Node currentNode = head;

		while (currentNode != null)
		{
			if (min > selector(currentNode.Value))
			{
				min = selector(currentNode.Value);
			}

			currentNode = currentNode.NextNode;
		}

		return min;
	}

	public T2 Average<T2>(Func<T, T2> selector) where T2 : INumber<T2>
	{
		T2 average = T2.Zero;
		T2 sum = Sum(selector);
		T2 count = T2.Zero;

		for (int i = 0; i < Count; i++) count++;

		average = sum / count;
		return average;
	}
}