namespace PersonsInfo;

public class Person
{
	public Person(string firstName, string lastName, int age, decimal salary)
	{
		if (firstName.Length < 3) throw new ArgumentException("First name cannot contain fewer than 3 symbols!");
		if (lastName.Length < 3) throw new ArgumentException("Last name cannot contain fewer than 3 symbols!");
		if (age <= 0) throw new ArgumentException("Age cannot be zero or a negative integer!");
		if (salary < 650) throw new ArgumentException("Salary cannot be less than 650 leva!");

		FirstName = firstName;
		LastName = lastName;
		Age = age;
		Salary = salary;
	}

	public string FirstName { get; set; }
	public string LastName { get; set; }
	public int Age { get; set; }
	public decimal Salary { get; set; }

	public void IncreaseSalary(decimal percentage)
	{
		if (this.Age > 30) this.Salary += this.Salary * percentage / 100;
		else this.Salary += this.Salary * percentage / 200;
	}

	public override string ToString() => $"{this.FirstName} {this.LastName} receives {this.Salary:F2} leva.";
}
