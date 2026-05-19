namespace FightingArena.Tests
{
	using NUnit.Framework;
	using System;

	[TestFixture]
	public class WarriorTests
	{
		[Test]
		public void WarriorShouldBeInitializedCorrectly()
		{
			Random random = new();

			string name = $"Warrior";
			int damage = random.Next(0, 11);
			int hp = random.Next(70, 101);

			Warrior warrior = new(name, damage, hp);

			Assert.That(warrior.Name, Is.SameAs(name));
			Assert.That(warrior.Damage, Is.EqualTo(damage));
			Assert.That(warrior.HP, Is.EqualTo(hp));
		}

		[TestCase(null), TestCase(" ")]
		public void WarriorNameShouldThrowExceptionWhenNullOrWhiteSpace(string value)
		{
			Assert.That(() => new Warrior(value, 10, 10), Throws.TypeOf<ArgumentException>());
		}

		[TestCase(-1), TestCase(0)]
		public void WarriorDamageShouldThrowExceptionWhenZeroOrNegative(int value)
		{
			Assert.That(() => new Warrior("Warrior", value, 10), Throws.TypeOf<ArgumentException>());
		}

		[Test]
		public void WarriorDamageShouldThrowExceptionWhenNegative()
		{
			Assert.That(() => new Warrior("Warrior", 10, -1), Throws.TypeOf<ArgumentException>());
		}
	}
}