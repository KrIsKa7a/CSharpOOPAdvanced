using System;

namespace P02.Graphic_Editor
{
    class Program
    {
        static void Main()
        {
            var circle = new Circle();
            var rect = new Rectangle();
            var square = new Square();

            var ge = new GraphicEditor();

            ge.DrawShape(circle);
            ge.DrawShape(rect);
            ge.DrawShape(square);
        }
    }
}
