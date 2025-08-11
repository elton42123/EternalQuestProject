using System;

class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int pointsPerCompletion)
        : base(name, description, pointsPerCompletion) { }

    public override void RecordEvent(ref int totalScore)
    {
        totalScore += _pointsPerCompletion;
        Console.WriteLine($"Goal '{_name}' recorded! You earned {_pointsPerCompletion} points.");
    }

    public override string GetStatus()
    {
        return "[∞] " + $"{_name} ({_description})";
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal:{_name},{_description},{_pointsPerCompletion}";
    }
}
