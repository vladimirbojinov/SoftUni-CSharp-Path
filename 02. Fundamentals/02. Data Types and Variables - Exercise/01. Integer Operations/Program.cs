namespace _01._Integer_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());

            int sum = num1 + num2;

            int num3 = int.Parse(Console.ReadLine());

            sum /= num3;

            int num4 = int.Parse(Console.ReadLine());

            sum *= num4;

            Console.WriteLine(sum);
        }
    }
}