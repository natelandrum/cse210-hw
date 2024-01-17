using System;

public class Entry
{
    public string _date;
    public string _promptText;
    public string _entryText;
    
    public void Display(int index)
    {
        Console.WriteLine("");
        Console.WriteLine($"{index}. Date: {_date} - Prompt: {_promptText}");
        Console.WriteLine($"Entry: {_entryText}");
    }
}