﻿namespace _04._Sum_of_Chars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int loops = int.Parse(Console.ReadLine());
            int sum = 0;

            for (int i = 0; i < loops; i++)
            {
                char symbol = char.Parse(Console.ReadLine());
                sum += symbol;
            }

            Console.WriteLine($"The sum equals: {sum}");
        }
    }
}