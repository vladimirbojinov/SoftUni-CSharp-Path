using System.Numerics;

namespace _04.SumOfIntegers;

internal class Program
{
	static void Main(string[] args)
	{
		string[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
		BigInteger sum = 0;

		foreach (string element in numbers)
		{
			sum = ProcessElements(sum, element);
		}

		Console.WriteLine($"The total sum of all integers is: {sum}");
	}

	private static BigInteger ProcessElements(BigInteger sum, string element)
	{
		BigInteger temp = 0;

		try
		{
			if (!BigInteger.TryParse(element, out temp)) throw new FormatException();
			if (temp > int.MaxValue || temp < int.MinValue) throw new OverflowException();

			sum += temp;
		}
		catch (FormatException)
		{
			Console.WriteLine($"The element '{element}' is in wrong format!");
		}
		catch (OverflowException)
		{
			Console.WriteLine($"The element '{temp}' is out of range!");
		}
		finally
		{
			Console.WriteLine($"Element '{element}' processed - current sum: {sum}");
		}

		return sum;
	}
}
