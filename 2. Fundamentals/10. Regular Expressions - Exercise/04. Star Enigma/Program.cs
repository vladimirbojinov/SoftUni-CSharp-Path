using System.Numerics;
using System.Text.RegularExpressions;

namespace _04._Star_Enigma
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> decryptedMessages = new List<string>();

            int messageCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < messageCount; i++)
            {
                string decryptedMessage = string.Empty;
                string encryptedMessage = Console.ReadLine();

                int subtract = NumberOfSubtractions(encryptedMessage);

                for (int k = 0; k < encryptedMessage.Length; k++)
                {
                    int numberOfLetter = encryptedMessage[k] - subtract;
                    decryptedMessage += (char)numberOfLetter;
                }

                decryptedMessages.Add(decryptedMessage);
            }

            List<string> attackedPlanets = new List<string>();
            List<string> destroyedPlanets = new List<string>();

            string pattern = @"@(?<planetName>[A-Z][a-z]+)(?:\w|[!-/:-@[-`{-~])*?:(?<population>\d+)(?:\w|[!-/:-@[-`{-~])*?!(?<attackType>[AD])!(?:\w|[!-/:-@[-`{-~])*?->(?:\w|[!-/:-@[-`{-~])*?(?<soldierCount>\d+)(?:\w|[!-/:-@[-`{-~])*?";
            Regex regex = new Regex(pattern);

            foreach (string message in decryptedMessages)
            {
                Match match = regex.Match(message);
                if (match.Success)
                {
                    string planetName = match.Groups[1].Value;
                    string attackType = match.Groups[3].Value;

                    if (attackType == "A")
                    {
                        attackedPlanets.Add(planetName);
                    }
                    else if (attackType == "D")
                    {
                        destroyedPlanets.Add(planetName);
                    }
                }
            }

            attackedPlanets = attackedPlanets.OrderBy(x => x).ToList();
            destroyedPlanets = destroyedPlanets.OrderBy(x => x).ToList();

            Console.WriteLine($"Attacked planets: {attackedPlanets.Count}");
            foreach (string planet in attackedPlanets)
            {
                Console.WriteLine($"-> {planet}");
            }

            Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");
            foreach (string planet in destroyedPlanets)
            {
                Console.WriteLine($"-> {planet}");
            }
        }

        static int NumberOfSubtractions(string encryptedMessage)
        {
            int subtract = 0;

            for (int i = 0; i < encryptedMessage.Length; i++)
            {
                switch (encryptedMessage[i])
                {
                    case 'S':
                    case 's':
                    case 'T':
                    case 't':
                    case 'A':
                    case 'a':
                    case 'R':
                    case 'r':
                        subtract++;
                        break;
                }
            }

            return subtract;
        }
    }
}