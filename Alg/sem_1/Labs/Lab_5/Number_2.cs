using System;

class Program_2
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

    static int[] Sort_row(int[] row)
    {
        for (int i = 0; i < row.Length - 1; i++)
        {
            int min = i;
            for (int j = i + 1; j < row.Length; j++)
            {
                if (row[j] < row[min])
                {
                    min = j;
                }
            }
            (row[min], row[i]) = (row[i], row[min]);
        }

        return row;
    }

    static bool Compare_rows(ref int[,] arr, int firstRow, int secondRow)
    {
        int[] firstRowArray = new int[arr.GetLength(1)];
        int[] secondRowArray = new int[arr.GetLength(1)];

        for (int i = 0; i < arr.GetLength(1); i++)
        {
            firstRowArray[i] = arr[firstRow, i];
        }

        for (int i = 0; i < arr.GetLength(1); i++)
        {
            secondRowArray[i] = arr[secondRow, i];
        }

        firstRowArray = Sort_row(firstRowArray);
        secondRowArray = Sort_row(secondRowArray);

        for (int i = 0; i < arr.GetLength(1); i++)
        {
            if (firstRowArray[i] != secondRowArray[i])
                return false;
        }

        return true;
    }

    static void Main()
    {
        Console.WriteLine("Введите m");
        int m = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введите n");
        int n = Convert.ToInt32(Console.ReadLine());

        int[,] array = Create_array(m, n);
        Print_array(array);

        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(0); j++)
            {
                if (i == j)
                    continue;

                if (Compare_rows(ref array, i, j) == true)
                {
                    Console.WriteLine($"Строчка {i + 1} состоит из тех же элементов что и строчка {j + 1}");
                }
            }
        }
    }
}
