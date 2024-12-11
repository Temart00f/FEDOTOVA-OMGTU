﻿using System;

class Number_1
{
    static void Main()
    {
        int n = Convert.ToInt32(Console.ReadLine());
        while (n > 0)
        {
            int discharge = 0;
            int reverse = 0;
            int odd = 0;
            int count = 0;

            do
            {
                discharge = n % 10;
                n = n / 10;
                reverse *= 10;
                reverse += discharge;
            }
            while (Math.Abs(n) >= 1);

            do
            {
                discharge = reverse % 10;
                reverse /= 10;
                if (discharge % 2 != 0)
                {

                    odd += discharge * Convert.ToInt32(Math.Pow(10, count));
                    count++;
                }
            }
            while (Math.Abs(reverse) >= 1);

            if (odd == 0)
            {
                Console.WriteLine("Нечетных цифр в элементе нет!");
            }

            else
            {
                Console.WriteLine(odd);
            }

            n = Convert.ToInt32(Console.ReadLine());
        }
    }
}