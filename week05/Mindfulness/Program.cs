using System;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();
            if (choice == "1")
            {
                BreathingActivity activity = new BreathingActivity();
                activity.Run();
            }
            else if (choice == "2")
            {
                ReflectingActivity activity = new ReflectingActivity();
                activity.Run();
            }
            else if (choice == "3")
            {
                ListingActivity activity = new ListingActivity();
                activity.Run();
            }
            else if (choice == "4")
            {
                break;
            }
        }
    }
}

// Added safe numeric input parsing and spinner animations for pauses, with randomized prompts/questions.

// 1. Safe numeric input parsing added to prevent crash if user enters non-numeric input
//    - This ensures robustness and improves user experience
// 2. Spinner animations and countdown timers implemented using "\b \b" and Thread.Sleep
//    - This uses the Code Helps guidance for displaying animations while pausing
//    - Spinner: ShowSpinner(seconds)
//    - Countdown: ShowCountDown(seconds)
// 3. Random prompts and questions for Reflecting and Listing activities
//    - Ensures varied user experience each session
// 4. Base Activity class used to implement shared attributes and behaviors
// -Reduces code duplication and demonstrates abstraction, encapsulation, and inheritance
// 5. Program exceeds core requirements by:
//    - Implementing safe input validation
//    - Using randomized prompts/questions
//    - Adding animated pauses with spinner and countdown