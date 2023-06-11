namespace _04._List_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbersList = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] arguments = command.Split();

                switch (arguments[0])
                {
                    case "Add": numbersList = AddCommand(numbersList, int.Parse(arguments[1])); break;
                    case "Insert": numbersList = InsertCommand(numbersList, int.Parse(arguments[1]), int.Parse(arguments[2])); break;
                    case "Remove": numbersList = RemoveCommand(numbersList, int.Parse(arguments[1])); break;
                    case "Shift":
                        switch (arguments[1])
                        {
                            case "left": numbersList = ShiftLeftCommand(numbersList, int.Parse(arguments[2])); break;
                            case "right": numbersList = ShiftRightCommand(numbersList, int.Parse(arguments[2])); break;
                        }
                        break;

                }
            }

            Console.WriteLine(string.Join(" ", numbersList));
        }

        static List<int> AddCommand(List<int> numbersList, int number)
        {
            numbersList.Add(number);

            return numbersList;
        }
        static List<int> InsertCommand(List<int> numbersList, int number, int index)
        {
            if (IsIndexCorrect(numbersList, index))
            {
                numbersList.Insert(index, number);
            }

            return numbersList;
        }
        static List<int> RemoveCommand(List<int> numbersList, int index)
        {
            if (IsIndexCorrect(numbersList, index))
            {
                numbersList.RemoveAt(index);
            }

            return numbersList;
        }
        static List<int> ShiftLeftCommand(List<int> numbersList, int count)
        {
            for (int i = 0; i < count; i++)
            {
                int first = numbersList[0];
                numbersList.Add(first);
                numbersList.RemoveAt(0);
            }

            return numbersList;
        }
        static List<int> ShiftRightCommand(List<int> numbersList, int count)
        {
            for (int i = 0; i < count; i++)
            {
                int last = numbersList[numbersList.Count - 1];
                numbersList.Insert(0, last);
                numbersList.RemoveAt(numbersList.Count - 1);
            }

            return numbersList;
        }
        static bool IsIndexCorrect(List<int> numbersList, int index)
        {
            if (index >= 0 && index < numbersList.Count)
            {
                return true;
            }

            Console.WriteLine("Invalid index");
            return false;
        }
    }
}