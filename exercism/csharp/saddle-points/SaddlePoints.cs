using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

public static class SaddlePoints
{
    public static IEnumerable<(int, int)> Calculate(int[,] matrix)
    {
        List<(int, int)> candidates = new List<(int, int)>();
        
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            int max = int.MinValue;
            
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] > max)
                {
                    max = matrix[i, j];
                } 
            }

            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] == max)
                {
                    candidates.Add((i + 1, j + 1));
                } 
            }
        }

        List<(int, int)> results = new List<(int, int)>();
        foreach ((int, int) tree in candidates)
        {
            bool shortest = true;
            for (int k = 0; k < matrix.GetLength(0); k++)
            {
                if (matrix[k, tree.Item2 - 1] < matrix[tree.Item1 - 1, tree.Item2 - 1])
                {
                    shortest = false;
                    break;
                }
            }

            if (shortest)
            {
                results.Add(tree);
            }
        }

        return results;
    }
}
