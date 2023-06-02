using System;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

//         return Regex.Matches(logLine, @": (.*)")[0].Groups[1].ToString().Trim();


public static class LogAnalysis 
{
    public static string SubstringAfter(this string str, string substr)
    {
        return Regex.Matches(str, $@".*{substr}(.*)")[0].Groups[1].ToString();
    }

    public static string SubstringBetween(this string str, string before, string after)
    {
        string beforePrefix = before == "[" ? "\\" : "";
        string afterPrefix = after == "[" ? "\\" : "";

        return Regex.Matches(str,
            $@".*{beforePrefix}{before}(.*){afterPrefix}{after}.*")[0].Groups[1].ToString();
    }

    public static string Message(this string str)
    {
        return str.SubstringAfter(": ");
    }

    public static string LogLevel(this string str)
    {
        return str.SubstringBetween("[", "]");
    }
}