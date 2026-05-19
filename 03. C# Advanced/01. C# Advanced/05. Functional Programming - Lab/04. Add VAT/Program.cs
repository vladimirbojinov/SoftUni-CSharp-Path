namespace _04._Add_VAT
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Func<double, double> vat = x => x * 1.20;

			double[] array = Console.ReadLine()
				.Split(", ", StringSplitOptions.RemoveEmptyEntries)
				.Select(double.Parse)
				.Select(vat)
				.ToArray();

            foreach (double value in array)
			{
				Console.WriteLine($"{value:F2}");
			}
        }
	}
}
