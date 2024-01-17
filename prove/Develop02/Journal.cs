using System;
using System.ComponentModel;
using System.IO;
public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        if (_entries.Count > 0)
        {
            int index = 1;
            foreach (Entry entry in _entries)
            {
                entry.Display(index);
                index++;
            }
        }
        else
        {
            Console.WriteLine("You don't have any entries.");
            Console.WriteLine("Start by adding one with option 1.");
        }
        
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine($"{entry._date}||{entry._promptText}||{entry._entryText}");
            }
        }
    }

    public void LoadFromFile(string filename)
    {
        _entries = new List<Entry>();
        string[] lines = File.ReadAllLines(filename);

        foreach (string line in lines)
        {
            Entry newEntry = new Entry();
            string[] parts = line.Split("||");
            newEntry._date = parts[0];
            newEntry._promptText = parts[1];
            newEntry._entryText = parts[2];
            _entries.Add(newEntry);
        }
    }
    
    public void DeleteEntry(int index)
    {
        if (index < _entries.Count && index >= 0)
        {
            _entries.RemoveAt(index);
            Console.WriteLine("Entry successfully deleted.");
        }
        else
        {
            Console.WriteLine("Invalid choice.");
            Console.WriteLine("Please choose a number to the left of the entry.");
        }
        
    }
}