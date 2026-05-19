namespace _04.BorderControl;

public class Person : IIdentifiable
{
	public Person(string id, string name, int age)
	{
		Id = id;
		Name = name;
		Age = age;
	}

	public string Id { get; }
	public string Name { get; }
	public int Age { get; }
}
