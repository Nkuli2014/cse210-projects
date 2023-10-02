using System;

class Program
{
    static void Main(string[] args)
    {
        using System;
using System.Collections.Generic;
using System.Linq;

namespace NumberListAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            int number;
            
            Console.WriteLine("Enter a list of numbers, type 0 when finished.");
            
            do
            {
                Console.Write("Enter number: ");
                if (int.TryParse(Console.ReadLine(), out number))
                {
                    if (number != 0)
                    {
                        numbers.Add(number);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            } while (number != 0);
            
            if (numbers.Count == 0)
            {
                Console.WriteLine("No numbers entered.");
                return;
            }

            // Core Requirement 1: Compute the sum of the numbers
            int sum = numbers.Sum();

            // Core Requirement 2: Compute the average of the numbers
            double average = (double)sum / numbers.Count;

            // Core Requirement 3: Find the maximum number
            int maxNumber = numbers.Max();

            Console.WriteLine($"The sum is: {sum}");
            Console.WriteLine($"The average is: {average}");
            Console.WriteLine($"The largest number is: {maxNumber}");

            // Stretch Challenge 1: Find the smallest positive number
            int smallestPositive = numbers.Where(n => n > 0).Min();
            Console.WriteLine($"The smallest positive number is: {smallestPositive}");

            // Stretch Challenge 2: Sort the list
            List<int> sortedNumbers = numbers.OrderBy(n => n).ToList();
            Console.WriteLine("The sorted list is:");
            foreach (var num in sortedNumbers)
            {
                Console.WriteLine(num);
            }
        }
    }
}