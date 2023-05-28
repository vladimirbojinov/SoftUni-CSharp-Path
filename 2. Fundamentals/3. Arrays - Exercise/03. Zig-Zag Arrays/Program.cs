namespace _03._Zig_Zag_Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int loops = int.Parse(Console.ReadLine());
            string[] firstDigit = new string[loops];
            string[] firstDigit2 = new string[loops];

            int counter = 0;
            for (int i = 0; i < loops; i++)
            {
                string[] numbers = Console.ReadLine().Split();
                if ((i+1) % 2 == 0)
                {
                    firstDigit[i] = numbers[1];
                    firstDigit2[i] = numbers[0];
                }
                else
                {
                    firstDigit2[i] = numbers[1];
                    firstDigit[i] = numbers[0];
                }
            }

            Console.Write(string.Join(" ", firstDigit));
            Console.WriteLine();
            Console.Write(string.Join(" ", firstDigit2));
        }
    }
}