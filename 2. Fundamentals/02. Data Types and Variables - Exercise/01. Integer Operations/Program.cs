namespace _01._Integer_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;

            int n1 = int.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());

            sum = n1 + n2;

            int n3 = int.Parse(Console.ReadLine());

            sum /= n3;

            int n4 = int.Parse(Console.ReadLine());

            sum *= n4;

            Console.WriteLine(sum);
        }
    }
}