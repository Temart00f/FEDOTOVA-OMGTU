using System;
using System.Collections.Generic;
using System.Linq;

class Neutro_connection
{
    struct Point
    {
        public int Id;
        public double Alpha;
        public double Beta;
    }

    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        List<Point> points = new List<Point>();

        for (int i = 0; i < n; i++)
        {
            string[] parts = Console.ReadLine().Split();
            int id = int.Parse(parts[0]);
            double alpha = Parse_angle(parts[1]);
            double beta = Parse_angle(parts[2]);

            points.Add(new Point { Id = id, Alpha = alpha, Beta = beta });
        }

        List<Tuple<int, int>> pairs = new List<Tuple<int, int>>();

        for (int i = 0; i < points.Count; i++)
        {
            for (int j = i + 1; j < points.Count; j++)
            {
                if (Opposite(points[i], points[j]))
                {
                    int p = Math.Min(points[i].Id, points[j].Id);
                    int q = Math.Max(points[i].Id, points[j].Id);
                    pairs.Add(Tuple.Create(p, q));
                }
            }
        }

        pairs = pairs.OrderBy(p => p.Item1).ThenBy(p => p.Item2).ToList();

        Console.WriteLine(pairs.Count);
        foreach (var pair in pairs)
        {
            Console.WriteLine($"{pair.Item1}-{pair.Item2}");
        }
    }

    static double Parse_angle(string angleStr)
    {
        string[] parts = angleStr.Split(new[] { '~', '\'', '"' }, StringSplitOptions.RemoveEmptyEntries);

        int degrees = int.Parse(parts[0]);
        int minutes = int.Parse(parts[1]);
        int seconds = int.Parse(parts[2]);

        double sign = 1;
        if (angleStr.StartsWith("-"))
        {
            sign = -1;
            degrees = Math.Abs(degrees);
        }

        return sign * (degrees + minutes / 60.0 + seconds / 3600.0);
    }

    static bool Opposite(Point p1, Point p2)
    {
        double alpha1 = Normalize(p1.Alpha);
        double beta1 = Normalize(p1.Beta);
        double alpha2 = Normalize(p2.Alpha);
        double beta2 = Normalize(p2.Beta);

        bool alphaCondition = Math.Abs(Normalize(alpha1 - alpha2 + 180)) < 1e-9 ||
                             Math.Abs(Normalize(alpha1 - alpha2 - 180)) < 1e-9;

        bool betaCondition = Math.Abs(Normalize(beta1 + beta2)) < 1e-9;

        return alphaCondition && betaCondition;
    }

    static double Normalize(double angle)
    {
        angle = angle % 360;
        if (angle < 0) angle += 360;
        return angle;
    }
}