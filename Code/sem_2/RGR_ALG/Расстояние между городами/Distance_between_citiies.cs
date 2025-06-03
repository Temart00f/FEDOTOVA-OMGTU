using System;

class Distance_between_citites
{
    static void Main()
    {
        string[] city1_coords = Console.ReadLine().Split();
        double s1 = double.Parse(city1_coords[0]);
        double d1 = double.Parse(city1_coords[1]);

        string[] city2_coords = Console.ReadLine().Split();
        double s2 = double.Parse(city2_coords[0]);
        double d2 = double.Parse(city2_coords[1]);

        double radius = double.Parse(Console.ReadLine());

        double s1_in_radians = To_radians(s1);
        double d1_in_radians = To_radians(d1);
        double s2_in_radians = To_radians(s2);
        double d2_in_radians = To_radians(d2);

        double haversine = Math.Pow(Math.Sin((s2_in_radians - s1_in_radians) / 2), 2) +
                          Math.Cos(s1_in_radians) * Math.Cos(s2_in_radians) *
                          Math.Pow(Math.Sin(Math.Abs(d1_in_radians - d2_in_radians) / 2), 2);

        double central_angle = 2 * Math.Asin(Math.Sqrt(haversine));

        double distance = radius * central_angle;

        Console.WriteLine(Math.Round(distance, 3));
    }

    static double To_radians(double deg)
    {
        return deg * Math.PI / 180;
    }
}