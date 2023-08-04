namespace _07._Theatre_Promotion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string dayType = Console.ReadLine().ToLower();
            int age = int.Parse(Console.ReadLine());
            int ticketPrice = 0;

            switch (dayType)
            {
                case "weekday":
                    if (0 <= age && age <= 18)
                    {
                        ticketPrice = 12;
                    }
                    else if (18 < age && age <= 64)
                    {
                        ticketPrice = 18;
                    }
                    else if(64 < age && age <= 122)
                    {
                        ticketPrice = 12;
                    }
                    break;
                case "weekend":
                    if (0 <= age && age <= 18)
                    {
                        ticketPrice = 15;
                    }
                    else if (18 < age && age <= 64)
                    {
                        ticketPrice = 20;
                    }
                    else if (64 < age && age <= 122)
                    {
                        ticketPrice = 15;
                    }
                    break;
                case "holiday":
                    if (0 <= age && age <= 18)
                    {
                        ticketPrice = 5;
                    }
                    else if (18 < age && age <= 64)
                    {
                        ticketPrice = 12;
                    }
                    else if (64 < age && age <= 122)
                    {
                        ticketPrice = 10;
                    }
                    break;
            }

            if (ticketPrice > 0 && age >= 0)
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