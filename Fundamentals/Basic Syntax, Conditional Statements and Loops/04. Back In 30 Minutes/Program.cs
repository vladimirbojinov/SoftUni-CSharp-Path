namespace _04._Back_In_30_Minutes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int hh = int.Parse(Console.ReadLine());
            int mm = int.Parse(Console.ReadLine());

            mm += 30;

            if (mm >= 60)
            {
                hh++;
                mm = mm - 60;
            }
            if (hh >= 24)
            {
                hh = 0;
            }

            Console.WriteLine($"{hh}:{mm:d2}");
        }
    }
}