using System;

        class Program
{
    static void Main(string[] args)
    {
        using System;

namespace GradeCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ask the user for their grade percentage
            Console.Write("Enter your grade percentage: ");
            if (double.TryParse(Console.ReadLine(), out double gradePercentage))
            {
                // Initialize variables for grade letter and sign
                string gradeLetter = "";
                string gradeSign = "";

                // Determine the grade letter
                if (gradePercentage >= 90)
                {
                    gradeLetter = "A";
                }
                else if (gradePercentage >= 80)
                {
                    gradeLetter = "B";
                }
                else if (gradePercentage >= 70)
                {
                    gradeLetter = "C";
                }
                else if (gradePercentage >= 60)
                {
                    gradeLetter = "D";
                }
                else
                {
                    gradeLetter = "F";
                }

                // Determine the grade sign
                int lastDigit = (int)gradePercentage % 10;
                if (gradeLetter != "F" && lastDigit >= 7)
                {
                    gradeSign = "+";
                }
                else if (gradeLetter != "F" && lastDigit < 3)
                {
                    gradeSign = "-";
                }

                // Display the grade and message
                Console.WriteLine($"Your letter grade is: {gradeLetter}{gradeSign}");

                // Check if the user passed the course and display a message
                if (gradePercentage >= 70)
                {
                    Console.WriteLine("Congratulations! You passed the course.");
                }
                else
                {
                    Console.WriteLine("Better luck next time! Keep working hard.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid percentage.");
            }
        }
    }
}
    }
}
    }
}