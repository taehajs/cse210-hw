using System;
using System.Collections.Generic;
using System.Threading;

class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Starting {_name} Activity");
        Console.WriteLine(_description);
        Console.Write("Enter the duration of the activity in seconds: ");
        
        while (!int.TryParse(Console.ReadLine(), out _duration))
        {
            Console.Write("Please enter a valid number: ");
        }

        Console.WriteLine("Prepare to begin...");
        ShowSpinner(3);
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine("Great! Well done!");
        ShowSpinner(2);
        Console.WriteLine($"You have completed the {_name} activity for {_duration} seconds.");
        ShowSpinner(3);
    }

    protected void ShowSpinner(int seconds)
    {
        List<string> spinner = new List<string>() { "|", "/", "-", "\\" };
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        int i = 0;
        while (DateTime.Now < endTime)
        {
            Console.Write(spinner[i]);
            Thread.Sleep(200);
            Console.Write("\b \b");
            i = (i + 1) % spinner.Count;
        }
    }

    protected void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
}
