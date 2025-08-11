using System;

class ChecklistGoal : Goal
{
    private int _currentCount;
    private int _targetCount;
    private int _bonusPoints;

    public ChecklistGoal(string name, string description, int pointsPerCompletion, int targetCount, int bonusPoints)
        : base(name, description, pointsPerCompletion)
    {
        _targetCount = targetCount;
        _bonusPoints = bonusPoints;
        _currentCount = 0;
    }

    public override void RecordEvent(ref int totalScore)
    {
        if (!_isComplete)
        {
            _currentCount++;
            totalScore += _pointsPerCompletion;
            Console.WriteLine($"Progress made on '{_name}'. You earned {_pointsPerCompletion} points.");

            if (_currentCount >= _targetCount)
            {
                _isComplete = true;
                totalScore += _bonusPoints;
                Console.WriteLine($"Goal '{_name}' completed! Bonus {_bonusPoints} points awarded.");
            }
        }
        else
        {
            Console.WriteLine($"Goal '{_name}' is already completed.");
        }
    }

    public override string GetStatus()
    {
        string checkMark = _isComplete ? "[X]" : "[ ]";
        return $"{checkMark} {_name} ({_description}) Completed {_currentCount}/{_targetCount}";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{_name},{_description},{_pointsPerCompletion},{_currentCount},{_targetCount},{_bonusPoints},{_isComplete}";
    }

    public void SetCurrentCount(int count)
    {
        _currentCount = count;
    }

    public void MarkCompleteForLoad()
    {
        _isComplete = true;
    }
}
