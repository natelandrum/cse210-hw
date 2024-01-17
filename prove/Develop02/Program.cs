// To exceed expectations:
// Added a DeleteEntry method to Journal Class
// Added data validation to user input
// Checks file to load exists


using System;
using System.ComponentModel;
using System.Security.Cryptography;

class Program
{
    static void Main(string[] args)
    {
        Journal myJournal = new Journal();

        PromptGenerator myPromptGenerator = new PromptGenerator();
        myPromptGenerator._prompts.Add("Who was the most interesting person I interacted with today?");
        myPromptGenerator._prompts.Add("What was the best part of my day?");
        myPromptGenerator._prompts.Add("How did I see the hand of the Lord in my life today?");
        myPromptGenerator._prompts.Add("What was the strongest emotion I felt today?");
        myPromptGenerator._prompts.Add("If I had one thing I could do over today, what would it be?");
        myPromptGenerator._prompts.Add("What can I do better tomorrow?");
        myPromptGenerator._prompts.Add("What am I grateful for today?");
        myPromptGenerator._prompts.Add("Did I learn anything new today?");
        myPromptGenerator._prompts.Add("What was the most challenging part of my day?");
        myPromptGenerator._prompts.Add("What was the most spiritual part of my day?");
        myPromptGenerator._prompts.Add("What was the funniest thing that happened today?");
        myPromptGenerator._prompts.Add("Did I meet someone new today? If not, why?");

        Console.WriteLine("Welcome to the Journal Program!");

        while (true)
        {
            Console.WriteLine("");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Delete");
            Console.WriteLine("6. Quit");
            Console.Write("What would you like to do? ");

            string choice = Console.ReadLine();
            int choiceInt = 0;

            // https://stackoverflow.com/questions/1752499/c-sharp-testing-to-see-if-a-string-is-an-integer
            if (int.TryParse(choice, out int result))
            {
                choiceInt = result;
            }

            if (choiceInt == 6)
            {
                break;
            }
            // https://www.w3schools.com/cs/cs_switch.php
            switch (choiceInt)
            {
                case 1:
                    Entry newEntry = new Entry();

                    newEntry._date = DateTime.Now.ToShortDateString();

                    string newPrompt = myPromptGenerator.GetRandomPrompt();
                    newEntry._promptText = newPrompt;

                    Console.WriteLine(newPrompt);
                    Console.Write("> ");
                    newEntry._entryText = Console.ReadLine();

                    myJournal.AddEntry(newEntry);
                    break;

                case 2:
                    myJournal.DisplayAll();
                    break;

                case 3:
                    Console.Write("What file would you like to load? ");
                    string loadFile = Console.ReadLine();
                    if (!File.Exists(loadFile))
                    {
                        Console.WriteLine("Invalid file name.");
                    }
                    else
                    {
                        myJournal.LoadFromFile(loadFile);
                        Console.WriteLine("File loaded Successfully.");
                    }
                    break;

                case 4:
                    Console.Write("What file would you like to save to? ");
                    string saveFile = Console.ReadLine();
                    if (saveFile != "")
                    {
                        myJournal.SaveToFile(saveFile);
                        Console.WriteLine("File saved.");
                    }
                    else
                    {
                        Console.WriteLine("You must provide a filename.");
                    }
                    break;

                case 5:
                    myJournal.DisplayAll();
                    if (myJournal._entries.Count > 0)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Which entry would you like to delete?");
                        Console.Write("Use the number to the entry's left. ");
                        string index = Console.ReadLine();
                        if (int.TryParse(index, out int result2)) 
                        {
                            myJournal.DeleteEntry(result2 - 1);
                        }
                        else
                        {
                            Console.WriteLine("Invalid choice.");
                        }
                    }
                    break;

                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }
}