namespace _08._Town_Info
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string city = Console.ReadLine();
            int population = int.Parse(Console.ReadLine());
            int size = int.Parse(Console.ReadLine());

            Console.WriteLine($"Town {city} has population of {population} and area {size} square km.");
        }
    }
}