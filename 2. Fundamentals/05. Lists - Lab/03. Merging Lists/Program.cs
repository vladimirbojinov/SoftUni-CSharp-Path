using System;

namespace _03._Merging_Lists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> number1 = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            List<int> number2 = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList(); ;

            List<int> result = new List<int>();

            int maxLenght = Math.Max(number1.Count, number2.Count);

            for (int i = 0; i < maxLenght; i++)
            {
                if (i < number1.Count)
                {
                    result.Add(number1[i]);
                }
                if (i < number2.Count)
                {
                    result.Add(number2[i]);
                }
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}