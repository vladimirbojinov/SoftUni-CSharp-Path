namespace _07._Projects_Creation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //input
            string name = Console.ReadLine();
            int numberOfProjects = int.Parse(Console.ReadLine());
            //calculations
            int hours = numberOfProjects * 3;
            //output
            Console.WriteLine($"The architect {name} will need {hours} hours to complete {numberOfProjects} project/s.");
        }
    }
}