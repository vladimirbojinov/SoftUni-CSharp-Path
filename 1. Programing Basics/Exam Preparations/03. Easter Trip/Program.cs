namespace _03._Easter_Trip
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string destination = Console.ReadLine();
            string dates = Console.ReadLine();
            int nights = int.Parse(Console.ReadLine());

            int nightCost = 0;

            switch (destination)
            {
                case "France":
                    switch (dates)
                    {
                        case "21-23": nightCost = 30; break;
                        case "24-27": nightCost = 35; break;
                        case "28-31": nightCost = 40; break;
                    }
                    break;
                case "Italy":
                    switch (dates)
                    {
                        case "21-23": nightCost = 28; break;
                        case "24-27": nightCost = 32; break;
                        case "28-31": nightCost = 39; break;
                    }
                    break;
                case "Germany":
                    switch (dates)
                    {
                        case "21-23": nightCost = 32; break;
                        case "24-27": nightCost = 37; break;
                        case "28-31": nightCost = 43; break;
                    }
                    break;
            }

            Console.WriteLine($"Easter trip to {destination} : {nightCost * nights:f2} leva.");
        }
    }
}