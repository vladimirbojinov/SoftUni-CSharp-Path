namespace _03._Substring
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string removedWord = Console.ReadLine();
            string text = Console.ReadLine();
            while (text.Contains(removedWord))
            {
                int startIndex = text.IndexOf(removedWord);
                text = text.Remove(startIndex, removedWord.Length);
            }

            Console.WriteLine(text);
        }
    }
}