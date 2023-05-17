using System;
namespace _09._Ski_Trip
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine()) - 1;
            string room = Console.ReadLine();
            string review = Console.ReadLine();

            double totalSum = 0;

            switch (room)
            {
                case "room for one person": totalSum = 18.0;
                    totalSum *= 1;
                    break;
                case "apartment": totalSum = 25.0;
                    if (days < 10)
                    {
                        totalSum *= 0.7;
                    }
                    else if (days <= 15)
                    {
                        totalSum *= 0.65;
                    }
                    else if (days > 15)
                    {
                        totalSum *= 0.5;
                    }
                    break;
                case "president apartment": totalSum = 35.0;
                    if (days < 10)
                    {
                        totalSum *= 0.9;
                    }
                    else if (days <= 15)
                    {
                        totalSum *= 0.85;
                    }
                    else if (days > 15)
                    {
                        totalSum *= 0.8;
                    }
                    break;
            }
            
            if (review == "positive")
            {
                totalSum *= 1.25;
            }
            else
            {
                totalSum *= 0.9;
            }

            double finalPrice = totalSum * days;

            Console.WriteLine($"{finalPrice:f2}");
        }
    }
}