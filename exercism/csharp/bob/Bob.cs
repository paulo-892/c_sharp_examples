using System;
using System.Linq;

public static class Bob
{
    private static bool IsYelled(this string statement)
    {
        return
            statement.Any(char.IsUpper)
            && !statement.Any(char.IsLower);

    }
    
    public static string Response(string statement)
    {
        bool stmtIsQuestion = statement.Trim() != "" && statement.Trim().Last() == '?';
        bool stmtIsEmpty = statement == "" || statement.All(char.IsWhiteSpace);
        bool stmtIsYelled = statement.IsYelled();

        if (stmtIsEmpty)
        {
            return "Fine. Be that way!";
        }
        else if (stmtIsQuestion && stmtIsYelled)
        {
            return "Calm down, I know what I'm doing!";
        }
        else if (stmtIsQuestion)
        {
            return "Sure.";
        }
        else if (stmtIsYelled)
        {
            return "Whoa, chill out!";
        }
        else
        {
            return "Whatever.";
        }
    }
}