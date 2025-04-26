namespace _03._Longer_Line
{
	internal class Program
	{
		static void Main(string[] args)
		{
			double x1 = double.Parse(Console.ReadLine());
			double y1 = double.Parse(Console.ReadLine());
			double x2 = double.Parse(Console.ReadLine());
			double y2 = double.Parse(Console.ReadLine());

			double x3 = double.Parse(Console.ReadLine());
			double y3 = double.Parse(Console.ReadLine());
			double x4 = double.Parse(Console.ReadLine());
			double y4 = double.Parse(Console.ReadLine());

			double distanceA = CalculateDistance(x1, y1, x2, y2);
			double distanceB = CalculateDistance(x3, y3, x4, y4);

			if (distanceA >= distanceB)
			{
				if (CompareDistances(x1, y1, x2, y2) == 1)
				{
					Console.Write($"({x1}, {y1})({x2}, {y2})");
				}
				else
				{
					Console.Write($"({x2}, {y2})({x1}, {y1})");
				}
			}
			else
			{
				if (CompareDistances(x3, y3, x4, y4) == 1)
				{
					Console.Write($"({x3}, {y3})({x4}, {y4})");
				}
				else
				{
					Console.Write($"({x4}, {y4})({x3}, {y3})");
				}
			}
		}

		private static double CalculateDistance(double x1, double y1, double x2, double y2)
		{
			double distance = Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));

			return distance;
		}

		private static int CompareDistances(double x1, double y1, double x2, double y2)
		{
			double distanceA = CalculateDistance(x1, y1, 0, 0);
			double distanceB = CalculateDistance(x2, y2, 0, 0);

			if (distanceA <= distanceB)
			{
				return 1;
			}
			else
			{
				return -1;
			}
		}
	}
}
