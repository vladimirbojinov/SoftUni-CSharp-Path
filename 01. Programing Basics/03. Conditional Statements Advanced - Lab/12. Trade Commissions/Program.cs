namespace _12._Trade_Commissions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string city = Console.ReadLine();
            double salles = double.Parse(Console.ReadLine());

            double comission = 0;

            switch (city)
            {
                case "Sofia":
                    if (salles >= 0 && salles <= 500)
                    {
                        comission = salles * 0.05;
                    }
                    else if (salles > 500 && salles <= 1000)
                    {
                        comission = salles * 0.07;
                    }
                    else if (salles > 1000 && salles <= 10000)
                    {
                        comission = salles * 0.08;
                    }
                    else if (salles > 10000)
                    {
                        comission = salles * 0.12;
                    }
                    break;
                case "Varna":
                    if (salles >= 0 && salles <= 500)
                    {
                        comission = salles * 0.045;
                    }
                    else if (salles > 500 && salles <= 1000)
                    {
                        comission = salles * 0.075;
                    }
                    else if (salles > 1000 && salles <= 10000)
                    {
                        comission = salles * 0.10;
                    }
                    else if (salles > 10000)
                    {
                        comission = salles * 0.13;
                    }
                    break;
                case "Plovdiv":
                    if (salles >= 0 && salles <= 500)
                    {
                        comission = salles * 0.055;
                    }
                    else if (salles > 500 && salles <= 1000)
                    {
                        comission = salles * 0.08;
                    }
                    else if (salles > 1000 && salles <= 10000)
                    {
                        comission = salles * 0.12;
                    }
                    else if (salles > 10000)
                    {
                        comission = salles * 0.145;
                    }
                    break;
            }

            if (salles < 0 || (city != "Sofia" && city != "Varna" && city != "Plovdiv"))
            {
                Console.WriteLine("error");
            }
            else
            {
                Console.WriteLine($"{comission:f2}");
            }
        }
    }
}