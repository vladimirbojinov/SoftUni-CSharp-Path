namespace _03._Sum_Prime_Non_Prime
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int primeSum = 0;
            int nonPrimeSum = 0;

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "stop")
                {
                    break;
                }

                int num = int.Parse(command);

                if (num < 0)
                {
                    Console.WriteLine("Number is negative.");
                    continue;
                }

                bool prime = true;

                for (int i = 2; i <= Math.Sqrt(num); i++)
                {
                    if (num % i == 0)
                    {
                        prime = false;
                        break;
                    }
                }

                if (prime)
                {
                    nonPrimeSum += num;
                }
                else
                {
                    primeSum += num;
                }
            }

            Console.WriteLine($"Sum of all prime numbers is: {nonPrimeSum}");
            Console.WriteLine($"Sum of all non prime numbers is: {primeSum}");
        }
    }
}