namespace _06._Equal_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int indexSatisfier = -1;

            for (int i = 0; i < array.Length; i++)
            {
                int leftRowSum = 0;
                int rightRowSum = 0;

                for (int j = 0; j < i; j++)
                {
                    leftRowSum += array[j];
                }

                for (int j = array.Length - 1; j > i; j--)
                {
                    rightRowSum += array[j];
                }

                if (rightRowSum == leftRowSum)
                {
                    indexSatisfier = i;
                    break;
                }
            }

            if (indexSatisfier != -1)
            {
                Console.WriteLine(indexSatisfier);
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}