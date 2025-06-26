using System;
using System.Collections.Generic;

class Super_horse
{
    struct Position
    {
        public int X;
        public int Y;
        public int Moves;
    }

    static bool Is_black(int x, int y)
    {
        return (x + y) % 2 == 0;
    }

    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        string[] coordinates = Console.ReadLine().Split();
        int x1 = int.Parse(coordinates[0]);
        int y1 = int.Parse(coordinates[1]);
        int x2 = int.Parse(coordinates[2]);
        int y2 = int.Parse(coordinates[3]);

        if (x1 == x2 && y1 == y2)
        {
            Console.WriteLine("0");
            return;
        }

        Queue<Position> queue = new Queue<Position>();
        queue.Enqueue(new Position { X = x1, Y = y1, Moves = 0 });

        bool[,] visited = new bool[n + 1, n + 1];
        visited[x1, y1] = true;

        int[] knight_dx = { 2, 2, 1, 1, -1, -1, -2, -2 };
        int[] knight_dy = { 1, -1, 2, -2, 2, -2, 1, -1 };

        int[] white_dx = { 1, -1, 0, 0 };
        int[] white_dy = { 0, 0, 1, -1 };

        while (queue.Count > 0)
        {
            Position current = queue.Dequeue();

            if (Is_black(current.X, current.Y))
            {
                for (int i = 0; i < 8; i++)
                {
                    int new_x = current.X + knight_dx[i];
                    int new_y = current.Y + knight_dy[i];

                    if (new_x >= 1 && new_x <= n && new_y >= 1 && new_y <= n && !visited[new_x, new_y])
                    {
                        if (new_x == x2 && new_y == y2)
                        {
                            Console.WriteLine(current.Moves + 1);
                            return;
                        }
                        visited[new_x, new_y] = true;
                        queue.Enqueue(new Position { X = new_x, Y = new_y, Moves = current.Moves + 1 });
                    }
                }
            }
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    int new_x = current.X + white_dx[i];
                    int new_y = current.Y + white_dy[i];

                    if (new_x >= 1 && new_x <= n && new_y >= 1 && new_y <= n && !visited[new_x, new_y])
                    {
                        if (new_x == x2 && new_y == y2)
                        {
                            Console.WriteLine(current.Moves + 1);
                            return;
                        }
                        visited[new_x, new_y] = true;
                        queue.Enqueue(new Position { X = new_x, Y = new_y, Moves = current.Moves + 1 });
                    }
                }
            }
        }
        Console.WriteLine("NO");
    }
}