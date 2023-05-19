namespace _06._Triples_of_Latin_Letters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int letterCount = int.Parse(Console.ReadLine());

            for (int i = 97; i < 97 + letterCount; i++)
            {
                for (int j = 97; j < 97 + letterCount; j++)
                {
                    for (int k = 97; k < 97 + letterCount; k++)
                    {
                        Console.WriteLine($"{(char)i}{(char)j}{(char)k}");
                    }
                }
            }
        }
    }
}