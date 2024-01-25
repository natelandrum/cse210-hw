// Added a ParseJson class to handle my json file format
// Removed unused constuctor in Reference class
// Choose random scripture mastery scripture from json file
// Added method to Scripture class to unhide all words


using System;
using System.Diagnostics;
using System.Runtime.Intrinsics.Arm;
using System.Security;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Xml.Serialization;

class Program
{
    static void Main(string[] args)
    {
        Reference r;
        Scripture s;

        using (StreamReader f = new StreamReader("scriptures.json"))
            {
                string json = f.ReadToEnd();
                List<ParseJson> parsedJson = JsonSerializer.Deserialize<List<ParseJson>>(json);

                Random rnd = new Random();
                int randomIndex = rnd.Next(0, parsedJson.Count);
                ParseJson rndScripture = parsedJson[randomIndex];

                r = new Reference(rndScripture.book, rndScripture.chapter, rndScripture.startVerse, rndScripture.endVerse);
                s = new Scripture(r, rndScripture.scripture);
            }  

        string input;
        do
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine(s.GetDisplayText());

            if (s.IsCompletelyHidden())
            {
                break;
            }

            Console.WriteLine();
            Console.WriteLine("Press enter to continue, type 'quit' to finish,");
            Console.Write("or type 'show' to show the whole scripture again: ");
            input = Console.ReadLine();

            if (input =="show")
            {
                s.UnhideAllWords();
                continue;
            }

            Random rnd = new Random();
            int randomInt = rnd.Next(3, 7);
            s.HideRandomWords(randomInt);

        } while (input != "quit");
        
    }
}