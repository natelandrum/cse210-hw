public class RunningActivity : Activity
{
    private double _distance;

    public RunningActivity(DateOnly date, int duration, double distance) : base(date, duration)
    {
        _distance = distance;
    }

    protected override double GetDistance()
    {
        return _distance;
    }

    protected override double GetSpeed()
    {
        return _distance / _duration * 60;
    }
}