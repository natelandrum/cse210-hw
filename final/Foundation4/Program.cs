using System;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>();

        DateOnly date = new DateOnly(2024, 02, 14);
        DateOnly date2 = new DateOnly(2024, 02, 18);
        DateOnly date3 = new DateOnly(2024, 02, 22);

        RunningActivity running = new RunningActivity(date, 30, 4.8);
        activities.Add(running);

        SwimmingActivity swimming = new SwimmingActivity(date2, 45, 30.0);
        activities.Add(swimming);

        CyclingActivity cycling = new CyclingActivity(date3, 60, 8);
        activities.Add(cycling);

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}