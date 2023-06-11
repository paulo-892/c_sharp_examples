using System;

class WeighingMachine
{
    public int Precision { get; }

    private double _weight;
    public double Weight
    {
        get => _weight;
        set
        {
            if (value >= 0) _weight = value;
            else throw new ArgumentOutOfRangeException();
        }
    }

    public string DisplayWeight
    {
        get
        {
            var formatString = string.Concat("{0:F", Precision, "}");
            return string.Concat(string.Format(formatString, Weight - TareAdjustment), " kg");
        }
    }
    

    public double TareAdjustment { get; set; } = 5;
    
    public WeighingMachine(int precision)
    {
        Precision = precision;
    }
}
