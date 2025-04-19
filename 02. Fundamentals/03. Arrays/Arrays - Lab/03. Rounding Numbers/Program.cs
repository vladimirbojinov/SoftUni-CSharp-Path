namespace _03._Rounding_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] numbersRow = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToArray();

            int[] roundedNumbers = new int[numbersRow.Length];
            
            for (int i = 0; i < roundedNumbers.Length; i++)
            {
                roundedNumbers[i] = (int)Math.Round(numbersRow[i], MidpointRounding.AwayFromZero);
            }

            for (int j = 0;j < roundedNumbers.Length; j++)
            {
                Console.WriteLine($"{numbersRow[j]} => {roundedNumbers[j]}");
            }
        }
    }
}