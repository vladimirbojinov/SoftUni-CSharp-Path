namespace _06._Equal_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array1 = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int indexSatisfyer = -1;

            for (int i = 0; i < array1.Length; i++)
            {
                int leftRowSum = 0;
                int rightRowSum = 0;

                for (int j = 0; j < i; j++)
                {
                    leftRowSum += array1[j];
                }

                for (int k = array1.Length - 1; k > i; k--)
                {
                    rightRowSum += array1[k];
                }

                if (rightRowSum == leftRowSum)
                {
                    indexSatisfyer = i;
                    break;
                }
            }

            if (indexSatisfyer != -1)
            {
                Console.WriteLine(indexSatisfyer);
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}