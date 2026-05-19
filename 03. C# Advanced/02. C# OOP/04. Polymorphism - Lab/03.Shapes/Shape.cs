namespace Shapes;

abstract public class Shape
{
	public abstract double CalculatePerimeter();
	public abstract double CalculateArea();

	public virtual string Draw() => $"Drawing ";
}
