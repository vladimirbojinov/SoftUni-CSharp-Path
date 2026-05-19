using System.Globalization;

namespace _07.Tuple;

internal class Program
{
	static void Main(string[] args)
	{
		PersonInformation();
		LittersCanDrink();
		Numbers();
    }

	private static void Numbers()
	{
		string[] numbersData = Console.ReadLine()
					.Split(" ", StringSplitOptions.RemoveEmptyEntries);

		int integerNumber = int.Parse(numbersData[0]);
		double doubleNumber = double.Parse(numbersData[1]);

		Tuple<int, double> tuple = new(integerNumber, doubleNumber);
        Console.WriteLine(tuple);
    }

	private static void LittersCanDrink()
	{
		string[] canDrinkData = Console.ReadLine()
					.Split(" ", StringSplitOptions.RemoveEmptyEntries);

		string personName = canDrinkData[0];
		int litersCanDrink = int.Parse(canDrinkData[1]);

		Tuple<string, int> personDrinkInfo = new(personName, litersCanDrink);
        Console.WriteLine(personDrinkInfo);
    }

	private static void PersonInformation()
	{
		string[] personData = Console.ReadLine()
					.Split(" ", StringSplitOptions.RemoveEmptyEntries);

		string personName = $"{personData[0]} {personData[1]}";
		string address = personData[2];

		Tuple<string, string> personInfo = new(personName, address);
        Console.WriteLine(personInfo);
    }
}
