using System;
class Kyc
{
    static void Main()
    {
        Console.Write("Введите max_n:");
        int max_n = Convert.ToInt32(Console.ReadLine());
        int current = max_n;
        for (int k = 3; k <= max_n; k = 2 * k + 1)
        {
            int z = max_n / k;
            current += z;
        }
        Console.WriteLine(current);
    }
}