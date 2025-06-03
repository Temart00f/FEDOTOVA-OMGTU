using System;

class Citites
{
    static void Main()
    {
        string[] str1 = Console.ReadLine().Split();
        int n = int.Parse(str1[0]);
        int m = int.Parse(str1[1]);

        int[,] matrix = new int[n, n];
        const int inf = 100001;

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                matrix[i, j] = (i == j) ? 0 : inf;
            }
        }

        for (int i = 0; i < m; i++)
        {
            string[] str = Console.ReadLine().Split();
            int v1 = int.Parse(str[0]) - 1;
            int v2 = int.Parse(str[1]) - 1;
            int distance = int.Parse(str[2]);

            matrix[v1, v2] = distance;
            matrix[v2, v1] = distance;
        }

        for (int k = 0; k < n; k++)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i, k] + matrix[k, j] < matrix[i, j])
                    {
                        matrix[i, j] = matrix[i, k] + matrix[k, j];
                    }

                }
            }
        }

        int max_dist = 0;

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (matrix[i, j] < inf && matrix[i, j] > max_dist)
                {
                    max_dist = matrix[i, j];
                }
            }
        }

        Console.WriteLine(max_dist);

    }
}