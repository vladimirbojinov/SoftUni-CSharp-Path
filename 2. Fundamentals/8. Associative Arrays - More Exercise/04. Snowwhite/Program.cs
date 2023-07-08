using System.Xml.Linq;

namespace _04._Snowwhite
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Dwarf> dwarfList = new List<Dwarf>();

            string command;
            while ((command = Console.ReadLine()) != "Once upon a time")
            {
                string[] arguments = command.Split(" <:> ");
                string dwarfName = arguments[0];
                string hatColor = arguments[1];
                int physics = int.Parse(arguments[2]);


                Dwarf sameNameDwarf = dwarfList.FirstOrDefault(x => x.Name == dwarfName);
                Dwarf sameColorNameDwarf = dwarfList.Find(x => x.Name == dwarfName && x.HatColor == hatColor);

                if (sameNameDwarf != null && sameNameDwarf.HatColor != hatColor)
                {
                    Dwarf dwarf = new Dwarf(dwarfName, hatColor, physics);
                    dwarfList.Add(dwarf);
                }

                if (sameColorNameDwarf != null)
                {
                    sameColorNameDwarf.Update(physics);
                }

                if (sameNameDwarf == null && sameColorNameDwarf == null)
                {
                    Dwarf dwarf = new Dwarf(dwarfName, hatColor, physics);
                    dwarfList.Add(dwarf);
                }
            }

            dwarfList = dwarfList.OrderByDescending(x => x.Physics).ToList();
            Dictionary<string, List<Dwarf>> dwarfDictionary = new Dictionary<string, List<Dwarf>>();
            foreach (Dwarf dwarf in dwarfList)
            {
                string hatColor = dwarf.HatColor;
                if (!dwarfDictionary.ContainsKey(hatColor))
                {
                    dwarfDictionary.Add(hatColor, new List<Dwarf>());
                    dwarfDictionary[hatColor].Add(dwarf);
                }
                else
                {
                    dwarfDictionary[hatColor].Add(dwarf);
                }
            }

            var sortedDictionary = dwarfDictionary.OrderByDescending(x => x.Value.Count);
            foreach (var kvp in sortedDictionary)
            {
                foreach (Dwarf dwarf in kvp.Value)
                {
                    Console.WriteLine($"({dwarf.HatColor}) {dwarf.Name} <-> {dwarf.Physics}");
                }
            }
        }
    }

    class Dwarf
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