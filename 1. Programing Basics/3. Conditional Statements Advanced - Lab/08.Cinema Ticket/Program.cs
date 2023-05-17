namespace _08.Cinema_Ticket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string dayOfTheWeek = Console.ReadLine();
            int ticketPrice = 0;

            if (dayOfTheWeek == "Monday" || dayOfTheWeek == "Tuesday" || dayOfTheWeek == "Friday")
            {
                ticketPrice = 12;
            }
            else if (dayOfTheWeek == "Wednesday" || dayOfTheWeek == "Thursday")
            {
                ticketPrice = 14;
            }
            else if (dayOfTheWeek == "Saturday" || dayOfTheWeek == "Sunday")
            {
                ticketPrice = 16;
            }

            Console.WriteLine(ticketPrice);
        }
    }
}