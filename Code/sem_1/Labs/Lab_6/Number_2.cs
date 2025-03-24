using System;

class Program_2
{
    static int[,] Create_array()
    {
        Console.WriteLine("¬ведите m");
        int m = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("¬ведите n");
        int n = Convert.ToInt32(Console.ReadLine());

        int[,] arr = new int[m, n];

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                arr[i, j] = Convert.ToInt32(Console.ReadLine());
            }
        }
        return arr;
    }

    static void Main()
    {
        int[,] array = Create_array();
        int[] max_array = new int[array.GetLength(0)];

        int max = array[0, 0];

        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                if (array[i, j] > max)
                {
                    max = array[i, j];
                }
            }

            max_array[i] = max;
            max = array[i, 0];
        }

        for (int i = 0; i < max_array.Length; i++)
        {
            Console.Write($"{max_array[i]} ");
        }
    }
}