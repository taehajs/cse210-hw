using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    public List<Entry> Entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        Entries.Add(entry);
    }

    public void DisplayAll()
    {
        if (Entries.Count == 0)
        {
            Console.WriteLine("No journal entries yet.");
        }
        else
        {
            foreach (Entry entry in Entries)
            {
                entry.Display();
            }
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (Entry entry in Entries)
            {
                writer.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Response}");
            }
        }
    }


    public void LoadFromFile(string filename)
    {
        Entries.Clear();
        string[] lines = File.ReadAllLines(filename);
        foreach (string line in lines)
        {
            string[] parts = line.Split('|');
            if (parts.Length == 3)
            {
                Entry entry = new Entry(parts[0], parts[1], parts[2]);
                Entries.Add(entry);
            }
        }
    }
}
