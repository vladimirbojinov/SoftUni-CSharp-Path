namespace _11._Math_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            string symbol = Console.ReadLine();
            int num2 = int.Parse(Console.ReadLine());

            Calculate(num1, num2, symbol);
        }

        static void Calculate(int num1, int num2, string operation)
        {
            switch (operation)
            {
                case "+": Console.WriteLine(num1 + num2); break;
                case "-": Console.WriteLine(num1 - num2); break;
                case "*": Console.WriteLine(num1 * num2); break;
                case "/": Console.WriteLine(num1 / num2); break;
            }
        }
    }
}