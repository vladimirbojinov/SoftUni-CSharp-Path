namespace _07._List_Manipulation_Advanced
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            bool isListChanged = false;

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] arguments = command.Split();
                switch (arguments[0])
                {
                    case "Contains": ContainsCommand(numbers, int.Parse(arguments[1])); break;
                    case "PrintEven": PrintEvenCommand(numbers); break;
                    case "PrintOdd": PrintOddCommand(numbers); break;
                    case "GetSum": GetSumCommand(numbers); break;
                    case "Filter": FilterCommand(numbers, arguments[1].ToString(), int.Parse(arguments[2])); break;
                    case "Add": 
                        numbers = AddCommand(numbers, int.Parse(arguments[1]));
                        isListChanged = true; break;
                    case "Remove": 
                        numbers = RemoveCommand(numbers, int.Parse(arguments[1]));
                        isListChanged = true; break;
                    case "RemoveAt": 
                        numbers = RemoveIndexCommand(numbers, int.Parse(arguments[1]));
                        isListChanged = true; break;
                    case "Insert": 
                        numbers = InsertCommand(numbers, int.Parse(arguments[1]), int.Parse(arguments[2]));
                        isListChanged = true; break;
                }
            }

            if (isListChanged)
            {
                Console.WriteLine(string.Join(" ", numbers));
            }
        }

        static void ContainsCommand(List<int> numberList, int number)
        {
            if (numberList.Contains(number))
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No such number");
            }
        }

        static void PrintEvenCommand(List<int> numberList)
        {
            for (int i = 0; i < numberList.Count; i++)
            {
                if (numberList[i] % 2 == 0)
                {
                    Console.Write(numberList[i] + " ");
                }
            }

            Console.WriteLine();
        }

        static void PrintOddCommand(List<int> numberList)
        {
            for (int i = 0; i < numberList.Count; i++)
            {
                if (numberList[i] % 2 != 0)
                {
                    Console.Write(numberList[i] + " ");
                }
            }

            Console.WriteLine();
        }

        static void GetSumCommand(List<int> numberList)
        {
            int sum = 0;

            for (int i = 0; i < numberList.Count; i++)
            {
                sum += numberList[i];
            }

            Console.WriteLine(sum);
        }

        static void FilterCommand(List<int> numberList, string condition, int number)
        {
            if (condition == "<")
            {
				for (int i = 0; i < numberList.Count; i++)
				{
					if (numberList[i] < number)
					{
						Console.Write(numberList[i] + " ");
					}
				}
			}
            else if (condition == ">")
            {
				for (int i = 0; i < numberList.Count; i++)
				{
					if (numberList[i] > number)
					{
						Console.Write(numberList[i] + " ");
					}
				}
			}
            else if (condition == ">=")
            {
				for (int i = 0; i < numberList.Count; i++)
				{
					if (numberList[i] >= number)
					{
						Console.Write(numberList[i] + " ");
					}
				}
			}
            else if (condition == "<=")
            {
				for (int i = 0; i < numberList.Count; i++)
				{
					if (numberList[i] <= number)
					{
						Console.Write(numberList[i] + " ");
					}
				}
			}

			Console.WriteLine();
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