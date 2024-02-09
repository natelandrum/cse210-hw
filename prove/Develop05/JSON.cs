public class GoalJSON
{
    public string Type { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Points { get; set; }
    public List<int> Properties { get; set; }
}

public class ScoreJSON
{
    public int Score { get; set; }
}
