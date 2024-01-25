using System.ComponentModel.DataAnnotations;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words = new List<Word>();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;

        string[] splitText = text.Split(" ");

        foreach (string word in splitText)
        {
            _words.Add(new Word(word));
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        int hiddenWords = 0;

        while (hiddenWords < numberToHide && !IsCompletelyHidden())
        {
            Random rnd = new Random();

            int randomIndex = rnd.Next(0, _words.Count);

            if (!_words[randomIndex].IsHidden())
            {
                _words[randomIndex].Hide();
                hiddenWords++;
            }
        }
    }

    public void UnhideAllWords()
    {
        foreach (Word word in _words)
        {
            word.Show();
        }
    }

    public string GetDisplayText()
    {
        string displayText = $"{_reference.GetDisplayText()}\n\n";

        

        foreach (Word word in _words)
        {
            displayText += $"{word.GetDisplayText()} ";
        }

        return displayText;
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }
        return true;
    }
}