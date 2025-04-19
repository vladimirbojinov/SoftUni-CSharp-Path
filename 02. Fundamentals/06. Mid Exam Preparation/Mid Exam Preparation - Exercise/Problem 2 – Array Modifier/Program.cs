namespace Problem_2___Array_Modifier
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
                string[] arguments = command.Split();
                switch (arguments[0])
                {
                    case "swap": numbers = SwapCommand(numbers, int.Parse(arguments[1]), int.Parse(arguments[2])); break;
                    case "multiply": numbers = MultiplyCommand(numbers, int.Parse(arguments[1]), int.Parse(arguments[2])); break;
                    case "decrease": numbers = DecreaseCommand(numbers); break;
                }
            }

            Console.WriteLine(string.Join(", ", numbers));
        }

        static List<int> SwapCommand(List<int> numbers, int index1, int index2)
        {
            int temp = numbers[index1];
            numbers[index1] = numbers[index2];
            numbers[index2] = temp;

            return numbers;
        }
        static List<int> MultiplyCommand(List<int> numbers, int index1, int index2)
        {
            numbers[index1] = numbers[index1] * numbers[index2];

            return numbers;
        }
        static List<int> DecreaseCommand(List<int> numbers)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                numbers[i] -= 1;
            }

            return numbers;
        }
    }
}