using System.Diagnostics.CodeAnalysis;

namespace _06._Cards_Game
{
    /*
20 30 40 50
10 20 30 40
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> p1Deck = Console.ReadLine().Split().Select(int.Parse).ToList();

            List<int> p2Deck = Console.ReadLine().Split().Select(int.Parse).ToList();

            while (p1Deck.Count > 0 && p2Deck.Count > 0)
            {
                int p1Card = p1Deck[0];
                int p2Card = p2Deck[0];

                if (p1Card == p2Card)
                {
                    p1Deck.RemoveAt(0);
                    p2Deck.RemoveAt(0);
                }
                else if (p1Card > p2Card)
                {
                    int firstCard = p1Deck[0];

                    p1Deck.RemoveAt(0);
                    p1Deck.Add(firstCard);
                    p1Deck.Add(p2Deck[0]);
                    p2Deck.RemoveAt(0);
                }
                else
                {
                    int firstCard = p2Deck[0];

                    p2Deck.RemoveAt(0);
                    p2Deck.Add(firstCard);
                    p2Deck.Add(p1Deck[0]);
                    p1Deck.RemoveAt(0);
                }
            }

            if (p1Deck.Count > 0)
            {
                int sum = WiningDeckSum(p1Deck);
                Console.WriteLine($"First player wins! Sum: {sum}");
            }
            else
            {
                int sum = WiningDeckSum(p2Deck);
                Console.WriteLine($"Second player wins! Sum: {sum}");
            }
        }

        private static int WiningDeckSum(List<int> deck)
        {
            int sum = 0;

            for (int i = 0; i < deck.Count; i++)
            {
                sum += deck[i];
            }

            return sum;
        }
    }
}