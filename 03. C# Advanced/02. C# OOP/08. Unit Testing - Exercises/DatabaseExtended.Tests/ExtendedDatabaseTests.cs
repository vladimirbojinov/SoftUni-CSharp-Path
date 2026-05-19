namespace DatabaseExtended.Tests;

using ExtendedDatabase;
using NUnit.Framework;
using System;

[TestFixture]
public class ExtendedDatabaseTests
{
	private const int BaseCapacity = 16;

	[TestCase(BaseCapacity), TestCase(1), TestCase(0)]
	public void DatabaseShouldBeInitializedCorrectly(int n)
	{
		Person[] people = FillDatabase(n);
		Database database = new(people);

		foreach (Person person in people)
		{
			Assert.That(database.FindById(person.Id), Is.EqualTo(person));
			Assert.That(database.Count, Is.EqualTo(people.Length));
		}

	}

	[Test]
	public void DatabaseShouldThrowExceptionWhenAddRangeIsAboveCapacity()
	{
		Person[] people = FillDatabase(BaseCapacity + 1);
		Assert.That(() => new Database(people), Throws.TypeOf<ArgumentException>());
	}

	[Test]
	public void DatabaseShouldThrowExceptionWhenAddIsAboveCapacity()
	{
		Person[] people = FillDatabase(BaseCapacity);
		Database database = new(people);

		Assert.That(() => database.Add(people[0]), Throws.TypeOf<InvalidOperationException>());
	}

	[Test]
	public void DataBaseShouldThrowExceptionWhenAddingPersonWithSameUsername()
	{
		Person[] people = FillDatabase(5);
		Database database = new(people);

		Person duplicateUsernamePerson = new(people[people.Length - 1].Id + 1, people[people.Length - 1].UserName);

		Assert.That(() => database.Add(duplicateUsernamePerson), Throws.TypeOf<InvalidOperationException>());
	}

	[Test]
	public void DataBaseShouldThrowExceptionWhenAddingPersonWithSameId()
	{
		Person[] people = FillDatabase(5);
		Database database = new(people);

		Person duplicateIdPerson = new(people[people.Length - 1].Id, "Duplicate");

		Assert.That(() => database.Add(duplicateIdPerson), Throws.TypeOf<InvalidOperationException>());
	}

	[Test]
	public void DataBaseRemoveShouldWorkCorrectly()
	{
		Person[] people = FillDatabase(5);
		Database database = new(people);

		database.Remove();

		Assume.That(database.Count, Is.EqualTo(people.Length - 1));
	}

	[Test]
	public void EmptyDatabaseShouldThrowExceptionWhenRemoving()
	{
		Person[] people = FillDatabase(0);
		Database database = new(people);

		Assume.That(() => database.Remove(), Throws.TypeOf<InvalidOperationException>());
	}

	[Test]
	public void DataBaseFindByUsernameShouldWorkCorrectly()
	{
		Person[] people = FillDatabase(BaseCapacity);
		Database database = new(people);

		foreach (Person person in people)
		{
			Assert.That(database.FindByUsername(person.UserName), Is.EqualTo(person));
		}
	}

	[Test]
	public void DataBaseFindByUsernameShouldThrowExceptionWhenNullOrEmpty()
	{
		Assert.That(() => new Database().FindByUsername(""), Throws.TypeOf<ArgumentNullException>());
		Assert.That(() => new Database().FindByUsername(null), Throws.TypeOf<ArgumentNullException>());
	}

	[Test]
	public void DataBaseFindByUsernameShouldThrowExceptionWhenPersonNotFound()
	{
		Assert.That(() => new Database().FindByUsername("Not existing"), Throws.TypeOf<InvalidOperationException>());
	}

	[Test]
	public void DataBaseFindByIdShouldThrowExceptionWhenIdIsNegativeNumber()
	{
		Assert.That(() => new Database().FindById(-1), Throws.TypeOf<ArgumentOutOfRangeException>());
	}

	[Test]
	public void DataBaseFindByIdShouldThrowExceptionWhenIdNotFound()
	{
		Assert.That(() => new Database().FindById(5), Throws.TypeOf<InvalidOperationException>());
	}


	private Person[] FillDatabase(int n)
	{
		Person[] people = new Person[n];

		Random random = new Random();
		string name = string.Empty;

		for (int i = 0; i < n; i++)
		{
			Person person = new(i, $"Person #{i}");

			people[i] = person;
		}

		return people;
	}
}