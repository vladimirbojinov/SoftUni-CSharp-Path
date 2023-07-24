namespace _04._Sum_of_Two_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int startingNum = int.Parse(Console.ReadLine());
            int endNum = int.Parse(Console.ReadLine());
            int magicNum = int.Parse(Console.ReadLine());

            int combinations = 0;
            bool endCycle = false;

            for (int FirstNum = startingNum; FirstNum <= endNum; FirstNum++)
            {
                for (int SecondNum = startingNum; SecondNum <= endNum; SecondNum++)
                {
                    combinations++;

                    if (FirstNum + SecondNum == magicNum)
                    {
                        Console.WriteLine($"Combination N:{combinations} ({FirstNum} + {SecondNum} = {magicNum})");

                        endCycle = true;
                        break;
                    }
                }

                if (endCycle)
                {
                    break;
                }
            }

            if (endCycle == false)
            {
                Console.WriteLine($"{combinations} combinations - neither equals {magicNum}");
            }
        }
    }
}