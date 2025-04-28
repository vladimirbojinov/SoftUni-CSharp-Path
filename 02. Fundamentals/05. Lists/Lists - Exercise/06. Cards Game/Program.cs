namespace _06._Cards_Game
{
	internal class Program
    {
        static void Main(string[] args)
        {
            List<int> player1Deck = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> player2Deck = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            while (player1Deck.Count > 0 && player2Deck.Count > 0)
            {
                int player1Card = player1Deck[0];
                int player2Card = player2Deck[0];

                if (player1Card == player2Card)
                {
                    player1Deck.RemoveAt(0);
                    player2Deck.RemoveAt(0);
                }
                else if (player1Card > player2Card)
                {
                    int firstCard = player1Deck[0];

                    player1Deck.RemoveAt(0);
                    player1Deck.Add(firstCard);
                    player1Deck.Add(player2Deck[0]);
                    player2Deck.RemoveAt(0);
                }
                else
                {
                    int firstCard = player2Deck[0];

                    player2Deck.RemoveAt(0);
                    player2Deck.Add(firstCard);
                    player2Deck.Add(player1Deck[0]);
                    player1Deck.RemoveAt(0);
                }
            }

            if (player1Deck.Count > 0)
            {
                int sum = WiningDeckSum(player1Deck);
                Console.WriteLine($"First player wins! Sum: {sum}");
            }
            else
            {
                int sum = WiningDeckSum(player2Deck);
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