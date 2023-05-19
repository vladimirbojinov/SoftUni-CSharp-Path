namespace _12._Refactor_Special_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for (int i = 1; i <= number; i++)
            {
                int sumOfDigits = 0;
                int digits = i;
                bool isSpecial = false;

                while (digits > 0)
                {
                    sumOfDigits += i % 10;
                    digits = digits / 10;
                }

                isSpecial = (sumOfDigits == 5) || (sumOfDigits == 7) || (sumOfDigits == 11);
                Console.WriteLine($"{i} -> {isSpecial}");
            }
        }
    }
}