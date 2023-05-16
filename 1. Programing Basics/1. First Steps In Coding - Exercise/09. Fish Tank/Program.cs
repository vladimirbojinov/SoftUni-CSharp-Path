namespace _09._Fish_Tank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //input
            int lengInCm = int.Parse(Console.ReadLine());
            int widthInCm = int.Parse(Console.ReadLine());
            int hightInCm = int.Parse(Console.ReadLine());
            double percent = double.Parse(Console.ReadLine());
            //calculations
            double volume = lengInCm * widthInCm * hightInCm;
            double volumeInLiters = volume / 1000;
            double percentInNumber = percent / 100;
            double neededLeters = volumeInLiters * (1 - percentInNumber);
            //output
            Console.WriteLine(neededLeters);
        }
    }
}