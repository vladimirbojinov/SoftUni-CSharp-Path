﻿namespace _06._Student_Academy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> studentDictionary = new Dictionary<string, List<double>>();

            int studentGrade = int.Parse(Console.ReadLine());
            for (int i = 0; i < studentGrade; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (!studentDictionary.ContainsKey(name))
                {
                    studentDictionary.Add(name, new List<double>());
                }

                studentDictionary[name].Add(grade);
            }

            foreach (var student in studentDictionary)
            {
                double average = student.Value.Average();

                if (average >= 4.50)
                {
                    Console.WriteLine($"{student.Key} -> {average:F2}");
                }
            }
        }
    }
}