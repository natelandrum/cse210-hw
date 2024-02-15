public class LectureEvent : Event
{
    private string _speaker;
    private int _capacity;

    public LectureEvent(string title, string description, DateOnly date, TimeOnly time, Address address, string speaker, int capacity) : base(title, description, date, time, address)
    {
        _speaker = speaker;
        _capacity = capacity;
    }

    public string GetFullDetails()
    {
        return @$"
Lecture:
{GetStandardDetails()}
Speaker: {_speaker}
Capacity: {_capacity}";
    }
}