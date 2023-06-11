using System;
using System.Globalization;
using static System.String;

public static class HighSchoolSweethearts
{
    public static string DisplaySingleLine(string studentA, string studentB)
    {
        return $"{studentA, 29} ♡ {studentB, -29}";
    }

    public static string DisplayBanner(string studentA, string studentB)
    {
        return $@"
     ******       ******
   **      **   **      **
 **         ** **         **
**            *            **
**                         **
**     {studentA} +  {studentB}    **
 **                       **
   **                   **
     **               **
       **           **
         **       **
           **   **
             ***
              *
";
    }

    public static string DisplayGermanExchangeStudents(string studentA
        , string studentB, DateTime start, float hours)
    {
        var germanCulture = CultureInfo.GetCultureInfo("de-DE");
        return Format(germanCulture, "{0:} and {1:} have been dating since {2:dd.MM.yyyy} - that's {3:#,##0.00} hours", 
            studentA, studentB, start, hours);
    }
}
