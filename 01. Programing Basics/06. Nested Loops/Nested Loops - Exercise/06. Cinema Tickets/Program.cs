namespace _06._Cinema_Tickets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int studentTickets = 0;
            int standardTickets = 0;
            int kidTickets = 0;
            int tickets = 0;

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "Finish")
                {
                    break;
                }


                int places = int.Parse(Console.ReadLine());
                string FilmName = command;
                int soldTickets = 0;

                for (int i = 0; i < places; i++)
                {
                    string seats = Console.ReadLine();
                    if (seats == "End")
                    {
                        break;
                    }
                    switch (seats)
                    {
                        case "student": studentTickets++; break;
                        case "standard": standardTickets++; break;
                        case "kid": kidTickets++; break;
                    }
                    soldTickets++;
                    tickets++;

                }
                Console.WriteLine($"{FilmName} - {(soldTickets * 1.0 / places) * 100:f2}% full.");
            }

            Console.WriteLine($"Total tickets: {tickets}");
            Console.WriteLine($"{(studentTickets * 1.0 / tickets) * 100:f2}% student tickets.");
            Console.WriteLine($"{(standardTickets * 1.0 / tickets) * 100:f2}% standard tickets.");
            Console.WriteLine($"{(kidTickets * 1.0 / tickets) * 100:f2}% kids tickets.");
        }
    }
}