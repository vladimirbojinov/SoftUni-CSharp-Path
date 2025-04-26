namespace _02._Center_Point
{
	internal class Program
	{
		static void Main(string[] args)
		{
			double x1 = double.Parse(Console.ReadLine());
			double y1 = double.Parse(Console.ReadLine());
			double x2 = double.Parse(Console.ReadLine());
			double y2 = double.Parse(Console.ReadLine());

			Console.WriteLine(CompareDistances(x1, y1, x2, y2));
		}

		private static double CalculateDistanceFromCenter(double x, double y)
		{
			double distance = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));

			return distance;
		}

		private static string CompareDistances(double x1, double y1, double x2, double y2)
		{
			double distanceA = CalculateDistanceFromCenter(x1, y1);
			double distanceB = CalculateDistanceFromCenter(x2, y2);

			if (distanceA <= distanceB)
			{
				return $"({x1}, {y1})";
			}
			else
			{
				return $"({x2}, {y2})";
			}
		}
	}
}
