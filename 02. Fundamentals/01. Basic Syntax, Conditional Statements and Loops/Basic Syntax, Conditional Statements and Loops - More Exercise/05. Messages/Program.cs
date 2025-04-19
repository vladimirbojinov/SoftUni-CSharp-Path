namespace _05._Messages
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int loops = int.Parse(Console.ReadLine());
            string message = string.Empty;

            for (int i = 0; i < loops; i++)
            {
                string numberAsString = Console.ReadLine();
                int numberOfDigits = numberAsString.Length;
                int mainDigit = int.Parse(numberAsString[0].ToString());

                int offset = (mainDigit - 2) * 3;

                if (mainDigit == 8 || mainDigit == 9)
                {
                    offset++;
                }

                int letterIndex = (offset + numberOfDigits - 1) + 97;
                if (offset == -6)
                {
                    message += " ";
                }
                else
                {
                    message += (char)letterIndex;
                }
            }

            Console.WriteLine(message);
        }
    }
}