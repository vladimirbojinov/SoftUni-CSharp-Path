namespace _06._List_Manipulation_Basics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] argument = command.Split();
                switch (argument[0])
                {
                    case "Add": numbers = AddCommand(numbers, int.Parse(argument[1])); break;
                    case "Remove": numbers = RemoveCommand(numbers, int.Parse(argument[1])); break;
                    case "RemoveAt": numbers = RemoveIndexCommand(numbers, int.Parse(argument[1])); break;
                    case "Insert": numbers = InsertCommand(numbers, int.Parse(argument[1]), int.Parse(argument[2])); break;
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }

        static List<int> AddCommand(List<int> numbersList, int number)
        {
            List<int> changedList = numbersList;

            changedList.Add(number);

            return changedList;
        }
        static List<int> RemoveCommand(List<int> numbersList, int number)
        {
            List<int> changedList = numbersList;

            changedList.Remove(number);

            return changedList;
        }
        static List<int> RemoveIndexCommand(List<int> numbersList, int index)
        {
            List<int> changedList = numbersList;

            changedList.RemoveAt(index);

            return changedList;
        }
        static List<int> InsertCommand(List<int> numbersList, int number, int index)
        {
            List<int> changedList = numbersList;

            changedList.Insert(index, number);

            return changedList;
        }
    }
}