using System;

class Program_3
{
    static int[,] Create_array(int m, int n)
    {
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
        Console.WriteLine("Введите m");
        int m = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введите n");
        int n = Convert.ToInt32(Console.ReadLine());

        int[,] array = Create_array(m, n);
        Print_array(array);

        int min_value;
        int max_value = int.MinValue;
        int min_value_row = int.MinValue;
        int min_value_column = int.MinValue;
        int max_value_row = int.MinValue;
        int max_value_column = int.MinValue;
        int minimax_value = int.MinValue;

        for (int i = 0; i < array.GetLength(0); i++)
        {
            min_value = array[i, 0];
            for (int j = 0; j < array.GetLength(1); j++)
            {
                if (array[i, j] <= min_value)
                {
                    min_value = array[i, j];
                    min_value_row = i;
                    min_value_column = j;
                }
            }

            for (int j = 0; j < array.GetLength(0); j++)
            {
                if (array[j, min_value_column] >= max_value)
                {
                    max_value = array[j, min_value_column];
                    max_value_row = j;
                    max_value_column = min_value_column;
                }
            }

            if (min_value == max_value)
            {
                minimax_value = min_value;
                Console.WriteLine($"Точка минимакса = {minimax_value}, ее индекс = ({min_value_row}, {min_value_column}) ");
            }
        }

        if (minimax_value == int.MinValue)
        {
            Console.WriteLine($"В матрице отстуствует точка минимакса");
        }
    }
}