using System;

public static class ReverseString
{
    public static string Reverse(string input)
    {
        // in-built
        // char[] stringArray = input.ToCharArray();
        // Array.Reverse(stringArray);
        // return new string(stringArray);
        
        // manual
        char[] reversedStringArray = new char[input.Length];
        for (int i = 0; i < input.Length; i++)
        {
            reversedStringArray[i] = input[input.Length - i - 1];
        }
        return new string(reversedStringArray);
    }
}