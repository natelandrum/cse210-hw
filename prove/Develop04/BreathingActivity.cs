public class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        _name =  "Breathing";
        _description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
    }

    public void Run()
    {
        Console.Clear();
        DisplayStartingMessage();

        LoopActivities(BreatheIn, BreatheOut);

        Console.WriteLine();
        
        WriteLog();

        DisplayEndingMessage();
        
        
    }

    private void BreatheIn()
    {
        Console.Write("Breathe in...");
        ShowCountDown(4);
        Console.WriteLine();
    }

    private void BreatheOut()
    {
        Console.Write("Breathe out...");
        ShowCountDown(5);
        Console.WriteLine();
        Console.WriteLine();
    }
}