using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;

// Define a class to represent a word in the scripture
class ScriptureWord
{
    public string Word { get; set; }
    public bool Hidden { get; set; }

    public ScriptureWord(string word)
    {
        Word = word;
        Hidden = false;
    }
}

// Define a class to represent the scripture reference (e.g., "John 3:16")
class ScriptureReference
{
    public string Reference { get; private set; }

    public ScriptureReference(string reference)
    {
        Reference = reference;
    }
}

// Define a class to represent the scripture
class Scripture
{
    private List<ScriptureWord> words;
    private ScriptureReference reference;

    public Scripture(string reference, string text)
    {
        this.reference = new ScriptureReference(reference);
        this.words = text.Split(' ').Select(word => new ScriptureWord(word)).ToList();
    }

    public void Display()
    {
        Console.WriteLine($"{reference.Reference}:");
        foreach (var word in words)
        {
            if (word.Hidden)
            {
                Console.Write("**** ");
            }
            else
            {
                Console.Write(word.Word + " ");
            }
        }
        Console.WriteLine();
    }

    public bool HideRandomWord()
    {
        var visibleWords = words.Where(word => !word.Hidden).ToList();
        if (visibleWords.Count == 0)
        {
            return false; // All words are hidden
        }

        Random rand = new Random();
        int randomIndex = rand.Next(0, visibleWords.Count);
        visibleWords[randomIndex].Hidden = true;

        return true;
    }

    public bool AllWordsHidden()
    {
        return words.All(word => word.Hidden);
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create a Scripture object with the reference and text
        var scripture = new Scripture("John 3:16", "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.");

        Console.WriteLine("Welcome to the Scripture Memorizer!");
        Console.WriteLine("Press Enter to hide words or type 'quit' to exit.");
        Console.WriteLine();

        scripture.Display();

        while (true)
        {
            string input = Console.ReadLine();
            if (input.ToLower() == "quit")
            {
                break;
            }

            if (scripture.HideRandomWord())
            {
                Console.Clear();
                scripture.Display();
            }
            else
            {
                Console.WriteLine("All words are hidden. Congratulations!");
                break;
            }
        }

        Console.WriteLine("Thank you for using the Scripture Memorizer!");
    }
}
