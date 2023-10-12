using System;
using System.Threading;

// Define a base class for mindfulness activities
class MindfulnessActivity
{
    public string Name { get; protected set; }
    public string Description { get; protected set; }
    public int Duration { get; protected set; }

    public MindfulnessActivity(string name, string description)
    {
        Name = name;
        Description = description;
        Duration = 0; // Default duration (in seconds)
    }

    public virtual void Start()
    {
        Console.WriteLine($"Starting {Name} Activity");
        Console.WriteLine(Description);
        Console.WriteLine($"Duration: {Duration} seconds");
        Thread.Sleep(2000); // Pause for 2 seconds before starting
    }

    public virtual void End()
    {
        Console.WriteLine($"Congratulations! You've completed the {Name} Activity.");
        Console.WriteLine($"Duration: {Duration} seconds");
        Thread.Sleep(2000); // Pause for 2 seconds before finishing
    }
}

// Define a class for Breathing Activity
class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity() : base("Breathing", "This activity will help you relax by guiding you through deep breathing.")
    {
    }

    public override void Start()
    {
        base.Start();
        // Implement the Breathing Activity here
    }
}

// Define a class for Reflection Activity
class ReflectionActivity : MindfulnessActivity
{
    public ReflectionActivity() : base("Reflection", "This activity will help you reflect on past experiences and strengths.")
    {
    }

    public override void Start()
    {
        base.Start();
        // Implement the Reflection Activity here
    }
}

// Define a class for Listing Activity
class ListingActivity : MindfulnessActivity
{
    public ListingActivity() : base("Listing", "This activity will help you list positive things in your life.")
    {
    }

    public override void Start()
    {
        base.Start();
        // Implement the Listing Activity here
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Mindfulness Program!");
        while (true)
        {
            Console.WriteLine("Choose an activity:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                if (choice == 1)
                {
                    BreathingActivity breathingActivity = new BreathingActivity();
                    breathingActivity.Start();
                    // Implement breathing activity logic
                    breathingActivity.End();
                }
                else if (choice == 2)
                {
                    ReflectionActivity reflectionActivity = new ReflectionActivity();
                    reflectionActivity.Start();
                    // Implement reflection activity logic
                    reflectionActivity.End();
                }
                else if (choice == 3)
                {
                    ListingActivity listingActivity = new ListingActivity();
                    listingActivity.Start();
                    // Implement listing activity logic
                    listingActivity.End();
                }
                else if (choice == 4)
                {
                    break; // Quit the program
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please select a valid activity or 'Quit'.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }

        Console.WriteLine("Thank you for using the Mindfulness Program!");
    }
}
