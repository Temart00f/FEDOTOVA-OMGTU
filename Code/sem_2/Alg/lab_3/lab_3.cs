using System;

interface GetFig
{
    double GetPerimeter();
    double GetArea();
}

class Figure
{
    string Name { get; set; }
}

class Circle : Figure, GetFig
{
    public double Radius { get; set; }
    public double GetPerimeter()
    {
        return 2 * Math.PI * Radius;
    }

    public double GetArea()
    {
        return Math.PI * Radius * Radius;
    }
}

class Square : Figure, GetFig
{
    public double Length { get; set; }

    public double GetPerimeter()
    {
        return 4 * Length;
    }

    public double GetArea()
    {
        return Length * Length;
    }
}

class Triangle
{
    public double Length { get; set; }

    public double GetPerimeter()
    {
        return 3 * Length;
    }

    public double GetSurface()
    {
        return (Math.Sqrt(3) * Length * Length) / 4;
    }
}

class Program
{
    static void Main()
    {
        Circle circle = new Circle();
        circle.Radius = 52;
        Console.WriteLine(circle.GetPerimeter());
        Console.WriteLine(circle.GetArea() + "\n");

        Square square = new Square();
        square.Length = 52;
        Console.WriteLine(square.GetPerimeter());
        Console.WriteLine(square.GetArea() + "\n");

        Triangle triangle = new Triangle();
        triangle.Length = 52;
        Console.WriteLine(triangle.GetPerimeter());
        Console.WriteLine(triangle.GetSurface());
    }
}