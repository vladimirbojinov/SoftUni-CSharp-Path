namespace _03._Characters_in_Range
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(" ", CharRange()));
        }

        static string[] CharRange()
        {
            char char1 = char.Parse(Console.ReadLine());
            char char2 = char.Parse(Console.ReadLine());

            if ((int)char1 > (int)char2)
            {
                char last = char1;
                char1 = char2;
                char2 = last;
            }

            string charRow = " ";
            int counter = 0;

            for (int i = (int)char1 + 1; i < (int)char2; i++)
            {
                char singleChar = (char)i;
                charRow += singleChar + " ";
                counter++;
            }

            string[] charArray = charRow.Split().ToArray();

            return charArray;
        }
    }
}