using System;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Main St", "Anytown", "NY", "USA");
        Address address2 = new Address("456 Elm St", "Othertown", "CA", "USA");
        Address address3 = new Address("789 Oak St", "Somewhere", "TX", "USA");

        LectureEvent lecture = new LectureEvent("C# for Beginners", "Learn the basics of C# programming", new DateOnly(2024, 3, 15), new TimeOnly(10, 0), address1, "John Doe", 100);

        ReceptionEvent reception = new ReceptionEvent("Wedding Reception", "Join us for a night of dinner and dancing", new DateOnly(2024, 4, 25), new TimeOnly(18, 0), address2, "reception_rsvp_29@events4u.com");

        GatheringEvent gathering = new GatheringEvent("Family Reunion", "A day of fun and games with the family", new DateOnly(2024, 2, 29), new TimeOnly(12, 0), address3, "Sunny");

        Console.WriteLine(lecture.GetStandardDetails());
        Console.WriteLine(lecture.GetFullDetails());
        Console.WriteLine(lecture.GetShortDescription());

        Console.WriteLine(reception.GetStandardDetails());
        Console.WriteLine(reception.GetFullDetails());
        Console.WriteLine(reception.GetShortDescription());

        Console.WriteLine(gathering.GetStandardDetails());
        Console.WriteLine(gathering.GetFullDetails());
        Console.WriteLine(gathering.GetShortDescription());
    }
}