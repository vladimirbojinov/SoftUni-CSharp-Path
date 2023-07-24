namespace _07._Repeat_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            int loop = int.Parse(Console.ReadLine());

            StringRepeater(loop, text);
        }

        static void StringRepeater(int n, string text)
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write(text);
            }
        }
    }
}