﻿namespace _02._Print_Numbers_in_Reverse_Order
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int loops = int.Parse(Console.ReadLine());
            int[] array = new int[loops];

            for (int i = 0; i < loops; i++)
            {
                int num = int.Parse(Console.ReadLine());
                array[i] = num;
            }

            for (int i = loops - 1; i >= 0; i--)
            {
                Console.Write(array[i] + " ");
            }
        }
    }
}