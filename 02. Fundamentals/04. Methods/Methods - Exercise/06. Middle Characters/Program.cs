namespace _06._Middle_Characters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            char[] textArray = new char[text.Length];

            for (int i = 0; i < text.Length; i++)
            {
                char singleLetter = text[i];
                textArray[i] = singleLetter;
            }

            MiddleCharacterFinder(textArray);
        }

        static void MiddleCharacterFinder(char[] textArray)
        {
            int index = textArray.Length - 1;
            if (textArray.Length % 2 == 0)
            {
                Console.Write(textArray[index / 2]);
                Console.Write(textArray[(index / 2) + 1]);
            }
            else
            {
                Console.Write(textArray[index / 2]);
            }
        }
    }
}