public class ReceptionEvent : Event
{
    private string _registerEmail;

    public ReceptionEvent(string title, string description, DateOnly date, TimeOnly time, Address address, string registerEmail) : base(title, description, date, time, address)
    {
        _registerEmail = registerEmail;
    }

    public string GetFullDetails()
    {
        return @$"
Reception:
{GetStandardDetails()}
RSVP Email: {_registerEmail}";
    }
}