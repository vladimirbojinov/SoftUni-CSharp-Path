﻿using System.ComponentModel;

namespace _03._Calculations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());

            switch (command)
            {
                case "add": Add(num1, num2); break;
                case "subtract": Subtract(num1, num2); break;
                case "multiply": Multiply(num1, num2); break;
                case "divide": Divide(num1, num2); break;
            }
        }

        static void Add(int num1, int num2)
        {
            Console.WriteLine(num1 + num2);
        }

        static void Subtract(int num1, int num2)
        {
            Console.WriteLine(num1 - num2);
        }

        static void Multiply(int num1, int num2)
        {
            Console.WriteLine(num1 * num2);
        }
        static void Divide(int num1, int num2)
        {
            Console.WriteLine(num1 / num2);
        }
    }
}