using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void DisplayAll()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    // save or load document to a database or use different library 
    // or format such as JSON for storage
    public void SaveToFile(string fileName)
    {
        JsonSerializerOptions options = new JsonSerializerOptions
        {
            WriteIndented = true, // makes the file easy to read
            IncludeFields = true // needed because Entry uses public fields, not properties
        };

        string json = JsonSerializer.Serialize(_entries, options);
        File.WriteAllText(fileName, json);

        Console.WriteLine($"Journal saved successfully!");
    }

    public void LoadFromFile(string fileName)
    {
        if (!File.Exists(fileName))
        {
            Console.WriteLine($"File '{fileName}' not found.");
            return;
        }

        JsonSerializerOptions options = new JsonSerializerOptions
        {
            IncludeFields = true    
        };

        string json = File.ReadAllText(fileName);
        _entries = JsonSerializer.Deserialize<List<Entry>>(json, options) ?? new List<Entry>();

        Console.WriteLine($"Journal loaded successfully!");
    }
}