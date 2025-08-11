using System;

abstract class Goal
{
    protected string _name;
    protected string _description;
    protected int _pointsPerCompletion;
    protected bool _isComplete;

    public string Name => _name;
    public string Description => _description;
    public int PointsPerCompletion => _pointsPerCompletion;
    public bool IsComplete => _isComplete;

    protected Goal(string name, string description, int pointsPerCompletion)
    {
        _name = name;
        _description = description;
        _pointsPerCompletion = pointsPerCompletion;
        _isComplete = false;
    }

    // Record event and update score
    public abstract void RecordEvent(ref int totalScore);

    // Show progress/status string
    public abstract string GetStatus();

    // Convert to string for saving
    public abstract string GetStringRepresentation();

    // Factory method to create from string for loading
    public static Goal CreateGoalFromString(string goalString)
    {
        // Format: Type:field1,field2,...
        var parts = goalString.Split(':');
        if (parts.Length != 2) return null;

        string type = parts[0];
        string[] fields = parts[1].Split(',');

        switch (type)
        {
            case "SimpleGoal":
                // name,description,points,isComplete
                var sg = new SimpleGoal(fields[0], fields[1], int.Parse(fields[2]));
                if (bool.Parse(fields[3])) sg.MarkCompleteForLoad();
                return sg;

            case "EternalGoal":
                // name,description,points
                return new EternalGoal(fields[0], fields[1], int.Parse(fields[2]));

            case "ChecklistGoal":
                // name,description,points,currentCount,targetCount,bonus,isComplete
                var cg = new ChecklistGoal(fields[0], fields[1], int.Parse(fields[2]), int.Parse(fields[4]), int.Parse(fields[5]));
                cg.SetCurrentCount(int.Parse(fields[3]));
                if (bool.Parse(fields[6])) cg.MarkCompleteForLoad();
                return cg;

            default:
                return null;
        }
    }
}
