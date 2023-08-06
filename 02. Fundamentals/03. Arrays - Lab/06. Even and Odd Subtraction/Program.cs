namespace _06._Even_and_Odd_Subtraction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            {
                int[] row = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                int evenSum = 0;
                int oddSum = 0;

                for (int i = 0; i < row.Length; i++)
                {
                    int temp = row[i];

                    if (temp % 2 == 0)
                    {
                        evenSum += temp;
                    }
                    else
                    {
                        oddSum += temp;
                    }
                }

                Console.WriteLine(evenSum - oddSum);
            }
        }
    }
}