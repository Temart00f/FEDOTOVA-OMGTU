using System;

class Number_2
{
    public Operations(double a, double b)
    {
        A = a;
        B = b;
    }

    private double A { get; set; }
    private double B { get; set; }

    public double Sum() => A + B;
    public double Minus(double sum) => sum - B;
    public double Multiply(double minus) => minus * B;

    public double Multiply_two() => A * B;
    public double Sum_two(double multi) => multi + B;

    public double Divide(double sum)
    {
        if (B != 0)
        {
            return sum / B;
        }

        return double.NaN;
    }
}
class Program
{
    public delegate double First_delegate();
    public delegate double Second_delegate();

    public static First_delegate First;
    public static Second_delegate Second;
    static void Main(string[] args)
    {
        Operations two = new Operations(6, 0);

        First = two.Sum;
        First += () => two.Minus(two.Sum());
        First += () => two.Multiply(two.Minus(two.Sum()));

        Second = two.Multiply_two;
        Second += () => two.Sum_two(two.Multiply_two());
        Second += () => two.Divide(two.Sum_two(two.Multiply_two()));

        Console.WriteLine($"Первый делегат: {First.Invoke()}");
        Console.WriteLine($"Второй делегат: {Second.Invoke()}");
    }
}