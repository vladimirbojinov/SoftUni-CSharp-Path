using static System.Net.Mime.MediaTypeNames;

namespace _04._Morse_Code_Translator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string dot = ".";
            string dash = "-";

            string morseCodeLetter = Console.ReadLine();
            Console.WriteLine(Decrypting(morseCodeLetter, dot, dash));
        }

        static string Decrypting(string morseCodeLetter, string dot, string dash)
        {
            Dictionary<char, string> lettersToMorse = new Dictionary<char, string>()
            {
                {'A', string.Concat(dot, dash)},
                {'B', string.Concat(dash, dot, dot, dot)},
                {'C', string.Concat(dash, dot, dash, dot)},
                {'D', string.Concat(dash, dot, dot)},
                {'E', string.Concat(dot)},
                {'F', string.Concat(dot, dot, dash, dot)},
                {'G', string.Concat(dash, dash, dot)},
                {'H', string.Concat(dot, dot, dot, dot)},
                {'I', string.Concat(dot, dot)},
                {'J', string.Concat(dot, dash, dash, dash)},
                {'K', string.Concat(dash, dot, dash)},
                {'L', string.Concat(dot, dash, dot, dot)},
                {'M', string.Concat(dash, dash)},
                {'N', string.Concat(dash, dot)},
                {'O', string.Concat(dash, dash, dash)},
                {'P', string.Concat(dot, dash, dash, dot)},
                {'Q', string.Concat(dash, dash, dot, dash)},
                {'R', string.Concat(dot, dash, dot)},
                {'S', string.Concat(dot, dot, dot)},
                {'T', string.Concat(dash)},
                {'U', string.Concat(dot, dot, dash)},
                {'V', string.Concat(dot, dot, dot, dash)},
                {'W', string.Concat(dot, dash, dash)},
                {'X', string.Concat(dash, dot, dot, dash)},
                {'Y', string.Concat(dash, dot, dash, dash)},
                {'Z', string.Concat(dash, dash, dot, dot)},
                {'0', string.Concat(dash, dash, dash, dash, dash)},
                {'1', string.Concat(dot, dash, dash, dash, dash)},
                {'2', string.Concat(dot, dot, dash, dash, dash)},
                {'3', string.Concat(dot, dot, dot, dash, dash)},
                {'4', string.Concat(dot, dot, dot, dot, dash)},
                {'5', string.Concat(dot, dot, dot, dot, dot)},
                {'6', string.Concat(dash, dot, dot, dot, dot)},
                {'7', string.Concat(dash, dash, dot, dot, dot)},
                {'8', string.Concat(dash, dash, dash, dot, dot)},
                {'9', string.Concat(dash, dash, dash, dash, dot)}
            };

            string morseCodeWithSpace = morseCodeLetter.Replace(" | ", " n ");
            string[] individualMorselLetter = morseCodeWithSpace.Split();

            int count = 0;
            foreach (string morseLetter in individualMorselLetter)
            {
                if (lettersToMorse.ContainsValue(morseLetter))
                {
                    char key = lettersToMorse.FirstOrDefault(x => x.Value == morseLetter).Key;
                    individualMorselLetter[count] = key.ToString();
                }
                count++;
            }

            string letter = string.Join("", individualMorselLetter);
            letter = letter.Replace("n", " ");

            return letter;
        }
    }
}