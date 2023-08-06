namespace _04._Reverse_Array_of_Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] row = Console.ReadLine().Split();

            for (int i = row.Length - 1; i >= 0; i--)
            {
                Console.Write(row[i] + " ");
            }
        }
    }
}