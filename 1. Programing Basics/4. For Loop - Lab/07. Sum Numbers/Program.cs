namespace _07._Sum_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int loop = int.Parse(Console.ReadLine());

            int totalSum = 0;

            for (int i = 0; i < loop; i++)
            {
                int num = int.Parse(Console.ReadLine());
                totalSum += num;
            }

            Console.WriteLine(totalSum);
        }
    }
}