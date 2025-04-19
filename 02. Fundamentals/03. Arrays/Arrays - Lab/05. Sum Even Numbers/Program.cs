namespace _05._Sum_Even_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] row = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int sum = 0;

            for (int i = 0; i < row.Length; i++)
            {
                int input = row[i];

                if (input % 2 == 0)
                {
                    sum += input;
                }
            }

            Console.WriteLine(sum);
        }
    }
}