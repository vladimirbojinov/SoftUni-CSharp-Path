namespace _07._Repeat_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            int loops = int.Parse(Console.ReadLine());

            StringRepeater(loops, text);
        }

        static void StringRepeater(int loops, string text)
        {
            for (int i = 0; i < loops; i++)
            {
                Console.Write(text);
            }
        }
    }
}