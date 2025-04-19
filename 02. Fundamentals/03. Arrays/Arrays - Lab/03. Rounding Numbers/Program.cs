namespace _03._Rounding_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] numberRow = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToArray();

            int[] rounded = new int[numberRow.Length];
            
            for (int i = 0; i < rounded.Length; i++)
            {
                rounded[i] = (int)Math.Round(numberRow[i], MidpointRounding.AwayFromZero);
            }

            for (int j = 0;j < rounded.Length; j++)
            {
                Console.WriteLine($"{numberRow[j]} => {rounded[j]}");
            }
        }
    }
}