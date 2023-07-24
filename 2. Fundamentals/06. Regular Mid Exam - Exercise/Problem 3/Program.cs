namespace Problem_3
{
    /*
Ace of Diamonds, Queen of Hearts, King of Clubs 
3
Add, King of Diamonds
Insert, 2, Jack of Spades
Remove, Ace of Diamonds
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> cardsList = Console.ReadLine()
                .Split(", ")
                .ToList();

            int loops = int.Parse(Console.ReadLine());
            for (int i = 0; i < loops; i++)
            {
                string[] arguments = Console.ReadLine().Split(", ");
                switch (arguments[0])
                {
                    case "Add": cardsList = AddCard(cardsList, arguments[1]); break;
                    case "Remove": cardsList = RemoveCard(cardsList, arguments[1]); break;
                    case "Remove At": cardsList = RemoveAtCard(cardsList, int.Parse(arguments[1])); break;
                    case "Insert": cardsList = InsertCard(cardsList, int.Parse(arguments[1]), arguments[2]); break;
                }
            }

            Console.WriteLine(string.Join(", ", cardsList));
        }

        private static List<string> InsertCard(List<string> cardList, int index, string card)
        {
            if (IsInRange(cardList, index))
            {
                if (cardList.Contains(card))
                {
                    Console.WriteLine("Card is already added");
                }
                else
                {
                    cardList.Insert(index, card);
                    Console.WriteLine("Card successfully added");
                }
            }
            else
            {
                Console.WriteLine("Index out of range");
            }

            return cardList;
        }
        private static List<string> RemoveAtCard(List<string> cardsList, int index)
        {
            if (IsInRange(cardsList, index))
            {
                cardsList.RemoveAt(index);
                Console.WriteLine("Card successfully removed");
            }
            else
            {
                Console.WriteLine("Index out of range");
            }

            return cardsList;
        }
        private static bool IsInRange(List<string> cardsList, int index)
        {
            if (index < 0 || index >= cardsList.Count)
            {
                return false;
            }

            return true;
        }
        private static List<string> RemoveCard(List<string> cardsList, string card)
        {
            if (cardsList.Contains(card))
            {
                cardsList.Remove(card);
                Console.WriteLine("Card successfully removed");
            }
            else
            {
                Console.WriteLine("Card not found");
            }

            return cardsList;
        }
        private static List<string> AddCard(List<string> cardsList, string card)
        {
            if (cardsList.Contains(card))
            {
                Console.WriteLine("Card is already in the deck");
            }
            else
            {
                cardsList.Add(card);
                Console.WriteLine("Card successfully added");
            }

            return cardsList;
        }
    }
}