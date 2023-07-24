namespace _09._Left_and_Right_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int loop = int.Parse(Console.ReadLine());

            int leftSum = 0;
            int rightSum = 0;

            for (int i = 0; i < loop; i++)
            {
                leftSum = leftSum + int.Parse(Console.ReadLine());
            }
            for (int i = 0; i < loop; i++)
            {
                rightSum = rightSum + int.Parse(Console.ReadLine());
            }
            if (leftSum == rightSum)
            {
                Console.WriteLine($"Yes, sum = {leftSum}");
            }
            else
            {
                Console.WriteLine($"No, diff = {Math.Abs(leftSum - rightSum)}");
            }
        }
    }
}