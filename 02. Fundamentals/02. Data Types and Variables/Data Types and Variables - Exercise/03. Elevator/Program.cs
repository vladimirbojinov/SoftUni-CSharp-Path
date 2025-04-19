namespace _03._Elevator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double num = int.Parse(Console.ReadLine());
			double people = int.Parse(Console.ReadLine());

            double courses = Math.Ceiling(num / people);

            Console.WriteLine(courses);
        }
    }
}