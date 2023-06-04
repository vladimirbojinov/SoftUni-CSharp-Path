namespace _02._Vowels_Count
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int vowelCount = 0;

            vowelCount = VowelFinder();
            Console.WriteLine(vowelCount);
        }

        static int VowelFinder()
        {
            int count = 0;
            string word = Console.ReadLine();
            word = word.ToLower();

            for (int i = 0; i < word.Length; i++)
            {
                string singleLetter = word[i].ToString();

                switch (singleLetter)
                {
                    case "a": count++; break;
                    case "e": count++; break;
                    case "i": count++; break;
                    case "o": count++; break;
                    case "u": count++; break;
                }
            }

            return count;
        }
    }
}