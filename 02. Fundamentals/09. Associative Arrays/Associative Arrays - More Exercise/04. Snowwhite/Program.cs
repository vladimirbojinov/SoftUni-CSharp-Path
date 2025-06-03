namespace _04._Snowwhite
{
	internal class Program
	{
		static void Main(string[] args)
		{
			List<Dwarf> dwarfs = new List<Dwarf>();

			string command;
			while ((command = Console.ReadLine()) != "Once upon a time")
			{
				string[] arguments = command.Split(" <:> ");
				string name = arguments[0];
				string hatColor = arguments[1];
				int physics = int.Parse(arguments[2]);

				Dwarf matchedDwarf = dwarfs.FirstOrDefault(d => d.Name == name && d.HatColor == hatColor);
				if (matchedDwarf == null)
				{
					Dwarf dwarf = new Dwarf(name, hatColor, physics);
					dwarfs.Add(dwarf);
				}
				else
				{
					if (matchedDwarf.Physics < physics)
					{
						matchedDwarf.Update(physics);
					}
				}
			}

			List<Dwarf> sortedDwarfs = dwarfs
				.OrderByDescending(d => d.Physics)
				.ThenByDescending(x => dwarfs.Count(y => y.HatColor == x.HatColor))
				.ToList();

			Console.WriteLine(string.Join("\n", sortedDwarfs));
		}
	}

	public class Dwarf
	{
		public Dwarf(string name, string hatColor, int physics)
		{
			Name = name;
			HatColor = hatColor;
			Physics = physics;
		}

		public string Name { get; set; }
		public string HatColor { get; set; }
		public int Physics { get; set; }

		public void Update(int physics)
		{
			Physics = physics;
		}

		public override string ToString()
		{
			return $"({HatColor}) {Name} <-> {Physics}";
		}
	}
}