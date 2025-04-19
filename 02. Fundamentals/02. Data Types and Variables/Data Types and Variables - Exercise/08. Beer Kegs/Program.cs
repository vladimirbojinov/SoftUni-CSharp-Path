namespace _08._Beer_Kegs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int loops = int.Parse(Console.ReadLine());

            string bestKegModel = string.Empty;
            double bestKegVolume = 0;

            for (int i = 0; i < loops; i++)
            {
                string model = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                int high = int.Parse(Console.ReadLine());

                double volume = Math.PI * Math.Pow(radius, 2) * high;

                if (bestKegVolume < volume)
                {
                    bestKegModel = model;
                    bestKegVolume = volume;
                }
            }

            Console.WriteLine(bestKegModel);
        }
    }
}