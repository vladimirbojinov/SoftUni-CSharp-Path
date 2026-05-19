namespace FightingArena.Tests
{
	using NUnit.Framework;
	using System;
	using System.Collections.Generic;

	[TestFixture]
	public class ArenaTests
	{
		private int warriorIndex = 0;

		[TestCase(16), TestCase(1), TestCase(8)]
		public void ArenaShouldBeInitialized(int n)
		{
			Arena arena = new();

			for (int i = 0; i < n; i++)
			{
				Warrior warrior = CreateWarrior();
				arena.Enroll(warrior);
			}

			Assert.That(arena.Count, Is.EqualTo(n));
		}

		[Test]
		public void ArenaEnrollShouldThrowExceptionWhenEnrollingWarriorWithSameName()
		{
			Warrior warrior = CreateWarrior();

			Arena arena = new();
			arena.Enroll(warrior);

			Assert.That(() => arena.Enroll(warrior), Throws.TypeOf<InvalidOperationException>());
		}

		[Test]
		public void ArenaFightShouldWorkCorrectly()
		{
			Warrior warriorA = CreateWarrior();
			Warrior warriorD = CreateWarrior();
			Arena arena = new();

			arena.Enroll(warriorA);
			arena.Enroll(warriorD);

			int defenderHpLeft = warriorD.HP - warriorA.Damage;
			arena.Fight(warriorA.Name, warriorD.Name);
			Assert.That(warriorD.HP, Is.EqualTo(defenderHpLeft));

		}

		[Test]
		public void ArenaFightShouldThrowExceptionWhenWarriorNotFound()
		{
			Assert.That(() => new Arena().Fight("No one", "No body"), Throws.TypeOf<InvalidOperationException>());
		}

		[TestCase(30), TestCase(15), TestCase(29)]
		public void ArenaFightShouldThrowExceptionWhenAttackerHpIsEqualOrUnder30(int hp)
		{
			Warrior warriorA = new("WarriorA", 10, hp);
			Warrior warriorD = new("WarriorD", 10, 100);

			Arena arena = new();
			arena.Enroll(warriorA);
			arena.Enroll(warriorD);

			Assert.That(() => arena.Fight(warriorA.Name, warriorD.Name), Throws.TypeOf<InvalidOperationException>());
		}

		[TestCase(30), TestCase(15), TestCase(29)]
		public void ArenaFightShouldThrowExceptionWhenDefenderHpIsEqualOrUnder30(int hp)
		{
			Warrior warriorA = new("WarriorA", 10, 100);
			Warrior warriorD = new("WarriorD", 10, hp);

			Arena arena = new();
			arena.Enroll(warriorA);
			arena.Enroll(warriorD);

			Assert.That(() => arena.Fight(warriorA.Name, warriorD.Name), Throws.TypeOf<InvalidOperationException>());
		}

		[Test]
		public void ArenaFightShouldThrowExceptionWhenDefenderAttackIsAboveAttackerHp()
		{
			Warrior warriorA = new("WarriorA", 10, 100);
			Warrior warriorD = new("WarriorD", 9999, 100);

			Arena arena = new();
			arena.Enroll(warriorA);
			arena.Enroll(warriorD);

			Assert.That(() => arena.Fight(warriorA.Name, warriorD.Name), Throws.TypeOf<InvalidOperationException>());
		}

		[Test]
		public void ArenaFightWhenDefenderIsDefeatedHpShouldNotBeNegative()
		{
			Warrior warriorA = new("WarriorA", 999, 100);
			Warrior warriorD = new("WarriorD", 10, 100);

			Arena arena = new();
			arena.Enroll(warriorA);
			arena.Enroll(warriorD);

			arena.Fight(warriorA.Name, warriorD.Name);

			Assert.That(warriorD.HP, Is.EqualTo(0));
		}

		private Warrior CreateWarrior()
		{
			Random random = new();

			string name = $"Warrior{warriorIndex++}";
			int damage = random.Next(5, 11);
			int hp = random.Next(70, 101);

			return new Warrior(name, damage, hp);
		}
	}
}
