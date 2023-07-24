namespace The_Imitation_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string encryptedMessage = Console.ReadLine();
            string decryptedMessage = encryptedMessage;

            string command;
            while ((command = Console.ReadLine()) != "Decode")
            {
                string[] arguments = command.Split('|');

                switch (arguments[0])
                {
                    case "Move": decryptedMessage = MoveMethod(int.Parse(arguments[1]), decryptedMessage); break;
                    case "Insert": decryptedMessage = InsertMethod(int.Parse(arguments[1]), arguments[2], decryptedMessage); break;
                    case "ChangeAll": decryptedMessage = ReplaceMethod(arguments[1], arguments[2], decryptedMessage); break;
                }
            }

            Console.WriteLine($"The decrypted message is: {decryptedMessage}");
        }


        static string MoveMethod(int numberOfLetters, string message)
        {
            string newMessage = message;

            string takenLetters = newMessage.Substring(0, numberOfLetters);
            newMessage = newMessage.Remove(0, numberOfLetters);
            newMessage = newMessage + takenLetters;

            return newMessage;
        }
        static string InsertMethod(int index, string letter, string message)
        {
            string newMessage = message;

            newMessage = newMessage.Insert(index, letter);

            return newMessage;
        }
        static string ReplaceMethod(string substring, string replacement, string message)
        {
            string newMessage = message;

            newMessage = newMessage.Replace(substring, replacement);

            return newMessage;
        }
    }
}