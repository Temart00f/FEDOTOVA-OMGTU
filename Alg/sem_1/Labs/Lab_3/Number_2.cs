using System;

class Number_2
{
    static void Main()
    {
        int n = Convert.ToInt32(Console.ReadLine());
        int current = 0;
        int max = 0;

        for (int i = 0; i < n; i++)
        {
            int num = Convert.ToInt32(Console.ReadLine());

            if (num % 2 == 0)
            {
                current += num;

                if (i == n - 1)
                {
                    if (current > max)
                    {
                        max = current;
                    }
                }
            }

            else
            {
                if (current > max && current != 0)
                    max = current;

                if (current < 0 && max == 0)
                {
                    max = current;
                }

                current = 0;
            }
        }

        Console.WriteLine($"Макс. сумма подпоследовательности четных чисел = {max}");
    }
}