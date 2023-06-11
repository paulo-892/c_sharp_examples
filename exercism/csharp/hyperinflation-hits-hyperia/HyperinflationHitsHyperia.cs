using System;

public static class CentralBank
{
    public static string DisplayDenomination(long @base, long multiplier)
    {
        long result;
        try
        {
            result = checked(@base * multiplier);
        }
        catch (OverflowException)
        {
            return "*** Too Big ***";
        }

        return result.ToString();
    }

    public static string DisplayGDP(float @base, float multiplier)
    {
        var result = checked(@base * multiplier);

        return float.IsPositiveInfinity(result) ? "*** Too Big ***" : result.ToString();
    }

    public static string DisplayChiefEconomistSalary(decimal salaryBase, decimal multiplier)
    {
        decimal result;
        try
        {
            result = checked(salaryBase * multiplier);
        }
        catch (OverflowException)
        {
            return "*** Much Too Big ***";
        }

        return result.ToString();    }
}
