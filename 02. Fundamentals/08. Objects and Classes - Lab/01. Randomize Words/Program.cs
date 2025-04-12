namespace _01._Randomize_Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> text = Console.ReadLine()
                .Split()
                .ToList();

            Random rnd = new Random();
            int count = text.Count;
            for (int i = 0; i < count; i++)
            {
                int random = rnd.Next(text.Count);
                Console.WriteLine(text[random]);
                text.RemoveAt(random);
            }
        }
    }
}