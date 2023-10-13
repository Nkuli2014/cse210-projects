using System;
using System.Collections.Generic;

// Define a base class for goals
class Goal
{
    public string Name { get; protected set; }
    public int Value { get; protected set; }
    public bool Completed { get; protected set; }

    public Goal(string name, int value)
    {
        Name = name;
        Value = value;
        Completed = false;
    }

    public virtual void RecordEvent()
    {
        Completed = true;
    }

    public virtual string GetStatus()
    {
        return Completed ? "[X]" : "[ ]";
    }
}

// Define a class for simple goals
class SimpleGoal : Goal
{
    public SimpleGoal(string name, int value) : base(name, value)
    {
    }

    public override void RecordEvent()
    {
        base.RecordEvent();
        // Additional logic for recording events specific to simple goals
    }
}

// Define a class for eternal goals
class EternalGoal : Goal
{
    public EternalGoal(string name, int value) : base(name, value)
    {
    }

    public override void RecordEvent()
    {
        // Override the base method if needed
        base.RecordEvent();
        // Additional logic for recording events specific to eternal goals
    }
}

// Define a class for checklist goals
class ChecklistGoal : Goal
{
    private int currentCount;
    private int requiredCount;

    public ChecklistGoal(string name, int value, int requiredCount) : base(name, value)
    {
        this.requiredCount = requiredCount;
        currentCount = 0;
    }

    public override void RecordEvent()
    {
        currentCount++;
        if (currentCount >= requiredCount)
        {
            base.RecordEvent();
            // Additional logic for recording events specific to checklist goals
        }
    }

    public override string GetStatus()
    {
        return $"{base.GetStatus()} Completed {currentCount}/{requiredCount} times";
    }
}

// Define a class to manage goals and scores
class EternalQuestManager
{
    private List<Goal> goals;
    private int score;

    public EternalQuestManager()
    {
        goals = new List<Goal>();
        score = 0;
    }

    public void AddGoal(Goal goal)
    {
        goals.Add(goal);
    }

    public void RecordEvent(int goalIndex)
    {
        if (goalIndex >= 0 && goalIndex < goals.Count)
        {
            Goal goal = goals[goalIndex];
            if (!goal.Completed)
            {
                goal.RecordEvent();
                score += goal.Value;
            }
        }
    }

    public void DisplayGoals()
    {
        Console.WriteLine("Goals:");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].GetStatus()} {goals[i].Name}");
        }
    }

    public int GetScore()
    {
        return score;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Your existing code here
    }
}