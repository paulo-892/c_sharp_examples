using System;

class RemoteControlCar
{
    private int _distanceDriven = 0;
    private int _batteryRemaining = 100;
    
    public static RemoteControlCar Buy()
    {
        return new RemoteControlCar();
    }

    public string DistanceDisplay()
    {
        return $"Driven {_distanceDriven} meters";
    }

    public string BatteryDisplay()
    {
        return _batteryRemaining <= 0 ? "Battery empty" : $"Battery at {_batteryRemaining}%";
    }

    public void Drive()
    {
        if (_batteryRemaining <= 0) return;
        
        _distanceDriven += 20;
        _batteryRemaining -= 1;
    }
}
