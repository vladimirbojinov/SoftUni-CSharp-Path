namespace _05._Add_and_Subtract
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
			int num3 = int.Parse(Console.ReadLine());

			int sum = SumTwoDigits(num1, num2);
            Subtract(sum, num3);
        }

        static void Subtract(int total, int num3)
        {
            Console.WriteLine(total -= num3);
        }

        static int SumTwoDigits(int num1, int num2)
        {
            int sum = num1 + num2;

            return sum;
        }
    }
}