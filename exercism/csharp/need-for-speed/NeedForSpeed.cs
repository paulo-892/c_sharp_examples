using System;

class RemoteControlCar
{
    private int speed;
    private int batteryDrain;
    private int distanceDriven = 0;
    private int remainingBattery = 100;

    public RemoteControlCar(int speed, int batteryDrain)
    {
        this.speed = speed;
        this.batteryDrain = batteryDrain;
    }

    public bool BatteryDrained()
    {
        return remainingBattery < batteryDrain;
    }

    public int DistanceDriven()
    {
        return distanceDriven;
    }

    public void Drive()
    {
        if (BatteryDrained()) return;
        
        distanceDriven += speed;
        remainingBattery -= batteryDrain;
    }

    public static RemoteControlCar Nitro()
    {
        return new RemoteControlCar(speed: 50, batteryDrain: 4);
    }
}

class RaceTrack
{
    private int distance;

    public RaceTrack(int distance)
    {
        this.distance = distance;
    }

    public bool TryFinishTrack(RemoteControlCar car)
    {
        while (car.DistanceDriven() < distance && !car.BatteryDrained())
        {
            car.Drive();
        }

        return car.DistanceDriven() >= distance;
    }
}
