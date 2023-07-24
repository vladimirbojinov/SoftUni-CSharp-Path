namespace _04._Caesar_Cipher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string decryptedText = Console.ReadLine();
            string encryptedText = string.Empty;

            for (int i = 0; i < decryptedText.Length; i++)
            {
                int encryptedLetterCode = decryptedText[i] + 3;
                char encryptedLetter = (char)encryptedLetterCode;
                encryptedText += encryptedLetter;
            }

            Console.WriteLine(encryptedText);
        }
    }
}