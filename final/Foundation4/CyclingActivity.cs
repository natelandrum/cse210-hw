public class CyclingActivity : Activity
{
    private double _speed;

    public CyclingActivity(DateOnly date, int duration, double speed) : base(date, duration)
    {
        _speed = speed;
    }
    protected override double GetDistance()
        {
            return _speed * _duration / 60;
        }

    protected override double GetSpeed()
    {
        return _speed;
    }

    protected override double GetPace()
    {
        return _duration / GetDistance();
    }
}