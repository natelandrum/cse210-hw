using System.Runtime;

public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;
    
    public ChecklistGoal(string name, string description, int points, int target, int bonus) : base(name, description, points)
    {
        _amountCompleted = 0;
        _target = target;
        _bonus = bonus;
    }

    public override int RecordEvent()
    {
        if (IsComplete())
        {
            return 0;
        }
        else
        {
            _amountCompleted += 1;
            return _amountCompleted == _target ? _points + _bonus : _points;
        }
    }

    public override bool IsComplete()
    {
        return _amountCompleted == _target;
    }

    public override string GetDetailsString()
    {
        return $"{base.GetDetailsString()} -- Currently completed: {_amountCompleted}/{_target}";
    }
    public override GoalJSON GetStringRepresentation()
    {
        return new GoalJSON()
        {
            Type = "ChecklistGoal",
            Name = _name,
            Description = _description,
            Points = _points,
            Properties = new List<int> { _amountCompleted, _target, _bonus }
        };
    }

    
}