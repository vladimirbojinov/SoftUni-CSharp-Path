namespace _05._Messages
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int loops = int.Parse(Console.ReadLine());
            string text = "";

            for (int i = 0; i < loops; i++)
            {
                string number = Console.ReadLine();
                int mainDigit = 0;
                int numberLengt = 0;

                for (int j = 0; j < number.Length; j++)
                {
                    numberLengt++;
                }

                for (int k = 0; k < 1; k++)
                {
                    mainDigit = int.Parse(number[k].ToString());
                }

                int offset = 0;
                if (mainDigit == 8 || mainDigit == 9)
                {
                    offset = (mainDigit - 2) * 3;
                    offset++;
                }
                else
                {
                    offset = (mainDigit - 2) * 3;
                }

                if (mainDigit == 0)
                {
                    text += " ";
                }
                else
                {
                    int letterIndex = (offset + numberLengt - 1);
                    letterIndex += 97;

                    char letter = (char)letterIndex;
                    text += letter;
                }
            }
            Console.WriteLine(text);
        }
    }
}