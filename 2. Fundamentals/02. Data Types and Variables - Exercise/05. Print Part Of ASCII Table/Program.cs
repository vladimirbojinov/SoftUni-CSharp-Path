namespace _05._Print_Part_Of_ASCII_Table
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstChar = int.Parse(Console.ReadLine());
            int secChar = int.Parse(Console.ReadLine());

            for (int i = firstChar; i <= secChar; i++)
            {
                Console.Write((char)i + " ");
            }
        }
    }
}