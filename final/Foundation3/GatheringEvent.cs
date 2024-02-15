public class GatheringEvent : Event
{
    private string _weather;

    public GatheringEvent(string title, string description, DateOnly date, TimeOnly time, Address address, string weather) : base(title, description, date, time, address)
    {
        _weather = weather;
    }

    public string GetFullDetails()
    {
        return @$"
Gathering:
{GetStandardDetails()}
Weather: {_weather}";
    }
}