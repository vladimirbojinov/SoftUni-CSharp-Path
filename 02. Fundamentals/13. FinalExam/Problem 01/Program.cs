namespace Problem_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            string command;
            while ((command = Console.ReadLine()) != "Finish")
            {
                string[] arguments = command.Split();

                switch (arguments[0])
                {
                    case "Replace":
                        string currentChar = arguments[1];
                        string newChar = arguments[2];
                        message = ReplaceMessage(message, currentChar, newChar); break;
                    case "Cut":
                        int startIndex = int.Parse(arguments[1]);
                        int endIndex = int.Parse(arguments[2]);
                        message = CutMessage(message, startIndex, endIndex); break;
                    case "Make":
                        switch (arguments[1])
                        {
                            case "Upper": message = ToUpperMessage(message); break;
                            case "Lower": message = ToLowerMessage(message); break;
                        }
                        break;
                    case "Check":
                        string text = arguments[1];
                        message = CheckMessage(message, text); break;
                    case "Sum":
                        startIndex = int.Parse(arguments[1]);
                        endIndex = int.Parse(arguments[2]);
                        SumMessage(message, startIndex, endIndex); break;
                }
            }
        }

        static string ReplaceMessage(string message, string currentChar, string newChar)
        {
            if (message.Contains(currentChar))
            {
                message = message.Replace(currentChar, newChar);
            }

            Console.WriteLine(message);

            return message;
        }
        static string CutMessage(string message, int startIndex, int endIndex)
        {
            int length = message.Length;

            if (IsValid(startIndex, length) && IsValid(endIndex, length)) // possible error bcs of subtraction 
            {
                int count = endIndex - startIndex;
                message = message.Remove(startIndex, endIndex);

                Console.WriteLine(message);
            }
            else
            {
                Console.WriteLine("Invalid indices!");
            }

            return message;
        }
        static string ToUpperMessage(string message)
        {
            message = message.ToUpper();

            Console.WriteLine(message);

            return message;
        }
        static string ToLowerMessage(string message)
        {
            message = message.ToLower();

            Console.WriteLine(message);

            return message;
        }
        static string CheckMessage(string message, string text)
        {
            if (message.Contains(text))
            {
                Console.WriteLine($"Message contains {text}");
            }
            else
            {
                Console.WriteLine($"Message doesn't contain {text}");
            }

            return message;
        }
        static void SumMessage(string message, int startIndex, int endIndex) //possible error wrong logic
        {
            int length = message.Length;

            if (IsValid(startIndex, length) && IsValid(endIndex, length))
            {
                int sum = 0;

                for (int i = startIndex; i <= endIndex; i++)
                {
                    sum += message[i];
                }

                Console.WriteLine(sum);
            }
            else
            {
                Console.WriteLine("Invalid indices!");
            }

        }
        static bool IsValid(int index, int length) // possible error
        {
            if (index < length && index > 0)
            {
                return true;
            }

            return false;
        }
    }
}