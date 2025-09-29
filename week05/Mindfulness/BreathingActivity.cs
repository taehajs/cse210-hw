using System;

class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing", "This activity will help you relax by guiding you through breathing in and out slowly. Clear your mind and focus on your breathing.") { }

    public void Run()
    {
        DisplayStartingMessage();
        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            Console.WriteLine("Breathe in...");
            ShowCountDown(3);
            Console.WriteLine("Breathe out...");
            ShowCountDown(3);
        }
        DisplayEndingMessage();
    }
}
