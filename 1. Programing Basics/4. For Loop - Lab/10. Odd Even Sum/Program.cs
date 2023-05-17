namespace _10._Odd_Even_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int loop = int.Parse(Console.ReadLine());

            int evenNum = 0;
            int oddNum = 0;

            for (int value = 0; value < loop; value++)
            {
                int value1 = int.Parse(Console.ReadLine());

                if (value % 2 == 0)
                {
                    evenNum += value1;
                }
                else
                {
                    oddNum += value1;
                }
            }

            if (oddNum == evenNum)
            {
                Console.WriteLine("Yes");
                Console.WriteLine($"Sum = {evenNum}");
            }
            else
            {
                Console.WriteLine("No");
                Console.WriteLine($"Diff = {Math.Abs(oddNum - evenNum)}");
            }
        }
    }
}