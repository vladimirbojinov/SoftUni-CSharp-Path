namespace _12._Refactor_Special_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfLoops = int.Parse(Console.ReadLine());

            for (int i = 1; i <= numberOfLoops; i++)
            {
                int num = i;
                int sumOfNumber = 0;
                while (num > 0)
                {
                    sumOfNumber += num % 10;
                    num /= 10;
                }

                bool isSpecialNum = sumOfNumber == 5 || sumOfNumber == 7 || sumOfNumber == 11;
                Console.WriteLine($"{i} -> {isSpecialNum}");
            }
        }
    }
}