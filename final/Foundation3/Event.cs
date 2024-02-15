public class Event
{
    private string _title;
    private string _description;
    private DateOnly _date;
    private TimeOnly _time;
    private Address _address;

    public Event(string title, string description, DateOnly date, TimeOnly time, Address address)
    {
        _title = title;
        _description = description;
        _date = date;
        _time = time;
        _address = address;
    }

    public string GetStandardDetails()
    {
        return @$"
Title: {_title}
Description: {_description}
Date: {_date}
Time: {_time}
Address: {_address.GetAddress()}";
    }

    public string GetShortDescription()
    {
        return @$"
Title: {_title}
Date: {_date}";
    }
}