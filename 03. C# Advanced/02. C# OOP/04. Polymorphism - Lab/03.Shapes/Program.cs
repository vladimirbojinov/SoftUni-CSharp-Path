namespace Shapes;

public class StartUp
{
	static void Main(string[] args)
	{
		Rectangle rectangle = new Rectangle(6, 4);
		Console.WriteLine(rectangle.CalculateArea());
		Console.WriteLine(rectangle.CalculatePerimeter());
		Console.WriteLine(rectangle.Draw());

		Circle circle = new Circle(3);
		Console.WriteLine(circle.CalculateArea());
		Console.WriteLine(circle.CalculatePerimeter());
		Console.WriteLine(circle.Draw());
	}
}
