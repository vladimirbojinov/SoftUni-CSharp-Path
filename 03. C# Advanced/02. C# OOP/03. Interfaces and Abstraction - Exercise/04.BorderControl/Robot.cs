namespace _04.BorderControl;

internal class Robot : IIdentifiable
{
	public Robot(string id, string model)
	{
		Id = id;
		Model = model;
	}

	public string Id { get; }
	public string Model { get; set; }
}
