namespace P02.Graphic_Editor;

class Program
{
    static void Main()
    {
        GraphicEditor editor = new GraphicEditor();

        Circle circle = new Circle();
        Rectangle rectangle = new Rectangle();

        editor.DrawShape(circle);
        editor.DrawShape(rectangle);
    }
}
