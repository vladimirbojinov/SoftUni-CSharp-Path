namespace Problem_2___Array_Modifier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

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

        static int[] SwapCommand(int[] numbers, int index1, int index2)
        {
            int temp = numbers[index1];
            numbers[index1] = numbers[index2];
            numbers[index2] = temp;

            return numbers;
        }

        static int[] MultiplyCommand(int[] numbers, int index1, int index2)
        {
            numbers[index1] = numbers[index1] * numbers[index2];

            return numbers;
        }

        static int[] DecreaseCommand(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] -= 1;
            }

            return numbers;
        }
    }
}