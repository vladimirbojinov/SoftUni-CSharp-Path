namespace _02._Odd_Occurrences
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] text = Console.ReadLine()
                .Split()
                .Select(x => x.ToLower())
                .ToArray();

            Dictionary<string, int> existingNumbers = new Dictionary<string, int>();
            for (int i = 0; i < text.Length; i++)
            {
                if (!existingNumbers.ContainsKey(text[i]))
                {
                    existingNumbers.Add(text[i], 1);
                }
                else
                {
                    existingNumbers[text[i]]++;
                }
            }

            foreach (var kvp in existingNumbers)
            {
                if (kvp.Value % 2 == 1)
                {
                    Console.Write(kvp.Key + " ");
                }
            }
        }
    }
}