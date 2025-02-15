using System;
using System.Collections.Generic;
using System.IO;

abstract class Goal
{
    public string Name { get; set; }
    public int Points { get; set; }
    public abstract void Complete();
    public abstract string GetStatus();
}

class SimpleGoal : Goal
{
    private bool _isCompleted;
    
    public SimpleGoal(string name, int points)
    {
        Name = name;
        Points = points;
        _isCompleted = false;
    }

    public override void Complete()
    {
        if (!_isCompleted)
        {
            _isCompleted = true;
            Console.WriteLine($"Goal '{Name}' completed!✅ You earned {Points} points.");
        }
        else
        {
            Console.WriteLine($"Goal '{Name}' was already completed.🎯");
        }
    }

    public override string GetStatus()
    {
        return _isCompleted ? "[X]" : "[ ]";
    }
}

class EternalGoal : Goal
{
    public EternalGoal(string name, int points)
    {
        Name = name;
        Points = points;
    }

    public override void Complete()
    {
        Console.WriteLine($"Goal '{Name}' recorded! You earned {Points} points.🏆");
    }

    public override string GetStatus()
    {
        return "[∞]";
    }
}

class ChecklistGoal : Goal
{
    private int _currentCount;
    private int _targetCount;
    private int _bonusPoints;

    public ChecklistGoal(string name, int points, int targetCount, int bonusPoints)
    {
        Name = name;
        Points = points;
        _targetCount = targetCount;
        _bonusPoints = bonusPoints;
        _currentCount = 0;
    }

    public override void Complete()
    {
        _currentCount++;
        Console.WriteLine($"Progress: {_currentCount}/{_targetCount} for '{Name}🚶‍♀️'");
        if (_currentCount >= _targetCount)
        {
            Console.WriteLine($"Goal '{Name}' fully completed! 🚶‍♀️ Bonus {Points + _bonusPoints} points awarded.🏆");
        }
    }

    public override string GetStatus()
    {
        return $"Progress: [{_currentCount}/{_targetCount}]🚶‍♀️";

    }
}

class Program
{
    static List<Goal> goals = new List<Goal>();

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("1. Add Simple Goal🎯");
            Console.WriteLine("2. Add Eternal Goal🌞");
            Console.WriteLine("3. Add Checklist Goal");
            Console.WriteLine("4. View Goals✅");
            Console.WriteLine("5. Complete a Goal🏁");
            Console.WriteLine("6. Exit🔚");
            Console.Write("Choose an option🤔: ");
            
            int choice = int.Parse(Console.ReadLine());
            if (choice == 6) break;
            
            switch (choice)
            {
                case 1:
                    Console.Write("Enter goal name 🤩: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter points 🥇: ");
                    int points = int.Parse(Console.ReadLine());
                    goals.Add(new SimpleGoal(name, points));
                    break;
                case 2:
                    Console.Write("Enter goal name 🤩: ");
                    string eternalName = Console.ReadLine();
                    Console.Write("Enter points 🥇: ");
                    int eternalPoints = int.Parse(Console.ReadLine());
                    goals.Add(new EternalGoal(eternalName, eternalPoints));
                    break;
                case 3:
                    Console.Write("Enter goal name 🤩: ");
                    string checklistName = Console.ReadLine();
                    Console.Write("Enter points per completion 🥇: ");
                    int checklistPoints = int.Parse(Console.ReadLine());
                    Console.Write("Enter target count 🎯: ");
                    int targetCount = int.Parse(Console.ReadLine());
                    Console.Write("Enter bonus points ✨: ");
                    int bonusPoints = int.Parse(Console.ReadLine());
                    goals.Add(new ChecklistGoal(checklistName, checklistPoints, targetCount, bonusPoints));
                    break;
                case 4:
                    Console.WriteLine("Your Goals:");
                    foreach (var goal in goals)
                    {
                        Console.WriteLine($"{goal.GetStatus()} {goal.Name}");
                    }
                    break;
                case 5:
                    Console.WriteLine("Enter the index of the goal to complete ❗:");
                    for (int i = 0; i < goals.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {goals[i].Name}");
                    }
                    int goalIndex = int.Parse(Console.ReadLine()) - 1;
                    if (goalIndex >= 0 && goalIndex < goals.Count)
                    {
                        goals[goalIndex].Complete();
                    }
                    else
                    {
                        Console.WriteLine("Invalid index.❗");
                    }
                    break;
            }
        }
    }
}
