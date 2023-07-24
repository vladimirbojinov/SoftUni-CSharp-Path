namespace _08._Magic_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int magicNumber = int.Parse(Console.ReadLine());

            bool foundMagicNumber = false;

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    int currentSum = numbers[i] + numbers[j];

                    if (currentSum == magicNumber)
                    {
                        Console.WriteLine(numbers[i] + " " + numbers[j]);
                        foundMagicNumber = true;
                    }
                }
            }
        }
    }
}