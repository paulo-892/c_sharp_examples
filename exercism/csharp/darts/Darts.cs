using System;

public static class Darts
{
    private static double DistanceToOrigin(double x, double y) => Math.Sqrt(x * x + y * y);

    public static int Score(double x, double y)
    {
        double dist = DistanceToOrigin(x, y);

        if (dist > 10) return 0;
        else if (dist > 5) return 1;
        else if (dist > 1) return 5;
        else return 10;
    }
}
