namespace _01._Smallest_of_Three_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int minNumber = 0;

            minNumber = SmallestNumber();

            Console.WriteLine(minNumber);
        }

        static int SmallestNumber()
        {
            int min = int.MaxValue;
            int number = 0;

            for (int j = 0; j < 3; j++)
            {
                number = int.Parse(Console.ReadLine());

                if (min > number)
                {
                    min = number;
                }
            }

            return min;
        }
    }
}