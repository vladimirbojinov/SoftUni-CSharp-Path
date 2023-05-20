namespace _03._Floating_Equality
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double double1 = double.Parse(Console.ReadLine());
            double double2 = double.Parse(Console.ReadLine());
            double tolerance = 0.0001;


            bool isEquel = Math.Abs(double1 - double2) <= tolerance;

            if (isEquel)
            {
                Console.WriteLine(true);
            }
            else
            {
                Console.WriteLine(false);
            }
        }
    }
}