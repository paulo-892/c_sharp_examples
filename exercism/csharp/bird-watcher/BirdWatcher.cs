using System;
using System.Linq;

class BirdCount
{
    private int[] birdsPerDay;

    public BirdCount(int[] birdsPerDay)
    {
        this.birdsPerDay = birdsPerDay;
    }

    public static int[] LastWeek()
    {
        return new int[] {0, 2, 5, 3, 7, 8, 4};
    }

    public int Today()
    {
        return birdsPerDay.Last();
    }

    public void IncrementTodaysCount()
    {
        birdsPerDay[birdsPerDay.Length - 1]++;
    }

    public bool HasDayWithoutBirds()
    {
        return birdsPerDay.Any(x => x == 0);
    }

    public int CountForFirstDays(int numberOfDays)
    {
        return birdsPerDay.Skip(0).Take(numberOfDays).Sum();
    }

    public int BusyDays()
    {
        return birdsPerDay.Count(x => x >= 5);
    }
}
