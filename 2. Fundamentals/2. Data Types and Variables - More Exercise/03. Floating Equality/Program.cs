﻿namespace _03._Floating_Equality
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal n1 = decimal.Parse(Console.ReadLine());
            decimal n2 = decimal.Parse(Console.ReadLine());
            decimal tolerance = 0.000001m;


            bool isEquel = Math.Abs(n1 - n2) < tolerance;

            if (isEquel)
            {
                Console.WriteLine(true);
            }
            else
            {
                Console.WriteLine(false);
            }
        }
    }
}