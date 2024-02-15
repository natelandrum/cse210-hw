public class SwimmingActivity : Activity
{
    private double _laps;

    public SwimmingActivity(DateOnly date, int duration, double laps) : base(date, duration)
    {
        _laps = laps;
    }

    protected override double GetDistance()
    {
        return _laps * 50 / 1000;
    }

    protected override double GetSpeed()
    {
        return GetDistance() / _duration * 60;
    }

    protected override double GetPace()
    {
        return _duration / GetDistance();
    }
}