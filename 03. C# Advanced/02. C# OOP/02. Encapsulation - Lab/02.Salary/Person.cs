namespace PersonsInfo;

public class Person
{
	public Person(string firstName, string lastName, int age, decimal salary)
	{
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

	public override string ToString()
	{
		return $"{this.FirstName} {this.LastName} receives {this.Salary:F2} leva.";
	}
}
