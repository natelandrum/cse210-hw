public class Video
{
    public string _title;
    public string _author;
    public int _length;
    public List<Comment> _comments = new List<Comment>();


    public int NumberOfComments()
    {
        return _comments.Count;
    }

    public void DisplayComments()
    {
        foreach (Comment comment in _comments)
        {
            comment.CommentStringRepresentation();
        }
    }
}