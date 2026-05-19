namespace CarManager.Tests;

using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;

[TestFixture]
public class CarManagerTests
{
	[Test]
	public void CarShouldBeInitializedCorrectly()
	{
		Random random = new();

		string make = "make";
		string model = "model";
		double fuelConsumption = random.NextDouble() * 5.00;
		double fuelCapacity = random.NextDouble() * 50.00;

		Car car = new(make, model, fuelConsumption, fuelCapacity);

		Assert.That(car.Make, Is.EqualTo(make));
		Assert.That(car.Model, Is.EqualTo(model));
		Assert.That(car.FuelConsumption, Is.EqualTo(fuelConsumption));
		Assert.That(car.FuelCapacity, Is.EqualTo(fuelCapacity));
	}

	[TestCase(null), TestCase("")]
	public void CarMakeShouldThrowExceptionWhenNullOrEmpty(string value)
	{
		Assert.That(() => new Car(value, "model", 5, 5), Throws.TypeOf<ArgumentException>());
	}

	[TestCase(null), TestCase("")]
	public void CarModelShouldThrowExceptionWhenNullOrEmpty(string value)
	{
		Assert.That(() => new Car("make", value, 5, 5), Throws.TypeOf<ArgumentException>());
	}

	[TestCase(-1), TestCase(0)]
	public void CarFuelConsumptionShouldThrowExceptionWhenItsZeroOrNegative(double value)
	{
		Assert.That(() => new Car("make", "model", value, 5), Throws.TypeOf<ArgumentException>());
	}

	[Test]
	public void CarFuelCapacityShouldThrowExceptionWhenItsNegative()
	{
		Assert.That(() => new Car("make", "model", 5, -1), Throws.TypeOf<ArgumentException>());
	}

	[Test]
	public void CarRefuelShouldWorkCorrectly()
	{
		Car car = CreateCar();
		car.Refuel(1);

		Assert.That(car.FuelAmount, Is.EqualTo(1));
	}

	[Test]
	public void CarRefuelShouldNotExceedFuelCapacity()
	{
		Car car = CreateCar();
		car.Refuel(9999);

		Assert.That(car.FuelAmount, Is.EqualTo(car.FuelCapacity));
	}

	[TestCase(0), TestCase(-1)]
	public void CarRefuelShouldThrowExceptionWhenRefuelingWithNegativeOrZeroValue(double fuel)
	{
		Car car = CreateCar();
		Assert.That(() => car.Refuel(fuel), Throws.TypeOf<ArgumentException>());
	}

	[Test]
	public void CarDriveShouldWorkCorrectly()
	{
		Car car = CreateCar();

		car.Refuel(9999);

		double oldFuel = car.FuelAmount;
		double distance = 5;
		double expectedFuelUsed = (distance / 100) * car.FuelConsumption;

		car.Drive(distance);

		Assert.That(car.FuelAmount, Is.EqualTo(oldFuel - expectedFuelUsed));
	}

	[Test]
	public void CarDriveShouldThrowExceptionWhenNotEnoughFuel()
	{
		Car car = CreateCar();
		Assert.That(() => car.Drive(50), Throws.TypeOf<InvalidOperationException>());
	}

	private Car CreateCar()
	{
		Random random = new();

		string make = "make";
		string model = "model";
		double fuelConsumption = random.NextDouble() * 5.00;
		double fuelCapacity = random.NextDouble() * 50.00;

		return new Car(make, model, fuelConsumption, fuelCapacity);
	}
}