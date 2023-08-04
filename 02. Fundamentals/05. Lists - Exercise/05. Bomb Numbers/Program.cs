namespace _05._Bomb_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numberList = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            List<int> bombAndBombRange = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            numberList = BombDetonation(numberList, bombAndBombRange);

            SumOfList(numberList);
        }


        static List<int> BombDetonation(List<int> numberList, List<int> bombAndBombRange)
        {
            int bomb = bombAndBombRange[0];
            int bombRange = bombAndBombRange[1];

            while (numberList.Contains(bomb))
            {
                int indexOfBomb = numberList.IndexOf(bomb);

                int leftExplosion = Math.Max(0, indexOfBomb - bombRange);
                int righExplosion = Math.Min(numberList.Count - 1, indexOfBomb + bombRange);

                int range = righExplosion - leftExplosion + 1;

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