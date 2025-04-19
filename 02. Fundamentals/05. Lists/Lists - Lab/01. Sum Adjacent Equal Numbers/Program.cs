namespace _01._Sum_Adjacent_Equal_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<double> equalSum = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToList();

            for (int i = 0; i < equalSum.Count - 1; i++)
            {
                if (equalSum[i] == equalSum[i + 1])
                {
                    equalSum[i] += equalSum[i + 1];
                    equalSum.RemoveAt(i + 1);
                    i = -1;
                }
            }

            Console.WriteLine(string.Join(" ", equalSum));
        }
    }
}