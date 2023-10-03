using System;

namespace NumberGuessingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            bool playAgain = true;
            Random random = new Random();

            while (playAgain)
            {
                int magicNumber = random.Next(1, 101);
                int guess;
                int attempts = 0;

                Console.WriteLine("Welcome to the Number Guessing Game!");
                Console.WriteLine("Think of a number between 1 and 100.");

                do
                {
                    Console.Write("What is your guess? ");
                    if (int.TryParse(Console.ReadLine(), out guess))
                    {
                        attempts++;

                        if (guess < magicNumber)
                        {
                            Console.WriteLine("Higher");
                        }
                        else if (guess > magicNumber)
                        {
                            Console.WriteLine("Lower");
                        }
                        else
                        {
                          Console.WriteLine($"You guessed it! It took you {attempts} attempts.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number.");
                    }
                } while (guess != magicNumber);

                Console.Write("Do you want to play again? (yes/no): ");
                string playAgainResponse = Console.ReadLine().ToLower();

                if (playAgainResponse != "yes")
                {
                    playAgain = false;
                }
            }

            Console.WriteLine("Thank you for playing! Goodbye.");
        }
    }
}
