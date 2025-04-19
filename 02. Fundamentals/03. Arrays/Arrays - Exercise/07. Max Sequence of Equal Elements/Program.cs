namespace _07._Max_Sequence_of_Equal_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split()
                .Select(int.Parse)
                .ToArray();
            int bestSequence = -1;
            int currentSequence = 0;
            int bestNum = 0;

            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] == array[i + 1])
                {
                    currentSequence++;
                }
                else
                {
                    currentSequence = 0;
                }

                if (currentSequence > bestSequence)
                {
                    bestSequence = currentSequence;
                    bestNum = array[i];
                }
            }

            for (int i = 0; i < bestSequence + 1; i++)
            {
                Console.Write(bestNum + " ");
            }
        }
    }
}