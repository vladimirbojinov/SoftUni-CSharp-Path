namespace _09._Sum_of_Odd_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfOddNum = int.Parse(Console.ReadLine());
            int currentValue = 1;
            int sum = 0;

            for (int i = 0; i < countOfOddNum; i++)
            {
                if (currentValue % 2 != 0)
                {
                    Console.WriteLine(currentValue);
                    sum += currentValue;
                }
                else
                {
                    i--;
                }

                currentValue++;
            }

            Console.WriteLine($"Sum: {sum}");
        }
    }
}