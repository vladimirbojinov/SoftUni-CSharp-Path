
namespace _02.RecursiveFactorial;

internal class Program
{
	static void Main(string[] args)
	{
		int n = int.Parse(Console.ReadLine());

		Console.WriteLine(RecursiveFactorial(n));
	}

	private static int RecursiveFactorial(int n)
	{
		if (n == 0) return 1;

		return n * RecursiveFactorial(n -  1);
	}
}
