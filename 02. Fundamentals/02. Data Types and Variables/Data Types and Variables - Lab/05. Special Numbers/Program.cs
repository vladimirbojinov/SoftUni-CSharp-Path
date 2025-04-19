namespace _05._Special_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int loops = int.Parse(Console.ReadLine());

            for (int i = 1; i <= loops; i++)
            {
                int sumOfDigits = 0;
                int num = i;

                while (num > 0)
                {
                    sumOfDigits += num % 10;
                    num /= 10;
                }

                bool isSpecial = sumOfDigits == 5 || sumOfDigits == 7 || sumOfDigits == 11;
                Console.WriteLine($"{i} -> {isSpecial}");
            }
        }
    }
}