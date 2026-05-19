using FakeAxeAndDummy;

namespace Skeleton.Tests;

[TestFixture]
public class DummyTests
{
    [Test]
    public void DummyLosesHealthWhenAttacked()
    {
        Axe axe = new(1, 9999);
        Dummy dummy = new(10, 10);

        axe.Attack(dummy);

        Assert.That(dummy.Health, Is.EqualTo(9), "Dummy health didn't change");
    }

	[Test]
	public void ThrowsExceptionWhenDeadDummyIsAttacked()
	{
		Axe axe = new(5, 9999);
		Dummy dummy = new(1, 10);

        axe.Attack(dummy);

        Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy), "Dead dummy didn't throw exception when attacked");
	}

    [Test]
    public void DummyGivesExperienceWhenDead()
    {
        Axe axe = new(5, 9999);
        Dummy dummy = new(1, 10);

		axe.Attack(dummy);
		int experience = dummy.GiveExperience();

        Assert.That(experience, Is.EqualTo(10), "Dead dummy didn't provide experience");
    }

    [Test]
	public void DummyDoesNotGiveExperienceWhenAlive()
	{
		Dummy dummy = new(9999, 10);

        Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience());
	}
}