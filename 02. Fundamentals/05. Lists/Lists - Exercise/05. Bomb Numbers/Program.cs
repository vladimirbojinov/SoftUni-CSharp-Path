namespace _05._Bomb_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            List<int> bombAndBombRange = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            numbers = BombDetonation(numbers, bombAndBombRange);

            SumOfList(numbers);
        }


        static List<int> BombDetonation(List<int> numberList, List<int> bombAndBombRange)
        {
            int bomb = bombAndBombRange[0];
            int bombRange = bombAndBombRange[1];

            while (numberList.Contains(bomb))
            {
                int indexOfBomb = numberList.IndexOf(bomb);

                int leftExplosion = Math.Max(0, indexOfBomb - bombRange);
                int rightExplosion = Math.Min(numberList.Count - 1, indexOfBomb + bombRange);

                int range = rightExplosion - leftExplosion + 1;

                numberList.RemoveRange(leftExplosion, range);
            }

            return numberList;
        }
        static void SumOfList(List<int> numberList)
        {
            int sum = 0;

            for (int i = 0; i < numberList.Count; i++)
            {
                sum += numberList[i];
            }

            Console.WriteLine(sum);
        }

    }
}