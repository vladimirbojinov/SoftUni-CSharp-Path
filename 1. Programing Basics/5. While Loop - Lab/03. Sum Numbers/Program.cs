namespace _03._Sum_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            int value = 0;

            while (value < num)
            {
                int num2 = int.Parse(Console.ReadLine());
                value += num2;
            }

            Console.WriteLine(value);
        }
    }
}