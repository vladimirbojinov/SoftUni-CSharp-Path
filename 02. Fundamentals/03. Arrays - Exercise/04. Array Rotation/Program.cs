namespace _04._Array_Rotation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine().Split();
            int loop = int.Parse(Console.ReadLine());
            string[] array2 = new string[numbers.Length];

            for (int i = 0; i < loop; i++)
            {
                for (int k = 1; k < numbers.Length; k++)
                {
                    array2[k - 1] = numbers[k];
                }
                array2[numbers.Length - 1] = numbers[0];
                numbers = array2;
                array2 = new string[numbers.Length];
            }


            foreach (var k in numbers)
            {
                Console.Write(k + " ");
            }
        }
    }
}