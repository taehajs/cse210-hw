using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    private Random _random;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
        _random = new Random();
    }

    public void Start()
    {
        int choice = 0;
        while (choice != 7)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Display Player Info");
            Console.WriteLine("2. List Goal Names");
            Console.WriteLine("3. List Goal Details");
            Console.WriteLine("4. Create Goal");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Save/Load Goals");
            Console.WriteLine("7. Quit");
            Console.Write("Choose an option: ");
            
            choice = int.Parse(Console.ReadLine() ?? "7");

            switch (choice)
            {
                case 1:
                    DisplayPlayerInfo();
                    break;
                case 2:
                    ListGoalNames();
                    break;
                case 3:
                    ListGoalDetails();
                    break;
                case 4:
                    CreateGoal();
                    break;
                case 5:
                    RecordEvent();
                    break;
                case 6:
                    SaveOrLoad();
                    break;
                case 7:
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }

    private void DisplayPlayerInfo()
    {
        Console.WriteLine($"\nYour current score: {_score}");
    }

    private void ListGoalNames()
    {
        Console.WriteLine("\nGoals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    private void ListGoalDetails()
    {
        Console.WriteLine("\nGoal Details:");
        foreach (Goal goal in _goals)
        {
            Console.WriteLine(goal.GetDetailsString());
        }
    }

    private void CreateGoal()
    {
        Console.WriteLine("\nWhich type of goal?");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.WriteLine("4. Negative Goal");
        Console.Write("Choose: ");
        int type = int.Parse(Console.ReadLine() ?? "1");

        Console.Write("Enter name: ");
        string name = Console.ReadLine();
        Console.Write("Enter description: ");
        string description = Console.ReadLine();
        Console.Write("Enter points: ");
        int points = int.Parse(Console.ReadLine() ?? "0");

        Goal newGoal = null;
        switch (type)
        {
            case 1:
                newGoal = new SimpleGoal(name, description, points);
                break;
            case 2:
                newGoal = new EternalGoal(name, description, points);
                break;
            case 3:
                Console.Write("Enter target count: ");
                int target = int.Parse(Console.ReadLine() ?? "1");
                Console.Write("Enter bonus: ");
                int bonus = int.Parse(Console.ReadLine() ?? "0");
                newGoal = new ChecklistGoal(name, description, points, target, bonus);
                break;
            case 4:
                Console.Write("Enter penalty points: ");
                int penalty = int.Parse(Console.ReadLine() ?? "0");
                newGoal = new NegativeGoal(name, description, penalty);
                break;
        }

        if (newGoal != null)
        {
            _goals.Add(newGoal);
            Console.WriteLine("Goal created!");
        }
    }

    private void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals to record.");
            return;
        }

        Console.WriteLine("\nWhich goal did you accomplish?");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
        Console.Write("Choose: ");
        int index = int.Parse(Console.ReadLine() ?? "1") - 1;

        if (index >= 0 && index < _goals.Count)
        {
            int points = _goals[index].RecordEvent();
            _score += points;
            Console.WriteLine($"Event recorded! You earned {points} points. Total: {_score}");
        }
    }

    private void SaveOrLoad()
    {
        Console.WriteLine("\n1. Save Goals");
        Console.WriteLine("2. Load Goals");
        Console.Write("Choose: ");
        int choice = int.Parse(Console.ReadLine() ?? "1");

        if (choice == 1)
        {
            SaveGoals();
        }
        else if (choice == 2)
        {
            LoadGoals();
        }
    }

    private void SaveGoals()
    {
        using (StreamWriter writer = new StreamWriter("goals.txt"))
        {
            writer.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine("Goals saved!");
    }

    private void LoadGoals()
    {
        if (!File.Exists("goals.txt"))
        {
            Console.WriteLine("No saved goals found.");
            return;
        }

        string[] lines = File.ReadAllLines("goals.txt");
        _score = int.Parse(lines[0]);
        _goals.Clear();

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split('|');
            string type = parts[0];

            switch (type)
            {
                case "SimpleGoal":
                    _goals.Add(new SimpleGoal(parts[1], parts[2], int.Parse(parts[3])) { });
                    break;
                case "EternalGoal":
                    _goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3])));
                    break;
                case "ChecklistGoal":
                    ChecklistGoal checklist = new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[5]), int.Parse(parts[4]));
                    for (int j = 0; j < int.Parse(parts[6]); j++)
                    {
                        checklist.RecordEvent();
                    }
                    _goals.Add(checklist);
                    break;
                case "NegativeGoal":
                    NegativeGoal neg = new NegativeGoal(parts[1], parts[2], int.Parse(parts[3]));
                    if (bool.Parse(parts[4]))
                    {
                        neg.RecordEvent();
                    }
                    _goals.Add(neg);
                    break;
            }
        }

        Console.WriteLine("Goals loaded!");
    }
}
