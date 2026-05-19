namespace _04.Froggy
{
	public class Program
	{
		public static void Main(string[] args)
		{
			Lake lake = new Lake(Console.ReadLine());

			Console.WriteLine(string.Join(", ", lake));
		}
	}
}
