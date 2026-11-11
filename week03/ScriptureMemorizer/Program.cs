using System;
using System.Collections.Generic;
using System.IO;

// EXCEEDING REQUIREMENTS:
// 1. Only words that are not already hidden are chosen to hide (stretch goal).
// 2. A library of scriptures is used, and one is picked at random each run.
// 3. Scriptures can be loaded from a file (scriptures.txt) so the library can
//    grow without changing code. Format per line:
//    Book|Chapter|StartVerse|EndVerse|Text   (EndVerse may be left blank)
//    If the file is missing, a built-in library is used.
// 4. Hidden words keep their punctuation ("trust," -> "_____,") so the verse
//    is easier to follow as it disappears.
// 5. A progress line shows what percent of the scripture is hidden, and the
//    user can type "reset" to show all words again and start over.

class Program
{
    static void Main(string[] args)
    {
        List<Scripture> library = LoadLibrary("scriptures.txt");
        Scripture scripture = library[new Random().Next(library.Count)];

        while (true)
        {
            ClearScreen();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.WriteLine($"Hidden: {scripture.GetHiddenPercent()}%");

            if (scripture.IsCompletelyHidden())
            {
                Console.WriteLine("All words are hidden. Well done!");
                break;
            }

            Console.WriteLine();
            Console.Write("Press Enter to continue, type 'reset' to start over, or type 'quit' to finish: ");
            string input = Console.ReadLine();

            if (input == null || input.Trim().ToLower() == "quit")
            {
                break;
            }
            else if (input.Trim().ToLower() == "reset")
            {
                scripture.ShowAllWords();
            }
            else
            {
                scripture.HideRandomWords(3);
            }
        }
    }

    static void ClearScreen()
    {
        // Console.Clear throws when output is redirected (e.g. piped to a file).
        if (!Console.IsOutputRedirected)
        {
            Console.Clear();
        }
    }

    static List<Scripture> LoadLibrary(string fileName)
    {
        List<Scripture> library = new List<Scripture>();

        if (File.Exists(fileName))
        {
            foreach (string line in File.ReadAllLines(fileName))
            {
                string[] parts = line.Split('|');
                if (parts.Length != 5)
                {
                    continue;
                }

                string book = parts[0].Trim();
                int chapter = int.Parse(parts[1]);
                int start = int.Parse(parts[2]);
                Reference reference = string.IsNullOrWhiteSpace(parts[3])
                    ? new Reference(book, chapter, start)
                    : new Reference(book, chapter, start, int.Parse(parts[3]));

                library.Add(new Scripture(reference, parts[4].Trim()));
            }
        }

        if (library.Count == 0)
        {
            library.Add(new Scripture(new Reference("John", 3, 16),
                "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."));
            library.Add(new Scripture(new Reference("Proverbs", 3, 5, 6),
                "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths."));
            library.Add(new Scripture(new Reference("Moroni", 10, 4),
                "And when ye shall receive these things, I would exhort you that ye would ask God, the Eternal Father, in the name of Christ, if these things are not true; and if ye shall ask with a sincere heart, with real intent, having faith in Christ, he will manifest the truth of it unto you, by the power of the Holy Ghost."));
        }

        return library;
    }
}
