﻿namespace _09._Sum_of_Odd_Numbers
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int oddNumCount = int.Parse(Console.ReadLine());
			int sum = 0;

			for (int i = 1; i <= oddNumCount; i++)
			{
				Console.WriteLine((i * 2) - 1);
				sum += (i * 2) - 1;
			}

			Console.WriteLine($"Sum: {sum}");
		}
	}
}