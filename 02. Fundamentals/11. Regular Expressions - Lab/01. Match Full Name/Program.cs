﻿using System.Text.RegularExpressions;

namespace _01._Match_Full_Name
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\b([A-Z][a-z]+) ([A-Z][a-z]+)";
            string input = Console.ReadLine();
            
            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(input);
            foreach (Match match in matches)
            {
                Console.Write(match + " ");
            }
        }
    }
}