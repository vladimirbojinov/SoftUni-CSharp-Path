namespace _06._Strong_number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string numberAsString = Console.ReadLine();

            int finalNum = 0;

            for (int i = 0; i < numberAsString.Length; i++)
            {
                int sum = 1;
                string currentChar = numberAsString[i].ToString();
                int currentNum = int.Parse(currentChar);

                for (int j = 1; j <= currentNum; j++)
                {
                    sum *= j;
                }

                finalNum += sum;
            }

            int convertedNumber = int.Parse(numberAsString);

            if (finalNum == convertedNumber)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}