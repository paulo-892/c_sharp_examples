using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public enum Schedule
{
    Teenth,
    First,
    Second,
    Third,
    Fourth,
    Last
}

public class Meetup
{
    private int month;
    private int year;
    
    public Meetup(int month, int year)
    {
        this.month = month;
        this.year = year;
    }

    private DateTime FindNthDay(IEnumerable<DateTime> days, int n) => days.Skip(n - 1).First();

    private DateTime FindLastDay(IEnumerable<DateTime> days) => days.Last();

    private DateTime FindTeenthDay(IEnumerable<DateTime> days)
    {
        HashSet<int> teens = new HashSet<int>() {13, 14, 15, 16, 17, 18, 19};
        return days.First(x => teens.Contains(x.Day));
    }

    public DateTime Day(DayOfWeek dayOfWeek, Schedule schedule)
    {
        List<DateTime> days = new List<DateTime>();
        DateTime curDay = new DateTime(year, month, 1);

        while (curDay.Month == month)
        {
            if (curDay.DayOfWeek == dayOfWeek) days.Add(curDay);
            curDay = curDay.AddDays(1);
        }

        switch (schedule)
        {
            case Schedule.Last:
                return FindLastDay(days);
            case Schedule.Teenth:
                return FindTeenthDay(days);
            case Schedule.First:
                return FindNthDay(days, 1);
            case Schedule.Second:
                return FindNthDay(days, 2);
            case Schedule.Third:
                return FindNthDay(days, 3);
            case Schedule.Fourth:
                return FindNthDay(days, 4);
            default:
                throw new ArgumentOutOfRangeException(nameof(schedule), schedule, null);
        }
        
    }
}