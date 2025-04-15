using System;

interface Get_figure
{
    double Get_perimeter();
    double Get_area();
}

class Figure
{
    string Name { get; set; }
}

class Circle : Figure, Get_figure
{
    public double Radius { get; set; }
    public double Get_perimeter()
    {
        return 2 * Math.PI * Radius;
    }

    public double Get_area()
    {
        return Math.PI * Radius * Radius;
    }
}

class Square : Figure, Get_figure
{
    public double Length { get; set; }

    public double Get_perimeter()
    {
        return 4 * Length;
    }

    public double Get_area()
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
        Console.WriteLine(circle.Get_perimeter());
        Console.WriteLine(circle.Get_area() + "\n");

        Square square = new Square();
        square.Length = 52;
        Console.WriteLine(square.Get_perimeter());
        Console.WriteLine(square.Get_area() + "\n");

        Triangle triangle = new Triangle();
        triangle.Length = 52;
        Console.WriteLine(triangle.GetPerimeter());
        Console.WriteLine(triangle.GetSurface());
    }
}