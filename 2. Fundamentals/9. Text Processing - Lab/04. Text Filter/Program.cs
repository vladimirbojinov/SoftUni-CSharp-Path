namespace _04._Text_Filter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] bannedWord = Console.ReadLine().Split(", ");
            string text = Console.ReadLine();

            foreach (string badWord in bannedWord)
            {
                text = text.Replace(badWord, new string('*', badWord.Length));
            }

            Console.WriteLine(text);
        }
    }
}