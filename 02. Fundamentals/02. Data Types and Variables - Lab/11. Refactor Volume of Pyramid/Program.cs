namespace _11._Refactor_Volume_of_Pyramid
{
    internal class Program
    {
        static void Main(string[] args)
        {
			Console.WriteLine("Length: ");
			double length = double.Parse(Console.ReadLine());

			Console.WriteLine("Width: ");
			double width = double.Parse(Console.ReadLine());

			Console.WriteLine("Height: ");
			double height = double.Parse(Console.ReadLine());

			double volume = (length + width + height) / 3;
			Console.WriteLine($"Pyramid Volume: {volume:F2}");
		}
    }
}