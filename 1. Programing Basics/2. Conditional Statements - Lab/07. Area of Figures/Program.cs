namespace _07._Area_of_Figures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string shape = Console.ReadLine();

            if (shape == "square")
            {
                double length = double.Parse(Console.ReadLine());

                double result = length * length;

                Console.WriteLine(result);
            }
            else if (shape == "rectangle")
            {
                double a = double.Parse(Console.ReadLine());
                double b = double.Parse(Console.ReadLine());

                double result = a * b;

                Console.WriteLine(result);
            }
            else if (shape == "circle")
            {
                double r = double.Parse(Console.ReadLine());

                double result = Math.PI * r * r;

                Console.WriteLine(result);
            }
            else if (shape == "triangle")
            {
                double a = double.Parse(Console.ReadLine());
                double ha = double.Parse(Console.ReadLine());

                double result = a * ha / 2;

                Console.WriteLine(result);
            }
        }
    }
}