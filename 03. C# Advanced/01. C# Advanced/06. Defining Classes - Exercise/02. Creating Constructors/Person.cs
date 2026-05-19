namespace DefiningClasses;

public class Person
{
	private string name;
	private int age;

	public Person() : this("No name", 1) { }

	public Person(int age) : this("No name", age) { }

	public Person(string name, int age)
	{
		Name = name;
		Age = age;
	}

	public string Name { get; set; }
	public int Age { get; set; }
}
