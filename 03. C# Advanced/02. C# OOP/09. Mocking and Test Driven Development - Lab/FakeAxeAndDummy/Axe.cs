namespace FakeAxeAndDummy;


// Axe durability drop with 5 
public class Axe : IWeapon
{
	public Axe(int attack, int durability)
	{
		AttackPoints = attack;
		DurabilityPoints = durability;
	}

	public int AttackPoints { get; }
	public int DurabilityPoints { get; private set; }

	public void Attack(ITarget target)
	{
		if (DurabilityPoints <= 0)
		{
			throw new InvalidOperationException("Axe is broken.");
		}

		target.TakeAttack(AttackPoints);
		DurabilityPoints -= 1;
	}
}