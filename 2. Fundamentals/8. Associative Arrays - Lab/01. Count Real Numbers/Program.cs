namespace _01._Count_Real_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var existingNumbers = new SortedDictionary<int, int>();
            for (int i = 0; i < numbers.Length; i++)
            {
                if (!existingNumbers.ContainsKey(numbers[i]))
                {
                    existingNumbers.Add(numbers[i], 1);
                }
                else
                {
                    existingNumbers[numbers[i]]++;
                }
            }

            foreach (var number in existingNumbers)
            {
                Console.WriteLine($"{number.Key} -> {number.Value}");
            }
        }
    }
}