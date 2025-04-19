namespace _07._Water_Overflow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int loops = int.Parse(Console.ReadLine());

            int currentCapacity = 0;

            for (int i = 0; i < loops; i++)
            {
                int pouredWater = int.Parse(Console.ReadLine());

                if (pouredWater + currentCapacity <= 255)
                {
                    currentCapacity += pouredWater;
                }
                else
                {
                    Console.WriteLine("Insufficient capacity!");
                }
            }

            Console.WriteLine(currentCapacity);
        }
    }
}