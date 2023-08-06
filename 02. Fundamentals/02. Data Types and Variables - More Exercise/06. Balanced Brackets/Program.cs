namespace _06._Balanced_Brackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int loops = int.Parse(Console.ReadLine());

            bool leftBracketSeen = false;
            bool rightBracketSeen = false;

            bool isBalanced = false;

            for (int i = 0; i < loops; i++)
            {
                string input = Console.ReadLine();

                if (leftBracketSeen && input == "(" || rightBracketSeen && input == ")")
                {
                    isBalanced = false;
                    break;
                }

                if (input == "(")
                {
                    leftBracketSeen = true;
                    isBalanced = false;
                }

                if (input == ")")
                {
                    rightBracketSeen = true;
                    isBalanced = false;
                }

                if (leftBracketSeen && rightBracketSeen)
                {
                    isBalanced = true;
                    leftBracketSeen = false;
                    rightBracketSeen = false;
                }
            }

            if (isBalanced)
            {
                Console.WriteLine("BALANCED");
            }
            else
            {
                Console.WriteLine("UNBALANCED");
            }
        }
    }
}