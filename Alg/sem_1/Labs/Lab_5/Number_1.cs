using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
class Program_1
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

    static int[] Find_max_element(int[,] arr)
    {
        int max_element = arr[0,0];
        int index_element_str = 0;
        int index_element_col = 0;
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                if (arr[i, j] > max_element)
                {
                    max_element = arr[i, j];
                    index_element_str = i;
                    index_element_col = j;
                }
            }
        }
        int[] list = {index_element_str, index_element_col};
        return list;
    }

    static void Swap_str(int[,] arr, int first, int second)
    {
        int current = 0;
        for (int i=0; i < arr.GetLength(1); i++)
        {
            current = arr[first, i];
            arr[first, i] = arr[second, i];
            arr[second, i] = current;
        } 
    }

    static void Swap_col(int[,] arr, int first, int second) 
    {
        int current = 0;
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            current = arr[i, first];
            arr[i, first] = arr[i, second];
            arr[i, second] = current;
        }
    }

    static void Number_1(int[,] arr)
    {
        int current_str = Find_max_element(arr)[0];
        int current_col = Find_max_element(arr)[1];
        if (arr[0, arr.GetLength(1) - 1] != arr[current_str, current_col])
        {
            while (current_str != 0)
            {
                Swap_str(arr, current_str, current_str - 1);
                current_str--;
            }
            while (current_col != arr.GetLength(1)-1)
            {
                Swap_col(arr, current_col, current_col + 1);
                current_col++;
            }
        }
        else
        {
            return;
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
        Console.WriteLine();
        Number_1(array);
        Print_array(array);
    }
}