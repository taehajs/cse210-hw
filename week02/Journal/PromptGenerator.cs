using System;
using System.Collections.Generic;

namespace JournalApp
{
    public class PromptGenerator
    {
        private readonly List<string> _prompts = new()
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "What am I grateful for right now, and why?",
            "What is a tiny win I can celebrate today?",
            "What surprised me today?",
            "What is something I learned or noticed today?",
            "What do I want to remember about today a year from now?"
        };

        private readonly Random _random = new();

        public string GetRandomPrompt(string? exclude = null)
        {
            if (_prompts.Count == 0) return "Write anything that's on your mind.";
            string prompt;
            int guard = 0;
            do
            {
                prompt = _prompts[_random.Next(_prompts.Count)];
                guard++;
            } while (!string.IsNullOrEmpty(exclude) && prompt == exclude && guard < 10);
            return prompt;
        }
    }
}
