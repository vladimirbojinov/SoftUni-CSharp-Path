﻿namespace _05._Special_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            for (int i = 1; i <= num; i++)
            {
                int sumOfDigits = 0;
                int digits = i;

                while (digits > 0)
                {
                    sumOfDigits += digits % 10;
                    digits /= 10;
                }

                bool isSpecial = sumOfDigits == 5 || sumOfDigits == 7 || sumOfDigits == 11;

                Console.WriteLine($"{i} -> {isSpecial}");
            }

        }
    }
}