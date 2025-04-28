namespace _03._House_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int commandCount = int.Parse(Console.ReadLine());
            List<string> partyList = new List<string>();

            for (int i = 0; i < commandCount; i++)
            {
                string[] arguments = Console.ReadLine().Split();

                if (arguments[2] == "not")
                {
                    partyList = NotComingCommand(partyList, arguments[0]);
                }
                else
                {
                    partyList = IsComingCommand(partyList, arguments[0]);
                }
            }

			Console.WriteLine(string.Join("\n", partyList));
        }

        static List<string> IsComingCommand(List<string> partyList, string name)
        {
            if (partyList.Contains(name))
            {
                Console.WriteLine($"{name} is already in the list!");
                return partyList;
            }

            partyList.Add(name);
            return partyList;
        }

        static List<string> NotComingCommand(List<string> partyList, string name)
        {
            if (!partyList.Contains(name))
            {
                Console.WriteLine($"{name} is not in the list!");
                return partyList;
            }

            partyList.Remove(name);
            return partyList;
        }
    }
}