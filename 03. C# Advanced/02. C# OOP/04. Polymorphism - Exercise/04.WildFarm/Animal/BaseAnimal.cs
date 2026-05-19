using _04.WildFarm.Foods;
using _04.WildFarm.Interfaces;

namespace _04.WildFarm.Animal;

internal abstract class BaseAnimal : ISound
{
	protected BaseAnimal(string name, double weight)
	{
		this.Name = name;
		this.Weight = weight;
	}

	public string Name { get; }
	public double Weight { get; private set; }
	public int FoodEaten { get; private set; }
	protected virtual double WeightGainPerPiece { get; }

	public virtual void Eat(BaseFood food)
	{
		if (CanEat(food))
		{
			this.Weight += WeightGainPerPiece * food.Quantity;
			this.FoodEaten += food.Quantity;
		}
	}

	public abstract bool CanEat(BaseFood food);

	public abstract string EmitSound();
}
