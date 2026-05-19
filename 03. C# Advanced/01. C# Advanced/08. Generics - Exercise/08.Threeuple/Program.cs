namespace _08.Threeuple;

internal class Program
{
	static void Main(string[] args)
	{
		PersonInformation();
		LittersCanDrink();
		BankInformation();
	}

	private static void BankInformation()
	{
		string[] bankData = Console.ReadLine()
					.Split(" ", StringSplitOptions.RemoveEmptyEntries);

		string personName = bankData[0];
		double balance = double.Parse(bankData[1]);
		string bankName = bankData[2];

		Tuple<string, double, string> tuple = new (personName, balance, bankName);
		Console.WriteLine(tuple);
	}

	private static void LittersCanDrink()
	{
		string[] canDrinkData = Console.ReadLine()
					.Split(" ", StringSplitOptions.RemoveEmptyEntries);

		string personName = canDrinkData[0];
		int litersCanDrink = int.Parse(canDrinkData[1]);
		string drunkState = canDrinkData[2];

		Predicate<string> predicate = p => drunkState == "drunk";

		Tuple<string, int, bool> tuple = new (personName, litersCanDrink, predicate(drunkState));
		Console.WriteLine(tuple);
	}

	private static void PersonInformation()
	{
		string[] personData = Console.ReadLine()
					.Split(" ", StringSplitOptions.RemoveEmptyEntries);

		string personName = $"{personData[0]} {personData[1]}";
		string address = personData[2];
		string[] town = personData[3..];
		string fullTownName = string.Join(" ", town);

		Tuple<string, string, string> tuple = new (personName, address, fullTownName);
        Console.WriteLine(tuple);
	}
}
