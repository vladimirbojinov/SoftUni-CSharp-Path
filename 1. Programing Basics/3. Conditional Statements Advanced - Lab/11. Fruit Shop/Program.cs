namespace _11._Fruit_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            string dayOfTheWeek = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());

            double total = 0.0;

            switch (dayOfTheWeek) 
            {
                case "Monday":
                case "Tuesday":
                case "Wednesday":
                case "Thursday":
                case "Friday":
                    switch(product)
                    {
                        case "banana": total = quantity * 2.50; break;
                        case "apple": total = quantity * 1.20; break;
                        case "orange": total = quantity * 0.85; break;
                        case "grapefruit": total = quantity * 1.45; break;
                        case "kiwi": total = quantity * 2.70; break;
                        case "pineapple": total = quantity * 5.50; break;
                        case "grapes": total = quantity * 3.85; break;
                        default:
                            Console.WriteLine("error"); break;
                    }
                    break;

                case "Saturday":
                case "Sunday":
                    switch (product)
                    {
                        case "banana": total = quantity * 2.70; break;
                        case "apple": total = quantity * 1.25; break;
                        case "orange": total = quantity * 0.90; break;
                        case "grapefruit": total = quantity * 1.60; break;
                        case "kiwi": total = quantity * 3.00; break;
                        case "pineapple": total = quantity * 5.60; break;
                        case "grapes": total = quantity * 4.20; break;
                        default:
                            Console.WriteLine("error"); break;
                    }
                    break;
                default:
                    Console.WriteLine("error"); break;
            }

            if (total > 0)
            {
            Console.WriteLine($"{total:f2}");
            }
        }
    }
}