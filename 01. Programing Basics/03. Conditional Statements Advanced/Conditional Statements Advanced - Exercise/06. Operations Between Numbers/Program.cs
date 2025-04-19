using System;
namespace _06._Operations_Between_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n1 = int.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());
            string op = Console.ReadLine();

            double result;

            if (op == "+")
            {
                result = n1 + n2;

                if (result % 2 == 0)
                {
                    Console.WriteLine($"{n1} + {n2} = {n1 + n2} - even");
                }
                else
                {
                    Console.WriteLine($"{n1} + {n2} = {n1 + n2} - odd");
                }
            }
            else if (op == "-")
            {
                result = n1 - n2;

                if (result % 2 == 0)
                {
                    Console.WriteLine($"{n1} - {n2} = {n1 - n2} - even");
                }
                else
                {
                    Console.WriteLine($"{n1} - {n2} = {n1 - n2} - odd");
                }
            }
            else if (op == "*")
            {
                result = n1 * n2;

                if (result % 2 == 0)
                {
                    Console.WriteLine($"{n1} * {n2} = {n1 * n2} - even");
                }
                else
                {
                    Console.WriteLine($"{n1} * {n2} = {n1 * n2} - odd");
                }
            }
            else if (op == "/")
            {

                if (n2 == 0)
                {
                    Console.WriteLine($"Cannot divide {n1} by zero");
                }
                else
                {
                    double result1 = n1 / (n2 * 1.0);

                    Console.WriteLine($"{n1} / {n2} = {result1:f2}");
                }
            }
            else if (op == "%")
            {
                if (n2 == 0)
                {
                    Console.WriteLine($"Cannot divide {n1} by zero");
                }
                else
                {
                    double result1 = n1 % (n2 * 1.0);
                    Console.WriteLine($"{n1} % {n2} = {result1}");
                }

            }
        }
    }
}