using System;
namespace Number_2
{
    class Program_2
    {
        public static void Second()
        {
            int a = Convert.ToInt32(Console.ReadLine());
            int b = Convert.ToInt32(Console.ReadLine());
            int max = (a + b + Math.Abs(a-b))/2;
            int min = (a + b - Math.Abs(a-b))/2;
            Console.WriteLine($"Наибольшее = {max}, Наименьшее = {min}");
        }
    }
}