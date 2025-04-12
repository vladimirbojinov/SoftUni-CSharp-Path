namespace _02._Ascii_Sumator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char startingSymbol = char.Parse(Console.ReadLine());
            char endSymbol = char.Parse(Console.ReadLine());
            string text = Console.ReadLine();

            int sum = 0;

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] > startingSymbol && text[i] < endSymbol)
                {
                    sum += text[i];
                }
            }

            Console.WriteLine(sum);
        }
    }
}