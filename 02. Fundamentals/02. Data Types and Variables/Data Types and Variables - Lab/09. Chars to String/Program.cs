namespace _09._Chars_to_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char symbol1 = char.Parse(Console.ReadLine());
            char symbol2 = char.Parse(Console.ReadLine());
            char symbol3 = char.Parse(Console.ReadLine());

            string text = $"{symbol1}{symbol2}{symbol3}";
			Console.WriteLine(text);
        }
    }
}