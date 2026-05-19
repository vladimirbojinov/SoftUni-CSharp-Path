using _04.Generi_SwapMethodInteger;

namespace _06.GenericCountMethodDouble
{
	internal class Program
	{
		static void Main(string[] args)
		{
			List<Box<double>> boxList = FillList();

			double value = double.Parse(Console.ReadLine());
			Box<double>.GreaterThanCount(boxList, value);
		}

		private static List<Box<double>> FillList()
		{
			List<Box<double>> boxList = new List<Box<double>>();
			int count = int.Parse(Console.ReadLine());

			for (int i = 0; i < count; i++)
			{
				double value = double.Parse(Console.ReadLine());
				Box<double> box = new Box<double>(value);

				boxList.Add(box);
			}

			return boxList;
		}
	}
}
