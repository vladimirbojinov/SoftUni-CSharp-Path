namespace _06._Unique_PIN_Codes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            int a = 0;

            for (int i = 1; i <= num1; i++)
            {
                if (i % 2 == 0)
                {
                    for (int y = 1; y <= num2; y++)
                    {
                        for (int x = 1; x <= y; x++)
                        {
                            if (y % x == 0)
                            {
                                a++;
                            }
                        }

                        if (a == 2)
                        {
                            for (int z = 1; z <= num3; z++)
                            {
                                if (z % 2 == 0)
                                {
                                    Console.WriteLine($"{i} {y} {z}");
                                }
                            }
                        }

                        a = 0;
                    }
                }
            }
        }
    }
}