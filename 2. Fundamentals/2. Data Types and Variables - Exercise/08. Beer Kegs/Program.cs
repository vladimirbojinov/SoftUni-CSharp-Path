namespace _08._Beer_Kegs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int loops = int.Parse(Console.ReadLine());

            string bestModel = "";
            double bestKeg = 0;

            for (int i = 0; i < loops; i++)
            {
                string model = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                int hight = int.Parse(Console.ReadLine());

                double volume = Math.PI * Math.Pow(radius, 2) * hight;

                if (bestKeg < volume)
                {
                    bestModel = model;
                    bestKeg = volume;
                }
            }

            Console.WriteLine(bestModel);
        }
    }
}