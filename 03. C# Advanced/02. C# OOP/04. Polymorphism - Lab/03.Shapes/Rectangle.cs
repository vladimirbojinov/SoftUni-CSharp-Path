namespace Shapes;

public class Rectangle : Shape
{
	public Rectangle(double height, double width)
	{
		this.Height = height;
		this.Width = width;
	}

	public double Height { get; }
	public double Width { get; }

	public override double CalculateArea() => this.Height * this.Width;

	public override double CalculatePerimeter() => 2 * (this.Height + this.Width);

	public override string Draw()
	{
		return base.Draw() + $"{nameof(Rectangle)}";
	}
}
