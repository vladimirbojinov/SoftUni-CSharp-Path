namespace _10._Multiply_Evens_by_Odds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            number = Math.Abs(number);

            string numberToString = number.ToString();
            int sumOfEven = 0;
            int oddOfEven = 0;

            for (int i = 0; i < numberToString.Length; i++)
            {
                int currentNum = int.Parse(numberToString[i].ToString());

                if (currentNum % 2 == 0)
                {
                    sumOfEven += currentNum;
                }
                else
                {
                    oddOfEven += currentNum;
                }

            }

            MultiplyEvenAndOdd(sumOfEven, oddOfEven);
        }

        static void MultiplyEvenAndOdd(int n1, int n2)
        {
            Console.WriteLine(n1 * n2);
        }
    }
}