namespace _03._Zig_Zag_Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int loops = int.Parse(Console.ReadLine());
            string[] firstDigit = new string[loops];
            string[] secondDigit = new string[loops];

            for (int i = 1; i <= loops; i++)
            {
                string[] numbers = Console.ReadLine().Split();
                if (i % 2 == 0)
                {
                    firstDigit[i - 1] = numbers[1];
                    secondDigit[i - 1] = numbers[0];
                }
                else
                {
                    secondDigit[i - 1] = numbers[1];
                    firstDigit[i - 1] = numbers[0];
                }
            }

            Console.WriteLine(string.Join(" ", firstDigit));
            Console.Write(string.Join(" ", secondDigit));
        }
    }
}