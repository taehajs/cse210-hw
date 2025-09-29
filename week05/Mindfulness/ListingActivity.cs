using System;
using System.Collections.Generic;

class ListingActivity : Activity
{
    private List<string> _prompts;
    private Random _rand;

    public ListingActivity() : base("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        _prompts = new List<string>()
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
        _rand = new Random();
    }

    public void Run()
    {
        DisplayStartingMessage();
        Console.WriteLine($"Prompt: {_prompts[_rand.Next(_prompts.Count)]}");
        Console.WriteLine("You may begin listing in: ");
        ShowCountDown(5);

        List<string> responses = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            responses.Add(Console.ReadLine());
        }
        Console.WriteLine($"You listed {responses.Count} items!");
        DisplayEndingMessage();
    }
}
