namespace _11._Math_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n1 = int.Parse(Console.ReadLine());
            string symbol = Console.ReadLine();
            int n2 = int.Parse(Console.ReadLine());

            Calculations(n1, n2, symbol);
        }

        static void Calculations(int n1, int n2, string operations)
        {
            switch (operations)
            {
                case "+": Console.WriteLine(n1 + n2); break;
                case "-": Console.WriteLine(n1 - n2); break;
                case "*": Console.WriteLine(n1 * n2); break;
                case "/": Console.WriteLine(n1 / n2); break;
            }
        }
    }
}