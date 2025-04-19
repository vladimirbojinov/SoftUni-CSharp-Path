namespace _05._Add_and_Subtract
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n1 = int.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());

            int total = Sum2Digits(n1, n2);
            Subtract(total);
        }

        static void Subtract(int total)
        {
            int n3 = int.Parse(Console.ReadLine());

            Console.WriteLine(total -= n3);
        }

        static int Sum2Digits(int n1, int n2)
        {
            int sum = n1 + n2;

            return sum;
        }
    }
}