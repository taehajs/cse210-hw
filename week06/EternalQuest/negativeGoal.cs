using System;

public class NegativeGoal : Goal
{
    private bool _isComplete;

    public NegativeGoal(string name, string description, int penaltyPoints) 
        : base(name, description, -Math.Abs(penaltyPoints))
    {
        _isComplete = false;
    }

    public override int RecordEvent()
    {
        if (!_isComplete)
        {
            _isComplete = true;
            return _points; 
        }
        return 0;
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetDetailsString()
    {
        string status = _isComplete ? "[X]" : "[ ]";
        return $"{status} {_shortName} ({_description}) - Penalty: {_points}";
    }

    public override string GetStringRepresentation()
    {
        return $"NegativeGoal|{_shortName}|{_description}|{_points}|{_isComplete}";
    }
}
