using System;
using System.Text.RegularExpressions;

static class LogLine
{
    public static string Message(string logLine)
    {
        return Regex.Matches(logLine, @": (.*)")[0].Groups[1].ToString().Trim();
    }

    public static string LogLevel(string logLine)
    {
        return Regex.Matches(logLine, @"\[(.*)\]")[0].Groups[1].ToString().ToLower();
    }

    public static string Reformat(string logLine)
    {
        return $"{Message(logLine)} ({LogLevel(logLine)})";
    }
}
