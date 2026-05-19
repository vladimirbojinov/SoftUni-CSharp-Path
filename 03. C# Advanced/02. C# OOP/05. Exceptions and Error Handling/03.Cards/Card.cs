
namespace _03.Cards;

internal class Card
{
	private static Dictionary<string, string> cardSuits = new()
	{
		["S"] = "\u2660",
		["H"] = "\u2665",
		["D"] = "\u2666",
		["C"] = "\u2663",
	};

	public Card(string cardFace, string cardSuit)
	{
		if (IsCardValid(cardFace, cardSuit))
		{
			CardFace = cardFace;
			CardSuit = cardSuit;
		}
		else throw new ArgumentException("Invalid card!");
	}

	private bool IsCardValid(string cardFace, string cardSuit)
	{
		if (!cardSuits.ContainsKey(cardSuit)) return false;

		if (int.TryParse(cardFace, out int cardDigit)
			&& (cardDigit >= 2 && cardDigit <= 10))
		{
			return true;
		}

		if (cardFace is "J" or "Q" or "K" or "A") return true;

		return false;
	}

	public string CardFace { get; }
	public string CardSuit { get; }

	public override string ToString() => $"[{this.CardFace}{cardSuits[this.CardSuit]}]";
}
