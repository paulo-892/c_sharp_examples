using System;
using System.Collections.Generic;
using System.Linq;

public static class RomanNumeralExtension
{
    public static string ToRoman(this int value)
    {
        ICollection<(int, string)> arabicToRoman = new List<(int, string)>(){
            (1000, "M"),
            (900, "CM"),
            (500, "D"),
            (400, "CD"),
            (100, "C"),
            (90, "XC"),
            (50, "L"),
            (40, "XL"),
            (10, "X"),
            (9, "IX"),
            (5, "V"),
            (4, "IV"),
            (1, "I"),
        };

        int rem = value;
        string res = "";
        
        foreach ((int, string) tup in arabicToRoman)
        {
            int num = tup.Item1;
            
            if (num > rem) continue;

            int iters = (int)(rem / num);
            for (int i = 0; i < iters; i++)
            {
                res += tup.Item2;
            }

            rem = rem % num;
        }

        return res;
    }
}

