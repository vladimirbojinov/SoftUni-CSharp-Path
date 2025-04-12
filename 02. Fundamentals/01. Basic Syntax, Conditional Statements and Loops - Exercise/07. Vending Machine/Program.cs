namespace _07._Vending_Machine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            double totalMoney = 0;

            while (command != "Start")
            {
                double coin = double.Parse(command);

                switch (coin)
                {
                    case 1.00:
                    case 2.00:
                    case 0.50:
                    case 0.20:
                    case 0.10:
                        totalMoney += coin;
                        break;
                    default: Console.WriteLine($"Cannot accept {coin}"); break;
                }

                command = Console.ReadLine();
            }
            
			command = Console.ReadLine();
            while (command != "End")
            {
				string product = command.ToLower();
                double productCost = 0;

                switch (product)
                {
                    case "nuts": productCost = 2.00; break;
                    case "water": productCost = 0.70; break;
                    case "crisps": productCost = 1.50; break;
                    case "soda": productCost = 0.80; break;
                    case "coke": productCost = 1.00; break;
                }

                if (productCost != 0)
                {
					if (totalMoney - productCost >= 0)
					{
						totalMoney -= productCost;
						Console.WriteLine($"Purchased {product}");
					}
					else
					{
						Console.WriteLine("Sorry, not enough money");
					}
				}
                else
                {
				    Console.WriteLine("Invalid product");	
                }

				command = Console.ReadLine();
			}

            Console.WriteLine($"Change: {totalMoney:F2}");
        }
    }
}