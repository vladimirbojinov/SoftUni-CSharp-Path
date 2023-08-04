namespace _07._Theatre_Promotion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string dateType = Console.ReadLine().ToLower();
            int age = int.Parse(Console.ReadLine());
            int ticketPrice = 0;

            if (dateType == "weekday")
            {
                if (age >= 0 && age <= 18)
                {
                    ticketPrice = 12;
                }
                else if (age > 18 && age <= 64)
                {
                    ticketPrice = 18;
                }
                else
                {
                    ticketPrice = 12;
                }
            }
            else if (dateType == "weekend")
            {
                if (age >= 0 && age <= 18)
                {
                    ticketPrice = 15;
                }
                else if (age > 18 && age <= 64)
                {
                    ticketPrice = 20;
                }
                else
                {
                    ticketPrice = 15;
                }
            }
            else if (dateType == "holiday")
            {
                if (age >= 0 && age <= 18)
                {
                    ticketPrice = 5;
                }
                else if (age > 18 && age <= 64)
                {
                    ticketPrice = 12;
                }
                else
                {
                    ticketPrice = 10;
                }
            }

            if (ticketPrice != 0 && age >= 0)
            {
                Console.WriteLine(ticketPrice + "$");
            }
            else
            {
                Console.WriteLine("Error!");
            }
        }
    }
}