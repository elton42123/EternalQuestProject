using System;

class SimpleGoal : Goal
{
    public SimpleGoal(string name, string description, int pointsPerCompletion)
        : base(name, description, pointsPerCompletion) { }

    public override void RecordEvent(ref int totalScore)
    {
        if (!_isComplete)
        {
            _isComplete = true;
            totalScore += _pointsPerCompletion;
            Console.WriteLine($"Goal '{_name}' completed! You earned {_pointsPerCompletion} points.");
        }
        else
        {
            Console.WriteLine($"Goal '{_name}' already completed.");
        }
    }

    public override string GetStatus()
    {
        return (_isComplete ? "[X] " : "[ ] ") + $"{_name} ({_description})";
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal:{_name},{_description},{_pointsPerCompletion},{_isComplete}";
    }

    // Helper for loading saved completion state
    public void MarkCompleteForLoad()
    {
        _isComplete = true;
    }
}
