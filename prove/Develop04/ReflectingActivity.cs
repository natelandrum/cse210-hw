public class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string>();
    private List<string> _questions = new List<string>();

    public ReflectingActivity()
    {
        _name =  "Reflecting";
        _description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";

        _prompts.Add("Think of a time when you were proud of yourself.");
        _prompts.Add("Think of a time when you were able to overcome a challenge.");
        _prompts.Add("Think of a time when you were able to help someone else.");
        _prompts.Add("Think of a time when you were able to help yourself.");
        _prompts.Add("Think of a time when you did something tryly selfless.");
        _prompts.Add("Think of a time when you were able to make someone else smile.");
        _prompts.Add("Think of a time when you stood up for someone else.");

        _questions.Add("Why was this experience meaningful to you?");
        _questions.Add("Have you ever done anything like this before?");
        _questions.Add("How did you get started?");
        _questions.Add("How did you feel when it was complete?");
        _questions.Add("What made this time different than other times when you were not as successful?");
        _questions.Add("What is your favorite thing about this eperience?");
        _questions.Add("What could you learn from this experience that applies to other situations?");
        _questions.Add("What did you learn about yourself through this experience?");
        _questions.Add("How can you keep this experience in mind in the future?");
    }

    public void Run()
    {
        Console.Clear();
        DisplayStartingMessage();

        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine();
        DisplayPrompt();

        Console.Write("\nWhen you have something in mind, press enter to continue.");
        Console.ReadLine();
        Console.WriteLine();

        Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
        Console.Write("You may begin in: ");
        ShowCountDown(5);

        Console.Clear();

        LoopActivities(DisplayQuestion);

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

    private string GetRandomQuestion()
    {
        Random rnd = new Random();
        int index = rnd.Next(0, _questions.Count);
        if (_questions.Count == 0)
        {
            return "We're out of questions!";
        }
        string question = _questions[index];
        _questions.RemoveAt(index);
        return question;
    }

    private void DisplayPrompt()
    {
        Console.WriteLine($"--- {GetRandomPrompt()} ---");
    }

    private void DisplayQuestion()
    {
        Console.Write($"> {GetRandomQuestion()} ");
        ShowSpinner(7);
        Console.WriteLine();
    }
}