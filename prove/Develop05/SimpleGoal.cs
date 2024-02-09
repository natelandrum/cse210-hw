using System.Reflection.Metadata.Ecma335;

public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points) : base(name, description, points)
    {
        _isComplete = false;
    }

    public override int RecordEvent()
    {
        if (IsComplete())
        {
            return 0;
        }
        else
        {
            _isComplete = true;
            return _points;
        }
        
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override GoalJSON GetStringRepresentation()
    {
        return new GoalJSON()
        {
            Type = "SimpleGoal",
            Name = _name,
            Description = _description,
            Points = _points,
            Properties = new List<int> { _isComplete ? 1 : 0 }
        };
    }
}