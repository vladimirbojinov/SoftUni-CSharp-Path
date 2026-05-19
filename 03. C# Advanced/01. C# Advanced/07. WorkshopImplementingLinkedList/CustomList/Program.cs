namespace CustomDoublyLinkedList;

public class StartUp
{
	static void Main(string[] args)
	{
		MyLinkedList<double> list = new MyLinkedList<double>();

		list.AddFirst(3.5);
		list.AddFirst(2.2);
		list.AddFirst(10.5);
		list.RemoveFirst();

		double sum = list.Sum(x => x);
		double min = list.Min(x => x);
		double max = list.Max(x => x);
		double average = list.Average(x => x);

		Console.WriteLine(sum);
		Console.WriteLine(min);
		Console.WriteLine(max);
		Console.WriteLine(average);
    }
}
