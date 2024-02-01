// Added a LoopActivities method to Activity class to remove duplicate code from each activity class.
// Added a member variable to Activity class to store the log of the activities.
// Added methods to load, save, and display a JSON log to the Activity class with corresponding menu option in Program class.
// Added a ParseJson class to manage the JSON log data.
// Prompts and questions will not repeat in the same session.
// Added input validation.


using System;
using System.Formats.Asn1;
using System.Reflection;
using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {
        int option = 0;

        while (option != 5)
        {
            Console.Clear();

            Console.WriteLine("Menu Options:");
            Console.WriteLine("     1. Start Breathing Activity");
            Console.WriteLine("     2. Start Reflecting Activity");
            Console.WriteLine("     3. Start Listing Activity");
            Console.WriteLine("     4. Review Activity Stats");
            Console.WriteLine("     5. Quit");
            Console.Write("Select a choice from the menu: ");
            string index = Console.ReadLine();

            if (int.TryParse(index, out int result)) 
            {
                option = result;
                switch (option)
                {
                    case 1:
                        BreathingActivity b = new BreathingActivity();
                        b.Run();
                        break;
                    case 2:
                        ReflectingActivity r = new ReflectingActivity();
                        r.Run();
                        break;
                    case 3:
                        ListingActivity l = new ListingActivity();
                        l.Run();
                        break;
                    case 4:
                        new Activity().DisplayLog();
                        break;
                    case 5:
                        Console.WriteLine("Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        Thread.Sleep(3000);
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid option. Please try again.");
                Thread.Sleep(3000);
            }
        }
    }
}

