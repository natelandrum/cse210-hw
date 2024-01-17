using System;

public class PromptGenerator
{
    public List<string> _prompts = new List<string>();

    public string GetRandomPrompt()
    {
        // https://stackoverflow.com/questions/2706500/how-do-i-generate-a-random-integer-in-c
        Random rnd = new Random();

        if (_prompts.Count > 0)
        {
            int index = rnd.Next(0, _prompts.Count);
            string prompt = _prompts[index];
            _prompts.RemoveAt(index);
            return prompt;
        }
        else 
        {
            return "No more available prompts. Write something meaningful about your day.";
        }
    }
}