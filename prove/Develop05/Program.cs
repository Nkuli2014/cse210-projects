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
        // Prevent marking eternal goals as completed
        // Additional logic for recording events specific to eternal goals can be added if needed
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
        Console.WriteLine("Welcome to the Eternal Quest Manager!");

        EternalQuestManager manager = new EternalQuestManager();

        while (true)
        {
            Console.WriteLine("Select an option:");
            Console.WriteLine("1. Add Goal");
            Console.WriteLine("2. Record Event");
            Console.WriteLine("3. Display Goals");
            Console.WriteLine("4. Display Score");
            Console.WriteLine("5. Exit");

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        Console.Write("Enter the goal name: ");
                        string goalName = Console.ReadLine();

                        int goalValue = 0; // Initialize to a default value
                        bool validInput = false;

                        while (!validInput)
                        {
                            Console.Write("Enter the goal value: ");
                            string input = Console.ReadLine();

                            if (int.TryParse(input, out goalValue))
                            {
                                validInput = true;
                            }
                            else
                            {
                                Console.WriteLine("Invalid input. Please enter a valid number.");
                            }
                        }

                        manager.AddGoal(new SimpleGoal(goalName, goalValue));
                        break;

                    case 2:
                        Console.Write("Enter the goal index to record an event: ");
                        if (int.TryParse(Console.ReadLine(), out int goalIndex))
                        {
                            manager.RecordEvent(goalIndex - 1); // Adjust index by 1 for user-friendly input
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a valid number.");
                        }
                        break;

                    case 3:
                        manager.DisplayGoals();
                        break;

                    case 4:
                        Console.WriteLine($"Score: {manager.GetScore()}");
                        break;

                    case 5:
                        Console.WriteLine("Exiting the Eternal Quest Manager. Goodbye!");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }
    }
}
