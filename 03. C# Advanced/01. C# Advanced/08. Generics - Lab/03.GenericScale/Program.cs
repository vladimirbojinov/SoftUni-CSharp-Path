namespace GenericScale
{
	public class StartUp
	{
		static void Main(string[] args)
		{
			int a = 5; 
			int b = 6;

			EqualityScale<int> scale = new EqualityScale<int>(a, b);
			bool areEqual = scale.AreEqual();

            Console.WriteLine(areEqual);
        }
	}
}
