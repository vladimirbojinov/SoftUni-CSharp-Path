namespace _04._Reverse_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string reversedString = string.Empty;

            for (int i = text.Length; i > 0; i--)
            {
                reversedString += text[i-1].ToString();
            }

            Console.WriteLine(reversedString);
        }
    }
}