using System.Runtime.ExceptionServices;

namespace _03._Recursive_Fibonacci
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int num = int.Parse(Console.ReadLine());

			Console.WriteLine(Fibonacci(num));

			int Fibonacci(int num)
			{
				if (num == 0 || num == 1)
				{
					return num;
				}
				else
				{
					return Fibonacci(num - 1) + Fibonacci(num - 2);
				}
			}
		}
	}
}