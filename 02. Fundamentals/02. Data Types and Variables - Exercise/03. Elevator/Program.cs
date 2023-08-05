namespace _03._Elevator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int people = int.Parse(Console.ReadLine());

            int courses = 0;

            while (num > 0)
            {
                courses++;
                num -= people;
            }

            Console.WriteLine(courses);
        }
    }
}