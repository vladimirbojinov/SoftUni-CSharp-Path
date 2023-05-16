namespace _06._Strong_number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string num = Console.ReadLine();

            int sum = 1;
            int finalNum = 0;

            for (int i = 0; i < num.Length; i++)
            {
                char currentCharacter = num[i];
                string str = currentCharacter.ToString();
                int curentNum = int.Parse(str);

                for (int j = 1; j <= curentNum; j++)
                {
                    sum *= j;
                }

                finalNum += sum;
                sum = 1;
            }

            int num2 = int.Parse(num);

            if (finalNum == num2)
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