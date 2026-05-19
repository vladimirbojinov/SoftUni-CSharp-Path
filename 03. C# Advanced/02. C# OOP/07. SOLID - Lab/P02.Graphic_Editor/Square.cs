using System;

namespace P02.Graphic_Editor;

public class Square : IShape
{
	public void DrawShape()
	{
		Console.WriteLine($"I Drew a {nameof(Square)}");
	}
}
