public class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts = new List<string>();

    public ListingActivity()
    {
        _name = "Listing";
        _description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain amount of time.";

        _prompts.Add("What are things you are grateful for.");
        _prompts.Add("Who are people that you appretiate?");
        _prompts.Add("What are personal strengths of yours?");
        _prompts.Add("Who are people that you have helped this week?");
        _prompts.Add("What are things that you have accomplished this week?");
        _prompts.Add("What are things that you are looking forward to?");
        _prompts.Add("When have you felt the Holy Ghost this week?");
        _prompts.Add("Who are some of your personal heroes?");
    }

    public void Run()
    {
        Console.Clear();
        DisplayStartingMessage();

        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine();
        DisplayPrompt();

        Console.Write("\nYou may begin in: ");
        ShowCountDown(5);
        Console.WriteLine();

        LoopActivities(GetListFromUser);

        Console.WriteLine();
        Console.WriteLine($"You listed {_count} items!");

        Console.WriteLine();

        WriteLog();

        DisplayEndingMessage();
    }

    private string GetRandomPrompt()
    {
        Random rnd = new Random();
        int index = rnd.Next(0, _prompts.Count);

        if (_prompts.Count == 0)
        {
            return "We're out of prompts!";
        }
        string prompt = _prompts[index];
        _prompts.RemoveAt(index);
        return prompt;
    }

    private void DisplayPrompt()
    {
        Console.WriteLine(GetRandomPrompt());
    }

    private void GetListFromUser()
    {
        Console.Write("> ");
        string input = Console.ReadLine();
        if (input != "")
        {
            _count++;
        }
    }
}