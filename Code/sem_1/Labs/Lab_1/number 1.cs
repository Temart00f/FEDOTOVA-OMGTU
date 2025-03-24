using System;
namespace Number_1
{
    class Program_1
    {
        public static void First()
        {
            int a = Convert.ToInt32(Console.ReadLine());
            int b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"a={a}, b={b}");
            a = a + b;
            b = a - b;
            a = a - b;
            Console.WriteLine($"a={a}, b={b}");
        }
    }

}