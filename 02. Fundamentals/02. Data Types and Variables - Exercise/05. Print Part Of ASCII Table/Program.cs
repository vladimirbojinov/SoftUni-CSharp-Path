namespace _05._Print_Part_Of_ASCII_Table
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstSymbol = int.Parse(Console.ReadLine());
            int secondSymbol = int.Parse(Console.ReadLine());

            for (int i = firstSymbol; i <= secondSymbol; i++)
            {
                Console.Write((char)i + " ");
            }
        }
    }
}