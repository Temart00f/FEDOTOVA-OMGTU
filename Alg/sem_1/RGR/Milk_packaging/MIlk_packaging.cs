using System;

class Milk_packaging
{
    static void Main()
    {
        int firm_number = 0;
        double min_price = 1000;
        int n = Convert.ToInt32(Console.ReadLine());

        if (n < 1 || n > 100)
        {
            Console.WriteLine("N должно лежать в промежутке 0 < N <= 100");
            return;
        }

        for (int i = 0; i < n; i++)
        {
            string[] data = Console.ReadLine().Split(" ");

            int x1 = int.Parse(data[0]);
            int y1 = int.Parse(data[1]);
            int z1 = int.Parse(data[2]);
            int x2 = int.Parse(data[3]);
            int y2 = int.Parse(data[4]);
            int z2 = int.Parse(data[5]);
            double c1 = double.Parse(data[6]);
            double c2 = double.Parse(data[7]);

            int v1 = x1 * y1 * z1;
            int v2 = x2 * y2 * z2;
            int s1 = 2 * (x1 * y1 + x1 * z1 + y1 * z1);
            int s2 = 2 * (x2 * y2 + x2 * z2 + y2 * z2);

            double current = ((c2 * s1 - c1 * s2) / (v2 * s1 - v1 * s2)) * 1000;

            if (current < min_price)
            {
                min_price = current;
                firm_number = i;

            }
        }
        Console.WriteLine($"{Convert.ToString(firm_number+1)} {Math.Round(min_price, 2)}");
    }
}