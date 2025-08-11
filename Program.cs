using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    private static List<Goal> _goals = new List<Goal>();
    private static int _totalScore = 0;

    // Creative feature: Levels unlock fun titles every 1000 points
    private static void ShowLevel()
    {
        int level = _totalScore / 1000;
        string title = level switch
        {
            0 => "Beginner",
            1 => "Apprentice",
            2 => "Warrior",
            3 => "Champion",
            4 => "Legend",
            _ => "Eternal Hero"
        };
        Console.WriteLine($"Your level: {level} - {title}");
    }

    static void Main()
    {
        Console.WriteLine("Welcome to Eternal Quest!");

        LoadData();

        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Create new goal");
            Console.WriteLine("2. List goals");
            Console.WriteLine("3. Record event");
            Console.WriteLine("4. Show total score");
            Console.WriteLine("5. Save goals");
            Console.WriteLine("6. Load goals");
            Console.WriteLine("7. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1": CreateGoal(); break;
                case "2": ListGoals(); break;
                case "3": RecordEvent(); break;
                case "4": ShowScore(); break;
                case "5": SaveData(); break;
                case "6": LoadData(); break;
                case "7": 
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }

    private static void CreateGoal()
    {
        Console.WriteLine("Select goal type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Choice: ");
        string type = Console.ReadLine();

        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();
        Console.Write("Enter description: ");
        string description = Console.ReadLine();

        int points = GetIntInput("Enter points per completion: ");

        switch (type)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, description, points));
                break;
            case "2":
                _goals.Add(new EternalGoal(name, description, points));
                break;
            case "3":
                int target = GetIntInput("Enter number of times to complete goal: ");
                int bonus = GetIntInput("Enter bonus points upon completion: ");
                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                break;
            default:
                Console.WriteLine("Invalid goal type.");
                return;
        }
        Console.WriteLine("Goal created successfully!");
    }

    private static int GetIntInput(string prompt)
    {
        int val;
        while (true)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out val) && val >= 0)
                return val;
            Console.WriteLine("Invalid input. Please enter a non-negative integer.");
        }
    }

    private static void ListGoals()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals to show.");
            return;
        }

        Console.WriteLine("Goals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetStatus()}");
        }
    }

    private static void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals available.");
            return;
        }

        Console.WriteLine("Select a goal to record progress:");
        ListGoals();

        int choice = GetIntInput("Goal number: ");
        if (choice < 1 || choice > _goals.Count)
        {
            Console.WriteLine("Invalid goal number.");
            return;
        }

        _goals[choice - 1].RecordEvent(ref _totalScore);
        ShowLevel();
    }

    private static void ShowScore()
    {
        Console.WriteLine($"Your total score is: {_totalScore}");
        ShowLevel();
    }

    private static void SaveData()
    {
        string filename = "goals.txt";
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_totalScore);
            foreach (var goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine($"Data saved to {filename}");
    }

    private static void LoadData()
    {
        string filename = "goals.txt";
        if (!File.Exists(filename))
        {
            Console.WriteLine("No saved data found.");
            return;
        }

        try
        {
            string[] lines = File.ReadAllLines(filename);
            _goals.Clear();
            _totalScore = int.Parse(lines[0]);

            for (int i = 1; i < lines.Length; i++)
            {
                Goal g = Goal.CreateGoalFromString(lines[i]);
                if (g != null)
                    _goals.Add(g);
            }
            Console.WriteLine("Data loaded successfully.");
            ShowLevel();
        }
        catch
        {
            Console.WriteLine("Failed to load data. File may be corrupted.");
        }
    }
}
