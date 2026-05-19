namespace _03.Cards;

internal class Program
{
	static void Main(string[] args)
	{
		List<Card> cards = new();
		string[] cardsData = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

		foreach (string card in cardsData)
		{
			try
			{
				AddCard(cards, card);
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}

		Console.WriteLine(string.Join(", ", cards));
	}

	private static void AddCard(List<Card> cards, string card)
	{
		string[] cardData = card.Split(" ", StringSplitOptions.RemoveEmptyEntries);
		string cardFace = cardData[0];
		string cardSuit = cardData[1];

		Card cardObject = new Card(cardFace, cardSuit);
		cards.Add(cardObject);
	}
}
