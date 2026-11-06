using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        int choice = 0;

        while (choice != 5)
        {
            Console.WriteLine();
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");
            choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                string prompt = promptGenerator.GetRandomPrompt();

                Console.WriteLine();
                Console.WriteLine(prompt);
                Console.Write("> ");

                string response = Console.ReadLine();
                string date = DateTime.Now.ToShortDateString();

                Entry entry = new Entry();
                entry._date = date;
                entry._promptText = prompt;
                entry._entryText = response;

                journal.AddEntry(entry);
            }
            else if (choice == 2)
            {
                journal.DisplayAll();
            }
            else if (choice == 3)
            {
                Console.Write("Enter filename: ");
                string fileName = Console.ReadLine();

                journal.LoadFromFile(fileName);
            }
            else if (choice == 4)
            {
                Console.Write("Enter filename: ");
                string fileName = Console.ReadLine();

                journal.SaveToFile(fileName);
            }
            else if (choice == 5)
            {
                Console.WriteLine("Goodbye!");
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
        }
    }
}