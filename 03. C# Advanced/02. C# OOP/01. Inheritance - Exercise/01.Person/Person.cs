namespace Person;

public class Person
{
	private readonly string name;
	private readonly int age;

	public Person(string name, int age)
	{
		this.name = name;
		this.age = age;
	}

	public string Name => this.name;
	public int Age => this.age;

	public override string ToString()
	{
		return $"{GetType().Name} -> Name: {this.name}, Age: {this.age}";
	}
}
