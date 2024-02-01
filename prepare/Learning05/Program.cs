using System;

class Program
{
    static void Main(string[] args)
    {
        Square s = new Square("Red", 5);
        Console.WriteLine(s.GetColor());
        Console.WriteLine(s.GetArea());

        Rectangle r = new Rectangle("Blue", 5, 10);
        Console.WriteLine(r.GetColor());
        Console.WriteLine(r.GetArea());

        Circle c = new Circle("Green", 5);
        Console.WriteLine(c.GetColor());
        Console.WriteLine(c.GetArea());

        List<Shape> shapes = new List<Shape>();
        shapes.Add(s);
        shapes.Add(r);
        shapes.Add(c);

        foreach (Shape shape in shapes)
        {
            Console.WriteLine(shape.GetColor());
            Console.WriteLine(shape.GetArea());
        }
    }
}