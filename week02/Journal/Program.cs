using System;
using System.Collections.Generic;
using JournalApp;

class Program
{
    static PromptGenerator _prompts = new PromptGenerator();
    string prompt = _prompts.GetRandomPrompt();

    static Journal journal = new Journal();
    static Random random = new Random();

    static void Main(string[] args)
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine("=== Journal App ===");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Quit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                WriteEntry();
            }
            else if (choice == "2")
            {
                journal.DisplayAll();
            }
            else if (choice == "3")
            {
                Console.Write("Enter filename: ");
                string filename = Console.ReadLine();
                journal.SaveToFile(filename);
                Console.WriteLine("Saved!");
            }
            else if (choice == "4")
            {
                Console.Write("Enter filename: ");
                string filename = Console.ReadLine();
                journal.LoadFromFile(filename);
                Console.WriteLine("Loaded!");
            }
            else if (choice == "5")
            {
                running = false;
            }
            else
            {
                Console.WriteLine("Invalid choice. Try again.");
            }

            Console.WriteLine();
        }

        Console.WriteLine("Goodbye!");
    }

    static void WriteEntry()
    {
        string[] prompts = {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };

        string prompt = prompts[random.Next(prompts.Length)];
        Console.WriteLine($"Prompt: {prompt}");
        Console.Write("Your response: ");
        string response = Console.ReadLine();

        string date = DateTime.Now.ToShortDateString();
        Entry entry = new Entry(date, prompt, response);
        journal.AddEntry(entry);

        Console.WriteLine("Entry added!");
    }
}
