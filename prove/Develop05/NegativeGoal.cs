public class NegativeGoal : Goal
{
    public NegativeGoal(string name, string description, int points) : base(name, description, points)
    {

    }

    public override int RecordEvent()
    {
        return -_points;
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override GoalJSON GetStringRepresentation()
    {
        return new GoalJSON()
        {
            Type = "NegativeGoal",
            Name = _name,
            Description = _description,
            Points = _points,
            Properties = new List<int> { IsComplete()? 1 : 0}
        };
    }

}