using System;

namespace _09._Palindrome_Integers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            while (command != "END")
            {
                Console.WriteLine(IsNumberPalindrome(command));
                command = Console.ReadLine();
            }
        }

        static bool IsNumberPalindrome(string number)
        {
            string[] numberArray = new string[number.Length];
            for (int i = 0; i < number.Length; i++)
            {
                string singleDigit = number[i].ToString();
                numberArray[i] = singleDigit;
            }

            string firstHalf = "";
            for (int i = 0; i <= number.Length / 2; i++)
            {
                firstHalf += numberArray[i];
            }

            Array.Reverse(numberArray);

            string secHalf = "";
            for (int i = 0; i <= number.Length / 2; i++)
            {
                secHalf += numberArray[i];
            }

            return firstHalf == secHalf;
        }
    }
}