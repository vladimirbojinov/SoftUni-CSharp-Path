
namespace _07._Bomb_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            int[] bombPower = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int bomb = bombPower[0];
            int power = bombPower[1];
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] == bomb)
                {
                    int index = numbers.IndexOf(bomb);
                    int remove = power;
                    if (index + power >= numbers.Count)
                    {
                        remove = (index + power) - numbers.Count;
                    }
                    int startIndex = index - power;
                    if (startIndex < 0)
                    {
                        startIndex = 0;
                    }
                    numbers.RemoveRange(startIndex, power + remove + 1);
                    i = -1;
                }
            }
            Console.WriteLine(numbers.Sum());
        }
    }
}