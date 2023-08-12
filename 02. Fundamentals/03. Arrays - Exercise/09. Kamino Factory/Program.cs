namespace _09._Kamino_Factory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int dnaLength = int.Parse(Console.ReadLine());

            int bestSum = 0;
            int bestIndexOfSequence = 101;
            int[] bestDna = new int[dnaLength];
            int bestDnaCount = 0;
            int bestSequence = 0;

            string command;
            int count = 0;
            while ((command = Console.ReadLine()) != "Clone them!")
            {
                count++;
                int[] dnaSequence = command
                    .Split("!")
                    .Select(int.Parse)
                    .ToArray();

                int dnaSum = 0;
                int indexOfSequence = 0;

                int bestCurrentSequence = 0;
                int currentSequence = 0;
                for (int i = 0; i < dnaSequence.Length; i++)
                {
                    dnaSum += dnaSequence[i];
                    if (dnaSequence[i] == 1)
                    {
                        currentSequence++;
                    }

                    if (dnaSequence[i] == 0 || i == dnaSequence.Length - 1)
                    {
                        if (currentSequence > bestSequence)
                        {
                            bestCurrentSequence = currentSequence;
                            indexOfSequence = i - currentSequence;
                        }
                        currentSequence = 0;
                    }
                }

                if (indexOfSequence < bestIndexOfSequence && bestCurrentSequence > bestSequence || (indexOfSequence == bestIndexOfSequence && dnaSum > bestSum))
                {
                    bestSum = dnaSum;
                    bestIndexOfSequence = indexOfSequence;
                    bestDna = dnaSequence;
                    bestSequence = bestCurrentSequence;
                    bestDnaCount = count;
                }
            }

            Console.WriteLine($"Best DNA sample {bestDnaCount} with sum: {bestSum}.");
            Console.WriteLine(string.Join(" ", bestDna));
        }
    }
}