using System;

class Program
{
    static void Main(string[] args)
    {
        
        // Modified Scripture.HideRandomWords so it only hides words that arenot already hidden. 
        // 
        // This ensures that each time the user presses Enter, new words are hidden until all are gone.

        Reference reference = new Reference("Proverbs", 3, 5, 6);
        string text = "Trust in the Lord with all thine heart and lean not unto thine own understanding.";
        Scripture scripture = new Scripture(reference, text);

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress ENTER to hide more words or type 'quit' to exit.");
            string input = Console.ReadLine();

            if (input?.ToLower() == "quit")
                break;

            scripture.HideRandomWords(3);

            if (scripture.IsCompletelyHidden())
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine("\nAll words are hidden. Program will end.");
                break;
            }
        }
    }
}
