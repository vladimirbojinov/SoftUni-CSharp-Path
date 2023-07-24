namespace _04._Inches_to_Centimeters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //input
            double intch = double.Parse(Console.ReadLine());
            double centimeters = 2.54;
            //calculation
            double calculations = intch * centimeters;
            //output
            Console.WriteLine(calculations);
        }
    }
}