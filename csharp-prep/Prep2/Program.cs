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

                // Validate the input percentage
                if (gradePercentage < 0 || gradePercentage > 100)
                {
                    Console.WriteLine("Invalid input. Please enter a valid percentage between 0 and 100.");
                }
                else
                {
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
                    int lastDigit = (int)(gradePercentage % 10);
                    if (gradeLetter != "F")
                    {
                        if (lastDigit >= 7)
                        {
                            gradeSign = "+";
                        }
                        else if (lastDigit <= 2)
                        {
                            gradeSign = "-";
                        }
                    }

                    // Display the grade and message
                    Console.WriteLine($"Your letter grade is: {gradeLetter}{gradeSign}");

                    // Check if the user passed the course and display a message
                    if (gradePercentage >= 70 && gradeLetter != "F")
                    {
                        Console.WriteLine("Congratulations! You passed the course.");
                    }
                    else
                    {
                        Console.WriteLine("Better luck next time! Keep working hard.");
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid percentage.");
            }
        }
    }
}
