namespace _03._Deposit_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //input
            double depositSum = double.Parse(Console.ReadLine());
            int depositInMonths = int.Parse(Console.ReadLine());
            double yearInterestPecentage = double.Parse(Console.ReadLine());
            //calculations
            double totalSum = depositSum + depositInMonths * ((depositSum * yearInterestPecentage / 100) / 12);
            //output
            Console.WriteLine(totalSum);
        }
    }
}