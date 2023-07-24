namespace _05._Easter_Eggs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numOfEggs = int.Parse(Console.ReadLine());

            int redEggs = 0;
            int orangeEggs = 0;
            int blueEggs = 0;
            int greenEggs = 0;

            int MaxEgg = int.MinValue;
            string color = "";

            for (int i = 0; i < numOfEggs; i++)
            {
                string eggColor = Console.ReadLine();

                switch (eggColor)
                {
                    case "red":
                        redEggs++;
                        if (MaxEgg < redEggs)
                        {
                            MaxEgg = redEggs;
                            color = "red";
                        }
                        break;
                    case "orange":
                        orangeEggs++;
                        if (MaxEgg < orangeEggs)
                        {
                            MaxEgg = orangeEggs;
                            color = "orange";
                        }
                        ; break;
                    case "blue":
                        blueEggs++;
                        if (MaxEgg < blueEggs)
                        {
                            MaxEgg = blueEggs;
                            color = "blue";
                        }
                        ; break;
                    case "green":
                        greenEggs++;
                        if (MaxEgg < greenEggs)
                        {
                            MaxEgg = greenEggs;
                            color = "green";
                        }
                        ; break;
                }
            }

            Console.WriteLine($"Red eggs: {redEggs}");
            Console.WriteLine($"Orange eggs: {orangeEggs}");
            Console.WriteLine($"Blue eggs: {blueEggs}");
            Console.WriteLine($"Green eggs: {greenEggs}");
            Console.WriteLine($"Max eggs: {MaxEgg} -> {color}");
        }
    }
}