namespace _02._Radians_to_Degrees
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //input
            double angleInRadiant = double.Parse(Console.ReadLine());
            //calculations
            // Math.PI = 3.14 
            double angleInDegree = angleInRadiant * 180 / Math.PI;
            //output
            Console.WriteLine(angleInDegree);
        }
    }
}