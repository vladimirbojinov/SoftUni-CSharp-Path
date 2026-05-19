namespace _01.ClassBoxData;

public class Box
{
	public Box(double length, double width, double height)
	{
		if (length <= 0) throw new ArgumentException($"{nameof(this.Length)} cannot be zero or negative.");
		if (width <= 0) throw new ArgumentException($"{nameof(this.Width)} cannot be zero or negative.");
		if (height <= 0) throw new ArgumentException($"{nameof(this.Height)} cannot be zero or negative.");

		this.Length = length;
		this.Width = width;
		this.Height = height;
	}

	public double Length { get; }
	public double Width { get; }
	public double Height { get; }

	public double SurfaceArea()
		=> 2.0 * (this.Length * this.Width + this.Length * this.Height + this.Width * this.Height);

	public double LateralSurfaceArea() 
		=> 2.0 * this.Length * this.Height + 2.0 * this.Width * this.Height;

	public double Volume()
		=> this.Length * this.Width * this.Height;
}
