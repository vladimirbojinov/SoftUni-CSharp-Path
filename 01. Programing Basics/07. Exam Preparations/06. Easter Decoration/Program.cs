namespace _06._Easter_Decoration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int clients = int.Parse(Console.ReadLine());

            double avgTotal = 0;

            for (int i = 0; i < clients; i++)
            {
                double price = 0;
                int productCount = 0;

                while (true)
                {
                    string product = Console.ReadLine();
                    if (product == "Finish")
                    {
                        if (productCount % 2 == 0)
                        {
                            price *= 0.80;
                        }

                        Console.WriteLine($"You purchased {productCount} items for {price:f2} leva.");
                        avgTotal += price;
                        break;
                    }

                    switch (product)
                    {
                        case "basket": price += 1.50; productCount++; break;
                        case "wreath": price += 3.80; productCount++; break;
                        case "chocolate bunny": price += 7.00; productCount++; break;
                    }
                }

            }
            Console.WriteLine($"Average bill per client is: {avgTotal / clients:f2} leva.");
        }
    }
}