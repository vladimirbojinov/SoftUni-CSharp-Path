using Moq;

namespace FakeAxeAndDummy.Tests;

internal class HeroTests
{
	[TestCase(10, 20), TestCase(50, 10), TestCase(100, 200)]
	public void HeroShouldBeInitializedCorrectly(int damage, int durability)
	{
		string name = "HeroName";
		
		Mock<IWeapon> weapon = MockWeapon(damage, durability);
		Hero hero = new(name, weapon.Object);

		Assume.That(hero.Name, Is.EqualTo(name));
		Assume.That(hero.Weapon.AttackPoints, Is.EqualTo(weapon.Object.AttackPoints));
		Assume.That(hero.Weapon.DurabilityPoints, Is.EqualTo(weapon.Object.DurabilityPoints));
	}

	[Test]
	public void HeroAttackingTargetShouldNotGiveExperience()
	{
		Mock<IWeapon> weapon = MockWeapon(1, 999);
		Mock<ITarget> target = MockTarget(999, 5);
		Hero hero = new("HeroName", weapon.Object);

		hero.Attack(target.Object);

		Assume.That(hero.Experience, Is.EqualTo(0));
	}

	[Test]
	public void HeroKillingTargetShouldGiveExperience()
	{
		Mock<IWeapon> weapon = MockWeapon(999, 999);
		Mock<ITarget> target = new();
		Hero hero = new("HeroName", weapon.Object);

		target.Setup(t => t.IsDead()).Returns(true);
		target.Setup(t => t.GiveExperience()).Returns(5);
		hero.Attack(target.Object);

		Assume.That(hero.Experience, Is.EqualTo(5));
	}

	private Mock<IWeapon> MockWeapon(int damage, int durability)
	{
		Mock<IWeapon> fakeWeapon = new();

		fakeWeapon.Setup(w => w.AttackPoints).Returns(damage);
		fakeWeapon.Setup(w => w.DurabilityPoints).Returns(durability);

		return fakeWeapon;
	}

	private Mock<ITarget> MockTarget(int health, int experience)
	{
		Mock<ITarget> fakeTarget = new();

		fakeTarget.Setup(t => t.Health).Returns(health);
		fakeTarget.Setup(t => t.Experience).Returns(experience);

		return fakeTarget;
	}
}
