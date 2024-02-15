public class Activity 
{
    protected DateOnly _date;
    protected int _duration;

    public Activity(DateOnly date, int duration)
    {
        _date = date;
        _duration = duration;
    }

    protected virtual double GetDistance()
    {
        return 0;
    }

    protected virtual double GetSpeed()
    {
        return 0;
    }

    protected virtual double GetPace()
    {
        return 0;
    }

    public string GetSummary()
    {
        char[] charsToTrim = {'A', 'c', 't', 'i', 'v', 'i', 't', 'y' };
        return $"{_date:dd MMM yyyy} {this.GetType().Name.Trim(charsToTrim)} ({_duration} min): Distance: {GetDistance()} km, Speed: {GetSpeed()} kph, Pace: {GetPace()} min per km";
    }
}