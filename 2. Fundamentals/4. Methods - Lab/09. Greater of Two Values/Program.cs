namespace _09._Greater_of_Two_Values
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();

            if (type == "int")
            {
                GetMaxInt();
            }
            else if (type == "char")
            {
                GetMaxChar();
            }
            else
            {
                GetMaxString();
            }
        }

        static void GetMaxInt()
        {
            int n1 = int.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());

            if (n1 > n2)
            {
                Console.WriteLine(n1);
            }
            else
            {
                Console.WriteLine(n2);
            }
        }

        static void GetMaxChar()
        {
            char n1 = char.Parse(Console.ReadLine());
            char n2 = char.Parse(Console.ReadLine());

            if ((int)n1 > (int)n2)
            {
                Console.WriteLine(n1);
            }
            else
            {
                Console.WriteLine(n2);
            }
        }

        static void GetMaxString()
        {
            string n1 = Console.ReadLine();
            string n2 = Console.ReadLine();

            int n1ToInt = 0; int n2ToInt = 0;

            for (int i = 0; i < n1.Length - 1; i++)
            {
                char letter = n1[i];
                n1ToInt += letter;
            }
            for (int j = 0; j < n1.Length-1; j++)
            {
                char letter = n2[j];
                n2ToInt += letter;
            }

            if (n1ToInt > n2ToInt)
            {
                Console.WriteLine(n1);
            }
            else
            {
                Console.WriteLine(n2);
            }
        }
    }
}