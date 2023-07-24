namespace _12._Refactor_Special_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numbers = int.Parse(Console.ReadLine());

            for (int i = 1; i <= numbers; i++)
            {
                int sum = 0;
                int finalSum = 0;
                int digit = i;

                finalSum = i;

                while (digit > 0)
                {
                    sum += i % 10;
                    digit = digit / 10;
                }

                bool isSpeccial = (sum == 5) || (sum == 7) || (sum == 11);
                Console.WriteLine("{0} -> {1}", finalSum, isSpeccial);
            }
        }
    }
}