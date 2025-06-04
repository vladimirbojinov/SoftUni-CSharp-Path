namespace _03._Substring
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string textToRemove = Console.ReadLine();
            string text = Console.ReadLine();
            while (text.Contains(textToRemove))
            {
                int textIndex = text.IndexOf(textToRemove);
                text = text.Remove(textIndex, textToRemove.Length);
            }

            Console.WriteLine(text);
        }
    }
}