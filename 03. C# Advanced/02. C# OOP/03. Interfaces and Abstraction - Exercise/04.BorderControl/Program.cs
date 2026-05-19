namespace _04.BorderControl;

public class StartUp
{
	static void Main(string[] args)
	{
		List<IIdentifiable> entities = FillIdentifiable();

		string searchedIdNumber = Console.ReadLine();
		foreach (IIdentifiable identifiable in entities)
		{
			string currentId = identifiable.Id;
			if (currentId.EndsWith(searchedIdNumber)) Console.WriteLine(currentId);
		}
	}

	private static List<IIdentifiable> FillIdentifiable()
	{
		List<IIdentifiable> entities = new List<IIdentifiable>();

		string command;
		while ((command = Console.ReadLine()) != "End")
		{
			string[] data = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

			if (data.Length == 3)
			{
				string name = data[0];
				int age = int.Parse(data[1]);
				string id = data[2];

				Person person = new Person(id, name, age);
				entities.Add(person);
			}
			else if (data.Length == 2)
			{
				string model = data[0];
				string id = data[1];

				Robot robot = new Robot(id, model);
				entities.Add(robot);
			}
		}

		return entities;
	}
}
