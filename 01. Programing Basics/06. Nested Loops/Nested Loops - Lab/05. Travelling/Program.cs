namespace _05._Travelling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string destination = Console.ReadLine();

            while (destination != "End")
            {
                double price = double.Parse(Console.ReadLine());
                double savedMoney = 0;

                while (savedMoney < price)
                {
                    double payment = double.Parse(Console.ReadLine());
                    savedMoney += payment;
                }

                if (savedMoney >= price)
                {
                    Console.WriteLine($"Going to {destination}!");
                }

                destination = Console.ReadLine();
            }
        }
    }
}