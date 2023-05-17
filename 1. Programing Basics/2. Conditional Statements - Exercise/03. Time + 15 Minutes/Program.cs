namespace _03._Time___15_Minutes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            int after = minutes + 15;
            int afterSix = after % 60;
            int hourSix = hours + 1;

            if (hourSix >= 24)
            {
                hourSix = 0;
            }

            if (after >= 60)
            {
                if (afterSix >= 10)
                {
                    Console.WriteLine($"{hourSix}:{afterSix}");
                }
                else
                {
                    Console.WriteLine($"{hourSix}:0{afterSix}");
                }
            }
            else
            {
                minutes += 15;

                Console.WriteLine($"{hours}:{minutes}");
            }
        }
    }
}