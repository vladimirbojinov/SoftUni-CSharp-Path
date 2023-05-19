namespace _04._Sum_of_Chars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int loops = int.Parse(Console.ReadLine());
            int sum = 0;

            for (int i = 0; i < loops; i++)
            {
                char numChar = char.Parse(Console.ReadLine());
                sum += numChar;
            }

            Console.WriteLine($"The sum equals: {sum}");
        }
    }
}