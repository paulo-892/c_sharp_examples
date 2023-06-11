using System;
using System.Collections.Generic;
using System.IO;

public interface IRemoteControlCar 
{
    int DistanceTravelled { get; set; }
    void Drive();
}

public class ProductionRemoteControlCar : IComparable, IRemoteControlCar
{
    public int DistanceTravelled { get; set; }
    public int NumberOfVictories { get; set; }

    public void Drive()
    {
        DistanceTravelled += 10;
    }

    public int CompareTo(object obj)
    {
        return NumberOfVictories - ((ProductionRemoteControlCar) obj).NumberOfVictories;
    }
}

public class ExperimentalRemoteControlCar : IRemoteControlCar
{
    public int DistanceTravelled { get; set; }

    public void Drive()
    {
        DistanceTravelled += 20;
    }
}

public static class TestTrack
{
    public static void Race(IRemoteControlCar car)
    {
        car.Drive();
    }

    public static List<ProductionRemoteControlCar> GetRankedCars(ProductionRemoteControlCar prc1,
        ProductionRemoteControlCar prc2)
    {
        return prc1.CompareTo(prc2) < 0
            ? new List<ProductionRemoteControlCar>{ prc1, prc2 }
            : new List<ProductionRemoteControlCar>{prc2, prc1};
    }
}
