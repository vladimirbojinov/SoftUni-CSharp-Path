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
                    int input = row[i];

                    if (input % 2 == 0)
                    {
                        evenSum += input;
                    }
                    else
                    {
                        oddSum += input;
                    }
                }

                Console.WriteLine(evenSum - oddSum);
            }
        }
    }
}