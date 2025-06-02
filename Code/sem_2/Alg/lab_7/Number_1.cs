using System;
using System.Diagnostics.Tracing;

class Point
{
    public double x { get; set; }
    public double y { get; set; }

    public Point(double x, double y)
    {
        this.x = x;
        this.y = y;
    }
}

delegate void Run_out_handler();

class Run_out_event
{
    public event Run_out_handler Event;

    public void On_event()
    {
        if (Event != null)
            Event();
    }
}

class Run_out_event_demo
{
    public static void Handler()
    {
        Console.WriteLine("Точка вышла за пределы поля!\n");
        Environment.Exit(0);
    }
}

class Program
{
    static void Main()
    {
        Random r = new Random();
        Point A = new Point(0, 0);
        Point B = new Point(0, 10);
        Point C = new Point(10, 10);
        Point D = new Point(10, 0);

        Point check = new Point(5, 5);

        Run_out_event evt = new Run_out_event();
        evt.Event += Run_out_event_demo.Handler;

        for (; ; )
        {
            check.x += r.NextDouble();
            check.y += r.NextDouble();

            if (check.x > 10 || check.x < 0 || check.y > 10 || check.y < 0)
                evt.OnEvent();

            Thread.Sleep(500);
        }
    }
}