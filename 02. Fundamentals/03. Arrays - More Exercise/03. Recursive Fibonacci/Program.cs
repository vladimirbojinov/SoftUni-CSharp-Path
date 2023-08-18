using System.Runtime.ExceptionServices;

namespace _03._Recursive_Fibonacci
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int n = int.Parse(Console.ReadLine());

			Console.WriteLine(Fibonacci(n));

			int Fibonacci(int n) 
			{
				if (n == 0 || n == 1) 
				{
					return n; 
				}
				else 
				{
					return Fibonacci(n - 1) + Fibonacci(n - 2); 
				}
			}
		}
	}
}