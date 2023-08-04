namespace _07.Working_Hours
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int workingHours = int.Parse(Console.ReadLine());
            string dayOfTheWeek = Console.ReadLine();

            if (workingHours < 10 || workingHours > 18)
            {
                Console.WriteLine("closed");
            }
            else
            {
                switch (dayOfTheWeek)
                {
                    case "Monday":
                    case "Tuesday":
                    case "Wednesday":
                    case "Thursday":
                    case "Friday":
                    case "Saturday":
                        Console.WriteLine("open"); break;
                    default: Console.WriteLine("closed"); break;
                }
            }
        }
    }
}