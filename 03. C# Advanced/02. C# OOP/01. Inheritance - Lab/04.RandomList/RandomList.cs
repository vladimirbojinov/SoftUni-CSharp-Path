namespace CustomRandomList;

public class RandomList
{
	public RandomList()
	{
		List = new List<string>();
	}

	public List<string> List { get; set; }

	public void Add(string value)
	{
		List.Add(value);
	}

	public string RandomString()
	{
		Random random = new Random();
		int rnd = random.Next(0, List.Count);

		string removedValue = this.List[rnd];
		this.List.RemoveAt(rnd);

		return removedValue;
	}
}
