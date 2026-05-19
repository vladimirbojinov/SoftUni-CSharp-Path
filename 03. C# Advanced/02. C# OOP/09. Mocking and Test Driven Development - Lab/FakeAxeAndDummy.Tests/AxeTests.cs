using FakeAxeAndDummy;

namespace Skeleton.Tests;

[TestFixture]
public class AxeTests
{
    [Test]
    public void AttackLowersAxeDurability()
    {
		Axe axe = new(10, 10);
		Dummy dummy = new(9999, 10);

		axe.Attack(dummy);
		Assert.That(axe.DurabilityPoints, Is.EqualTo(9), "Axe durability didn't change");
	}

	[Test]
	public void BrokenAxeThrowsExceptionWhenAttacking()
	{
		Axe axe = new(1, 1);
		Dummy dummy = new(9999, 10);

		axe.Attack(dummy);
		Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy));
	}
}