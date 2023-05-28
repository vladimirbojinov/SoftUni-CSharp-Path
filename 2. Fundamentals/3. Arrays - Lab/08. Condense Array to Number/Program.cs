namespace _08._Condense_Array_to_Number
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
            int[] condenced = new int[array1.Length];

            double n = array1.Length;
            double loops = Math.Ceiling(n / 2);

            for (int i = 0; i < loops; i++)
            {
                for (int j = 0; j < array1.Length - 1; j++)
                {
                    condenced[j] = array1[j] + array1[j + 1];
                    array1[j] = condenced[j];
                }

            }

            Console.WriteLine(condenced[0] + condenced[1]);
        }
    }
}