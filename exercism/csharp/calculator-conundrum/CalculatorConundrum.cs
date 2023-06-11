using System;

public static class SimpleCalculator
{
    private static int PerformCalculation(int operand1, int operand2, string operation)
    {
        return operation switch
        {
            "+" => operand1 + operand2,
            "*" => operand1 * operand2,
            "/" => operand1 / operand2,
            "" => throw new ArgumentException(),
            null => throw new ArgumentNullException(),
            _ => throw new ArgumentOutOfRangeException()
        };
    }
    
    public static string Calculate(int operand1, int operand2, string operation)
    {
        int calculationResult;
        try
        {
            calculationResult = PerformCalculation(operand1, operand2, operation);
        }
        catch (DivideByZeroException e)
        {
            return "Division by zero is not allowed.";
        }

        return $"{operand1} {operation} {operand2} = {calculationResult}";
    }
}
