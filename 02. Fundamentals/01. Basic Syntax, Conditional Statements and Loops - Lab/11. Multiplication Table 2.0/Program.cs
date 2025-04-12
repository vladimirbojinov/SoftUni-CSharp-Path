namespace _11._Multiplication_Table_2._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int startIndex = int.Parse(Console.ReadLine());

            if (startIndex > 10)
            {
                Console.WriteLine($"{num} X {startIndex} = {num * startIndex}");
            }

            for (int i = startIndex; i <= 10; i++)
            {
                Console.WriteLine($"{num} X {i} = {num * i}");
            }
        }
    }
}