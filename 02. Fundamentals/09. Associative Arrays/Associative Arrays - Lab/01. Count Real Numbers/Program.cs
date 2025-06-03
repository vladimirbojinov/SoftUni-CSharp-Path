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

			SortedDictionary<int, int> numbersEncounter = new SortedDictionary<int, int>();
            for (int i = 0; i < numbers.Length; i++)
            {
                if (!numbersEncounter.ContainsKey(numbers[i]))
                {
                    numbersEncounter.Add(numbers[i], 0);
                }

                numbersEncounter[numbers[i]]++;
            }

            foreach (var number in numbersEncounter)
            {
                Console.WriteLine($"{number.Key} -> {number.Value}");
            }
        }
    }
}