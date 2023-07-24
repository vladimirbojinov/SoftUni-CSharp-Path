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
                double money = double.Parse(command);

                if (money == 0.1 || money == 0.2 || money == 0.5 || money == 1 || money == 2)
                {
                    totalMoney += money;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {money}");
                }

                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command != "End")
            {
                string product = command.ToLower();

                switch (product)
                {
                    case "nuts":
                        if (totalMoney - 2.00 >= 0) 
                        {
                            totalMoney -= 2.00;
                            Console.WriteLine($"Purchased {product}");
                        }
                        else
                        {
                            Console.WriteLine("Sorry, not enough money");
                        }
                        ; break;
                    case "water":
                        if (totalMoney - 0.70 >= 0)
                        {
                            totalMoney -= 0.70;
                            Console.WriteLine($"Purchased {product}");
                        }
                        else
                        {
                            Console.WriteLine("Sorry, not enough money");
                        }
                        ; break;
                    case "crisps":
                        if (totalMoney - 1.50 >= 0)
                        {
                            totalMoney -= 1.50;
                            Console.WriteLine($"Purchased {product}");
                        }
                        else
                        {
                            Console.WriteLine("Sorry, not enough money");
                        }
                        ; break;
                    case "soda":
                        if (totalMoney - 0.80 >= 0)
                        {
                            totalMoney -= 0.80;
                            Console.WriteLine($"Purchased {product}");
                        }
                        else
                        {
                            Console.WriteLine("Sorry, not enough money");
                        }
                        ; break;
                    case "coke": 
                        if (totalMoney - 1.00 >= 0)
                        {
                            totalMoney -= 1.00;
                            Console.WriteLine($"Purchased {product}");
                        }
                        else
                        {
                            Console.WriteLine("Sorry, not enough money");
                        }
                        ;
                        break;
                    
                    default: Console.WriteLine("Invalid product");break;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"Change: {totalMoney:f2}");
        }
    }
}