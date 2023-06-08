using System;

public class SpiralMatrix
{
    public static int[,] GetMatrix(int size)
    {
        int[,] matrix = new int[size, size];
        
        int xIndex = 0;
        int yIndex = 0;
        
        int rLimit = size - 1;
        int lLimit = 0;
        int dLimit = size - 1;
        int uLimit = 0;
        
        string direction = "right";

        for (int i = 1; i <= size * size; i++)
        {
            // handle switching directions
            // set value
            matrix[xIndex, yIndex] = i;

            // update indices
            if (direction == "right")
            {
                if (yIndex < rLimit)
                {
                    yIndex++;
                }
                else
                {
                    direction = "down";
                    xIndex++;
                    uLimit++;
                }
            }
            else if (direction == "left")
            {
                if (yIndex > lLimit)
                {
                    yIndex--;
                }
                else
                {
                    direction = "up";
                    xIndex--;
                    dLimit--;
                }
            }
            else if (direction == "up")
            {
                if (xIndex > uLimit)
                {
                    xIndex--;
                }
                else
                {
                    direction = "right";
                    yIndex++;
                    lLimit++;
                }
            }
            else if (direction == "down")
            {
                if (xIndex < dLimit)
                {
                    xIndex++;
                }
                else
                {
                    direction = "left";
                    yIndex--;
                    rLimit--;
                }
            }
        }

        return matrix;
    }
}
