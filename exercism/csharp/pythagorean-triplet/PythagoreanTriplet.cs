using System;
using System.Collections.Generic;
using System.Linq;

public static class PythagoreanTriplet
{
    public static IEnumerable<(int a, int b, int c)> TripletsWithSum(int sum)
    {
        List<(int, int, int)> result = new List<(int, int, int)>();

        for (int i = 0; i < sum / 3; i++)
        {
            for (int j = i + 1; j < sum; j++)
            {
                // continues if i and j equal
                if (i == j)
                {
                    continue;
                }

                double kDouble = Math.Sqrt(i * i + j * j);

                // continues if k not an integer
                if (kDouble % 1 != 0)
                {
                    continue;
                }

                int k = (int)kDouble;

                // continues if k equal to i or j
                if (i == k || j == k)
                {
                    continue;
                }

                if (i + j + k == sum)
                {
                    result.Add((i, j, k));
                }

            }
        }

        return result;
    }
}