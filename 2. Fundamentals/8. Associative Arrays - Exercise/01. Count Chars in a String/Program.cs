namespace _01._Count_Chars_in_a_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<char, int> textDictionary = new Dictionary<char, int>();

            string input = Console.ReadLine();
            for (int i = 0; i < input.Length; i++)
            {
                char singleLetter = input[i];

                if (singleLetter == ' ')
                {
                    continue;
                }

                if (!textDictionary.ContainsKey(singleLetter))
                {
                    textDictionary.Add(singleLetter, 1);    
                }
                else
                {
                    textDictionary[singleLetter]++;
                }
            }

            foreach (var kvp in textDictionary)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}