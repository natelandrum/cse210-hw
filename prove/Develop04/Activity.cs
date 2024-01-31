using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Xml.Serialization;

public class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;
    protected List<ParseJson> _log = new List<ParseJson>();

    protected void DisplayStartingMessage()
    {
        Console.WriteLine($"Welcome to the {_name} Activity!\n");
        Console.WriteLine($"{_description}\n");
        Console.Write("How long, in seconds, would you like for your session? ");
        string index = Console.ReadLine();
        if (int.TryParse(index, out int duration)) 
        {
            _duration = duration;
        }

        else
        {
            Console.WriteLine("Invalid option. Please try again.");
            ShowCountDown(3);
            Console.Clear();
            DisplayStartingMessage();
        }
        
        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(5);
        Console.WriteLine();
    }

    protected void DisplayEndingMessage()
    {
        Console.WriteLine($"Well done!!\n");
        Console.WriteLine($"You have completed another {_duration} seconds of the {_name} Activity!\n");
        
        ShowSpinner(8);
    }

    protected void ShowSpinner(int seconds)
    {
        string[] animationStrings = new string[] { "|", "/", "-", "\\" };
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);

        int i = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write(animationStrings[i]);
            Thread.Sleep(500);
            Console.Write("\b \b");
            
            i++;

            if (i >= animationStrings.Count())
            {
                i = 0;
            }
        }
    }

    protected void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    // https://www.c-sharpcorner.com/UploadFile/manas1/params-in-C-Sharp-pass-variable-number-of-parameters-to-method/
    protected void LoopActivities(params Action[] activities)
    {
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            foreach (Action activity in activities)
            {
                activity();
            }
        }
    }

    private void LoadLog()
    {
        string json = File.ReadAllText("activities.json");
        _log = JsonSerializer.Deserialize<List<ParseJson>>(json);
    }

    protected void WriteLog()
    {   
        if (File.Exists("activities.json"))
        {
            LoadLog();
        }
        
        bool found = false;
        foreach (ParseJson item in _log)
        {
            if (item.Activity == _name)
            {
                item.Duration += _duration;
                item.Frequency++;
                found = true;
            }
        }

        if (!found)
        {
            _log.Add(new ParseJson(){Activity = _name, Duration = _duration, Frequency = 1});
        }
        
        string json = JsonSerializer.Serialize(_log);
        File.WriteAllText("activities.json", json);
    }

    public void DisplayLog()
    {
        if (File.Exists("activities.json"))
        {
            LoadLog();
            Console.WriteLine("Activity\tDuration(s)\tFrequency");
            foreach (ParseJson item in _log)
            {
                if (item.Activity == "Listing")
                {
                    Console.WriteLine($"{item.Activity}\t\t\t{item.Duration}\t\t{item.Frequency}");
                }
                else
                {
                    Console.WriteLine($"{item.Activity}\t\t{item.Duration}\t\t{item.Frequency}");
                }
            }
        }
        else
        {
            Console.WriteLine("\nYou haven't completed any activities yet.");
        }
        
        ShowSpinner(7);
    }
}