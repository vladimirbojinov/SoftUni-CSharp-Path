namespace _03._Vacation
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int peopleCount = int.Parse(Console.ReadLine());
			string groupType = Console.ReadLine();
			string day = Console.ReadLine();

			double price = 0;

			if (groupType == "Students")
			{
				switch (day)
				{
					case "Friday": price = 8.45 * peopleCount; break;
					case "Saturday": price = 9.80 * peopleCount; break;
					case "Sunday": price = 10.46 * peopleCount; break;
				}

				if (peopleCount >= 30)
				{
					price *= 0.85;
				}
			}
			else if (groupType == "Business")
			{
				if (peopleCount >= 100)
				{
					peopleCount -= 10;
				}

				switch (day)
				{
					case "Friday": price = 10.90 * peopleCount; break;
					case "Saturday": price = 15.60 * peopleCount; break;
					case "Sunday": price = 16.00 * peopleCount; break;
				}
			}
			else if (groupType == "Regular")
			{
				switch (day)
				{
					case "Friday": price = 15.00 * peopleCount; break;
					case "Saturday": price = 20.00 * peopleCount; break;
					case "Sunday": price = 22.50 * peopleCount; break;
				}

				if (peopleCount >= 10 && peopleCount <= 20)
				{
					price *= 0.95;
				}
			}

			Console.WriteLine($"Total price: {price:f2}");
		}
	}
}