namespace _01._Reverse_Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string reversedText = string.Empty;

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                reversedText = ReverseString(command);
                Console.WriteLine($"{command} = {reversedText}");
            }
        }

        private static string ReverseString(string text)
        {
            string reverseString = string.Empty;

            for (int i = text.Length - 1; i >= 0; i--)
            {
                reverseString += text[i].ToString();
            }

            return reverseString;
        }
    }
}