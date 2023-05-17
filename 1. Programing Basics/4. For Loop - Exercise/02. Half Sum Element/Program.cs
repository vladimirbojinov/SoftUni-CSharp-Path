namespace _02._Half_Sum_Element
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int loop = int.Parse(Console.ReadLine());

            int max = int.MinValue;
            int value = 0;

            for (int i = 0; i < loop; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (num > max)
                {
                    max = num;
                }

                value += num;
            }

            int lastValue = value - max;

            if (lastValue == max)
            {
                Console.WriteLine("Yes");
                Console.WriteLine($"Sum = {max}");
            }
            else
            {
                Console.WriteLine("No");
                Console.WriteLine($"Diff = {Math.Abs(lastValue - max)}");
            }
        }
    }
}