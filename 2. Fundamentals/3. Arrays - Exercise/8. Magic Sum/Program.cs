namespace _8._Magic_Sum
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

            while (array1.Length > 1)
            {
                int[] condensed = new int[array1.Length - 1];
                for (int i = 0; i < array1.Length - 1; i++)
                {
                    condensed[i] = array1[i] + array1[i + 1];
                }
                array1 = condensed;
            }

            Console.WriteLine(array1[0]);
        }
    }
}