namespace _03._Combinations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int wantedNum = int.Parse(Console.ReadLine());

            int counter = 0;

            for (int firstNum = 0; firstNum <= wantedNum; firstNum++)
            {
                for (int secNum = 0; secNum <= wantedNum; secNum++)
                {
                    for (int thirdNum = 0; thirdNum <= wantedNum; thirdNum++)
                    {
                        int isIt = firstNum + secNum + thirdNum;

                        if (isIt == wantedNum)
                        {
                            counter++;
                        }
                    }
                }
            }

            Console.WriteLine(counter);
        }
    }
}