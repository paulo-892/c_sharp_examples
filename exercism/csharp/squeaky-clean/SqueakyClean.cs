using System;
using System.Text;

public static class Identifier
{

    private static string ReplaceChars(this string identifier)
    {
        return identifier.Replace(' ', '_').Replace("\0", "CTRL");
    }

    private static string ConvertKebabCase(this string identifier)
    {
        StringBuilder sb = new StringBuilder();
        
        for (int i = 0; i < identifier.Length; i++)
        {
            char curChar = identifier[i];
            switch (curChar)
            {
                case '-' when i == identifier.Length - 1:
                    continue;
                case '-':
                    sb.Append(identifier[i + 1].ToString().ToUpper());
                    i++;
                    break;
                default:
                    sb.Append(curChar);
                    break;
            }
        }

        return sb.ToString();
    }

    private static string OmitNonLetters(this string identifier)
    {
        StringBuilder sb = new StringBuilder();
        
        foreach (char c in identifier)
        {
            if (char.IsLetter(c) || c == '_') sb.Append(c);
        }

        return sb.ToString();
    }
    
    private static string OmitLowercaseGreekLetters(this string identifier)
    {
        StringBuilder sb = new StringBuilder();
        
        foreach (char c in identifier)
        {
            if (!char.IsBetween(c, 'α', 'ω')) sb.Append(c);
        }

        return sb.ToString();
    }
    
    public static string Clean(string identifier)
    {
        if (identifier == "") return "";
        return identifier.ReplaceChars().ConvertKebabCase().OmitNonLetters().OmitLowercaseGreekLetters();
    }
}
