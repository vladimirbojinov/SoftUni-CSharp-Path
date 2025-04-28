namespace _07._Append_Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] numberChunks = Console.ReadLine()
                .Split('|', StringSplitOptions.RemoveEmptyEntries);

            PrintArray(numberChunks);
        }

        static void PrintArray(string[] stringsArray)
        {
            List<string> result = new List<string>();

            for (int i = stringsArray.Length - 1; i >= 0; i--)
            {
                string[] array = stringsArray[i]
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                result.AddRange(array);
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}