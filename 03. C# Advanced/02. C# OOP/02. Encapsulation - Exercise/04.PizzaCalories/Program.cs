using System.Security.AccessControl;

namespace _04.PizzaCalories;

public class StartUp
{
	static void Main(string[] args)
	{
		List<Topping> toppings = new();

		try
		{
			string pizzaName = Console.ReadLine().Split(" ")[1];

			Dough dough = CreateDough();
			CreateAndAddTopping(toppings);
			Pizza? pizza = CreatePizza(pizzaName, dough, toppings);

			Console.WriteLine(pizza);
		}
		catch (Exception e)
		{
			Console.WriteLine(e.Message);
		}
	}

	private static Pizza CreatePizza(string pizzaName, Dough dough, List<Topping> toppings)
	{
		return new Pizza(pizzaName, dough, toppings);
	}

	private static void CreateAndAddTopping(List<Topping> toppings)
	{
		string command;
		while ((command = Console.ReadLine()) != "END")
		{
			string[] ingredientType = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
			string toppingName = ingredientType[1];
			double grams = double.Parse(ingredientType[2]);

			Topping topping = new Topping(toppingName, grams);
			toppings.Add(topping);
		}
	}

	private static Dough CreateDough()
	{
		string[] doughType = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

		string flourType = doughType[1];
		string bakingTechnique = doughType[2];
		double grams = double.Parse(doughType[3]);

		return new Dough(flourType, bakingTechnique, grams);
	}
}