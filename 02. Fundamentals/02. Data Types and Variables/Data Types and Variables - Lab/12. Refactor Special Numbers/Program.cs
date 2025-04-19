using System.Globalization;

namespace _12._Refactor_Special_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
			int loops = int.Parse(Console.ReadLine());
			int sum = 0;

			for (int i = 1; i <= loops; i++)
			{
				int num = i;
				while (num > 0)
				{
					sum += num % 10;
					num = num / 10;
				}

				bool isSpecialNum = (sum == 5) || (sum == 7) || (sum == 11);
				Console.WriteLine("{0} -> {1}", i, isSpecialNum);
				sum = 0;
			}
		}
    }
}