namespace DefiningClasses;

public class Family
{
	public List<Person> FamilyMembers { get; set; } = new List<Person>();

	public void AddMember(Person person)
	{
		FamilyMembers.Add(person);
	}

	public Person GetOldestMember() => FamilyMembers.MaxBy(x => x.Age);
}
