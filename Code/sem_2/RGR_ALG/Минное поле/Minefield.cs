using System;

class Minefield
{
    static void Main()
    {
        string[] sizes = Console.ReadLine().Split();
        int n = int.Parse(sizes[0]);
        int m = int.Parse(sizes[1]);

        int[,] field = new int[n, m];

        for (int i = 0; i < n; i++)
        {
            string[] row = Console.ReadLine().Split();

            for (int j = 0; j < m; j++)
            {
                field[i, j] = int.Parse(row[j]);
            }
        }

        int[,] min_mines = new int[n, m];
        int[,] prev = new int[n, m];

        for (int j = 0; j < m; j++)
        {
            min_mines[0, j] = field[0, j];
            prev[0, j] = -1;
        }

        for (int i = 1; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                int min_prev = min_mines[i - 1, j];
                int min_index = j;

                if (j > 0 && min_mines[i - 1, j - 1] < min_prev)
                {
                    min_prev = min_mines[i - 1, j - 1];
                    min_index = j - 1;
                }
                if (j < m - 1 && min_mines[i - 1, j + 1] < min_prev)
                {
                    min_prev = min_mines[i - 1, j + 1];
                    min_index = j + 1;
                }

                min_mines[i, j] = field[i, j] + min_prev;
                prev[i, j] = min_index;
            }
        }

        int min_total = min_mines[n - 1, 0];
        int min_col = 0;
        for (int j = 1; j < m; j++)
        {
            if (min_mines[n - 1, j] < min_total)
            {
                min_total = min_mines[n - 1, j];
                min_col = j;
            }
        }

        int[] path = new int[n];
        int col = min_col;
        for (int i = n - 1; i >= 0; i--)
        {
            path[i] = col + 1;
            col = prev[i, col];
        }

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine(path[i]);
        }
    }
}