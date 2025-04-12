using static System.Net.Mime.MediaTypeNames;

namespace _03._Treasure_Finder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] keys = Console.ReadLine().Split()
                .Select(int.Parse)
                .ToArray();

            string encryptedMessage;
            while ((encryptedMessage = Console.ReadLine()) != "find")
            {
                string decryptedMessage = string.Empty;
                int currentKey = 0;
                for (int i = 0; i < encryptedMessage.Length; i++)
                {
                    if (currentKey < keys.Length)
                    {
                        int letterNum = encryptedMessage[i] - keys[currentKey];
                        char decryptedLetter = (char)letterNum;
                        decryptedMessage += decryptedLetter;
                    }
                    else
                    {
                        currentKey = 0;
                        int letterNum = encryptedMessage[i] - keys[currentKey];
                        char decryptedLetter = (char)letterNum;
                        decryptedMessage += decryptedLetter;
                    }
                    currentKey++;
                }

                int lootStartIndex = (decryptedMessage.IndexOf('&')) + 1;
                int lootEndIndex = (decryptedMessage.LastIndexOf('&')) - lootStartIndex;

                int coordinateStartIndex = (decryptedMessage.IndexOf('<')) + 1;
                int coordinateEndIndex = (decryptedMessage.IndexOf('>')) - coordinateStartIndex;

                string loot = decryptedMessage.Substring(lootStartIndex, lootEndIndex);
                string coordinate = decryptedMessage.Substring(coordinateStartIndex, coordinateEndIndex);

                Console.WriteLine($"Found {loot} at {coordinate}");
                decryptedMessage = string.Empty;
            }
        }
    }
}