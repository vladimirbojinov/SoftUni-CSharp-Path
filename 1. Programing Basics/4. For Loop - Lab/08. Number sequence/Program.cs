namespace _08._Number_sequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int loop = int.Parse(Console.ReadLine());

            int min = int.MaxValue;
            int max = int.MinValue;

            for (int i = 0; i < loop; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (num > max)
                {
                    max = num;
                }
                if (num < min)
                {
                    min = num;
                }
            }

            Console.WriteLine($"Max number: {max}");
            Console.WriteLine($"Min number: {min}");
        }
    }
}