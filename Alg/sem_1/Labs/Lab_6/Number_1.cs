using System;

class Program_1
{
    static int[,] Create_array()
    {
        Console.WriteLine("Введите m");
        int m = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введите n");
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

    static void Print_array(int[,] arr)
    {
        Console.WriteLine("Текущий массив:");
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                Console.Write($"{arr[i, j]}\t");
            }
            Console.WriteLine();
        }
    }

    static void Main()
    {
        int[,] array = Create_array();

        int[] multiply_arr = new int[array.GetLength(0)];

        int row_count = array.GetLength(0);
        int column_count = array.GetLength(1);

        for (int i = 0; i < column_count; i++)
        {
            int multiply = 1;
            for (int j = 0; j < row_count; j++)
            {
                multiply *= array[j, i];
            }

            multiply_arr[i] = multiply;
        }

        for (int i = 0; i < column_count - 1; i++)
        {
            for (int j = 0; j < column_count - i - 1; j++)
            {
                if (multiply_arr[j] < multiply_arr[j + 1])
                {
                    int temporary_multiply = multiply_arr[j];
                    multiply_arr[j] = multiply_arr[j + 1];
                    multiply_arr[j + 1] = temporary_multiply;

                    for (int k = 0; k < row_count; k++)
                    {
                        int temporary_value = array[k, j];
                        array[k, j] = array[k, j + 1];
                        array[k, j + 1] = temporary_value;
                    }
                }
            }
        }

        Print_array(array);

    }
}