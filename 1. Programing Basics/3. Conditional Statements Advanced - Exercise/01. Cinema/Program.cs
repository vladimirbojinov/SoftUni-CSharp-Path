namespace _01._Cinema
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string projection = Console.ReadLine();
            int rows = int.Parse(Console.ReadLine());
            int columns = int.Parse(Console.ReadLine());

            int numOfPpl = rows * columns;
            double finalSum = 0;

            switch (projection)
            {
                case "Premiere": finalSum = numOfPpl * 12; break;
                case "Normal": finalSum = numOfPpl * 7.5; break;
                case "Discount": finalSum = numOfPpl * 5; break;
            }

            Console.WriteLine($"{finalSum:f2} leva");
        }
    }
}