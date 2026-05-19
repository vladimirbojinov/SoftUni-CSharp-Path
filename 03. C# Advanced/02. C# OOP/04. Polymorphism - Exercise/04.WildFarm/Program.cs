using _04.WildFarm.Animal;
using _04.WildFarm.Animal.Bird;
using _04.WildFarm.Animal.Mammal;
using _04.WildFarm.Animal.Mammal.Feline;
using _04.WildFarm.Foods;

namespace _04.WildFarm;

internal class Program
{
	static void Main(string[] args)
	{
		List<BaseAnimal> animals = new List<BaseAnimal>();

		string command;
		while ((command = Console.ReadLine()) != "End")
		{
			string[] animalData = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
			string[] foodData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

			BaseAnimal animal = CreateAnimal(animals, animalData);
			BaseFood food = CreateFood(foodData);

			Console.WriteLine(animal.EmitSound());

			if (food != null && food != null && animal.CanEat(food)) animal.Eat(food);
			else Console.WriteLine($"{animal.GetType().Name} does not eat {food.GetType().Name}!");
		}

		Console.WriteLine(string.Join("\n", animals));
	}

	private static BaseFood CreateFood(string[] foodData)
	{
		string foodType = foodData[0];
		int foodQuantity = int.Parse(foodData[1]);

		BaseFood food = foodType switch
		{
			"Fruit" => new Fruit(foodQuantity),
			"Meat" => new Meat(foodQuantity),
			"Seeds" => new Seeds(foodQuantity),
			"Vegetable" => new Vegetable(foodQuantity)
		};

		return food;
	}

	private static BaseAnimal CreateAnimal(List<BaseAnimal> animals, string[] data)
	{
		BaseAnimal animal;

		string animalType = data[0];
		switch (animalType)
		{
			case "Mouse":
			case "Dog": return animal = CreateMammal(data, animals);
			case "Cat":
			case "Tiger": return animal = CreateFeline(data, animals);
			case "Hen":
			case "Owl": return animal = CreateBird(data, animals);
		}

		return null;
	}

	private static BaseAnimal CreateBird(string[] data, List<BaseAnimal> animals)
	{
		string animalType = data[0];
		string name = data[1];
		double weight = double.Parse(data[2]);
		double wingSize = double.Parse(data[3]);


		BaseAnimal? animal = animalType switch
		{
			"Hen" => new Hen(name, weight, wingSize),
			"Owl" => new Owl(name, weight, wingSize),
			_ => null
		};

		animals.Add(animal);
		return animal;
	}

	private static BaseAnimal CreateFeline(string[] data, List<BaseAnimal> animals)
	{
		string animalType = data[0];
		string name = data[1];
		double weight = double.Parse(data[2]);
		string livingRegion = data[3];
		string breed = data[4];


		BaseAnimal? animal = animalType switch
		{
			"Cat" => new Cat(name, weight, livingRegion, breed),
			"Tiger" => new Tiger(name, weight, livingRegion, breed),
			_ => null
		};

		animals.Add(animal);
		return animal;
	}

	private static BaseAnimal CreateMammal(string[] data, List<BaseAnimal> animals)
	{
		string animalType = data[0];
		string name = data[1];
		double weight = double.Parse(data[2]);
		string livingRegion = data[3];


		BaseAnimal? animal = animalType switch
		{
			"Dog" => new Dog(name, weight, livingRegion),
			"Mouse" => new Mouse(name, weight, livingRegion),
			_ => null
		};

		animals.Add(animal);
		return animal;
	}
}
