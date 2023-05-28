
namespace _07._Max_Sequence_of_Equal_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array1 = Console.ReadLine().Split()
                .Select(int.Parse)
                .ToArray();
            int counter = 0;
            int bestCounter = 0;
            int bestNum = 0;

            for (int i = 1; i < array1.Length; i++)
            {
                if (array1[i] == array1[i - 1])
                {
                    counter++;
                }
                else
                {
                    counter = 0;
                }

                if (counter > bestCounter)
                {
                    bestCounter = counter;
                    bestNum = array1[i];
                }
            }

            for (int i = 0; i < bestCounter + 1; i++)
            {
                Console.Write(bestNum + " ");
            }
        }
    }
}