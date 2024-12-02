using System;
namespace Number_3
{
    class Program_3
    {
        public static void Third()
        {
            int m = 3;
            int l = 3;
            int p = 5;
            int n = Convert.ToInt32(Console.ReadLine());
            int garden_primeter = (l+m)*2; 
            int total_path = p*2*n + garden_primeter*n + m*n*(n-1);

            Console.WriteLine($"Длина пути при поливе всех грядок = {total_path}");
        }
    }
}
