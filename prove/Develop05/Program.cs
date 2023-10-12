using System;
using System.Collections.Generic;
using System.IO;

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
        // Award points for completing the simple goal
    }
}

// Define a class for eternal goals
class EternalGoal : Goal
{
    public EternalGoal(string name, int value) : base(name, value)
    {
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
            // Award bonus points for completing the checklist goal
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

    public List<Goal> Goals => goals; // Add this property

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
        EternalQuestManager questManager = new EternalQuestManager();

        while (true)
        {
            Console.WriteLine("Eternal Quest Program");
            Console.WriteLine("1. Add Goal");
            Console.WriteLine("2. Record Event");
            Console.WriteLine("3. Display Goals");
            Console.WriteLine("4. Show Score");
            Console.WriteLine("5. Quit");

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                if (choice == 1)
                {
                    Console.Write("Enter the goal name: ");
                    string goalName = Console.ReadLine();
                    Console.Write("Enter the goal type (1 for Simple, 2 for Eternal, 3 for Checklist): ");
                    int goalType = int.Parse(Console.ReadLine());
                    Console.Write("Enter the goal value: ");
                    int goalValue = int.Parse(Console.ReadLine());

                    Goal goal;
                    if (goalType == 1)
                    {
                        goal = new SimpleGoal(goalName, goalValue);
                    }
                    else if (goalType == 2)
                    {
                        goal = new EternalGoal(goalName, goalValue);
                    }
                    else if (goalType == 3)
                    {
                        Console.Write("Enter the required count for the checklist goal: ");
                        int requiredCount = int.Parse(Console.ReadLine());
                        goal = new ChecklistGoal(goalName, goalValue, requiredCount);
                    }
                    else
                    {
                        Console.WriteLine("Invalid goal type.");
                        continue;
                    }

                    questManager.AddGoal(goal);
                    Console.WriteLine("Goal added.");
                }
                else if (choice == 2)
                {
                    Console.WriteLine("Select a goal to record an event:");
                    questManager.DisplayGoals();
                    int goalIndex = int.Parse(Console.ReadLine()) - 1;
                    questManager.RecordEvent(goalIndex);
                    Console.WriteLine("Event recorded.");
                }
                else if (choice == 3)
                {
                    questManager.DisplayGoals();
                }
                else if (choice == 4)
                {
                    Console.WriteLine($"Score: {questManager.GetScore()}");
                }
                               else if (choice == 5)
                {
                    // Save goals and score to a file (serialization)
                    using (StreamWriter writer = new StreamWriter("goals.txt"))
                    {
                        foreach (Goal goal in questManager.Goals)
                        {
                            writer.WriteLine($"{goal.Name},{goal.Value},{goal.Completed}");
                        }
                        writer.WriteLine($"Score,{questManager.GetScore()}");
                    }

                    Console.WriteLine("Thank you for using the Eternal Quest Program!");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }
    }
}

