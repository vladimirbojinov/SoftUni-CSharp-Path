using System;

namespace _09._Palindrome_Integers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            while (input != "END")
            {
                Console.WriteLine(IsNumberPalindrome(input));
                input = Console.ReadLine();
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

            string leftHalf = string.Empty;
            for (int i = 0; i <= number.Length / 2; i++)
            {
                leftHalf += numberArray[i];
            }

            Array.Reverse(numberArray);

            string rightHalf = string.Empty;
            for (int i = 0; i <= number.Length / 2; i++)
            {
                rightHalf += numberArray[i];
            }

            return leftHalf == rightHalf;
        }
    }
}