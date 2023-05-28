namespace _05._Top_Integers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array1 = Console
                .ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            for (int i = 0; i < array1.Length - 1; i++)
            {
                if (array1[i] > array1[i + 1])
                {
                    Console.Write(array1[i] + " ");
                }
            }

            Console.Write(array1[array1.Length - 1]);
        }
    }
}