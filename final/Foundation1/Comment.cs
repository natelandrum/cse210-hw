public class Comment
{
    public string _text;
    public string _author;

    public void CommentStringRepresentation()
    {
        Console.WriteLine($"{_text} - {_author}\n");
    }
}