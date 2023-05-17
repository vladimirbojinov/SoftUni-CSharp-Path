namespace _09._Sum_of_Odd_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int counter = 1;
            int sum = 0;

            for (int i = 0; i < n; i++)
            {
                if (counter % 2 != 0)
                {
                    Console.WriteLine(counter);
                    sum += counter;
                }
                else
                {
                    i--;
                }
                counter++;
            }

            Console.WriteLine($"Sum: {sum}");
        }
    }
}