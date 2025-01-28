using System;
using System.Collections.Generic;
using System.IO;

namespace JournalApp // Namespace for organization
{
    // Program class: Contains the Main method and serves as the entry point for the program
    public class Program
    {
        public static void Main(string[] args)
        {
            // Create a new Journal
            Journal myJournal = new Journal();
            bool isRunning = true;

            while (isRunning)
            {
                // Display the menu options
                Console.WriteLine("\nJournal Menu:");
                Console.WriteLine("1. Write a new entry ✍️ ");
                Console.WriteLine("2. Display the journal 🖥️");
                Console.WriteLine("3. Save the journal ⬇️");
                Console.WriteLine("4. Load the journal 📓");
                Console.WriteLine("5. Exit ❌");
                Console.Write("Choose an option: 🤔");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        // Write a new entry
                        string randomPrompt = myJournal.GetRandomPrompt();
                        Console.WriteLine($"Prompt: {randomPrompt}");
                        Console.Write("Enter your journal entry: ");
                        string content = Console.ReadLine();
                        myJournal.AddEntry(randomPrompt, content);
                        break;
                    case "2":
                        // Display the journal
                        Console.WriteLine("\nDisplaying all journal entries:");
                        myJournal.DisplayAll();
                        break;
                    case "3":
                        // Save the journal
                        Console.Write("Enter the filename to save the journal: ");
                        string saveFile = Console.ReadLine();
                        myJournal.SaveToFile(saveFile);
                        break;
                    case "4":
                        // Load the journal
                        Console.Write("Enter the filename to load the journal: ");
                        string loadFile = Console.ReadLine();
                        myJournal.LoadFromFile(loadFile);
                        break;
                    case "5":
                        // Exit the program
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
    }

    // Journal class: Models the Journal containing a list of Entries
    public class Journal
    {
        private List<Entry> _entries;
        private static List<string> _prompts = new List<string>
        {
            "What made you smile today?",
            "What is something you learned today?",
            "What was the best part of your day?",
            "What challenges did you face today?",
            "What is your biggest goal for tomorrow?"
        };

        public Journal()
        {
            _entries = new List<Entry>();
        }

        // Add a new journal entry with the current date and a prompt
        public void AddEntry(string prompt, string content)
        {
            Entry newEntry = new Entry(prompt, content);
            _entries.Add(newEntry);
        }

        // Display all journal entries with dates and prompts
        public void DisplayAll()
        {
            foreach (var entry in _entries)
            {
                Console.WriteLine(entry.DisplayEntry());
            }
        }

        // Generate a random prompt from the predefined list
        public string GetRandomPrompt()
        {
            Random rand = new Random();
            int index = rand.Next(_prompts.Count);
            return _prompts[index];
        }

        // Save the journal entries to a file
        public void SaveToFile(string file)
        {
            using (StreamWriter writer = new StreamWriter(file))
            {
                foreach (var entry in _entries)
                {
                    writer.WriteLine(entry.ToString());
                }
            }
        }

        // Load journal entries from a file
        public void LoadFromFile(string file)
        {
            if (File.Exists(file))
            {
                _entries.Clear();
                string[] lines = File.ReadAllLines(file);
                foreach (string line in lines)
                {
                    _entries.Add(Entry.Parse(line));
                }
            }
            else
            {
                Console.WriteLine("The file does not exist.");
            }
        }
    }

    // Entry class: Models the individual journal entries
    public class Entry
    {
        public DateTime Date { get; private set; }
        public string Prompt { get; private set; }
        public string Content { get; private set; }

        public Entry(string prompt, string content)
        {
            Date = DateTime.Now; // Automatically set to the current date
            Prompt = prompt;
            Content = content;
        }

        // Display the entry with its date and prompt
        public string DisplayEntry()
        {
            return $"{Date.ToShortDateString()} - {Prompt}\n{Content}\n";
        }

        // Convert the entry to a string for saving to a file
        public override string ToString()
        {
            return $"{Date.ToShortDateString()}|{Prompt}|{Content}";
        }

        // Parse a string from the file and create an Entry object
        public static Entry Parse(string entryString)
        {
            string[] parts = entryString.Split('|');
            DateTime date = DateTime.Parse(parts[0]);
            string prompt = parts[1];
            string content = parts[2];
            return new Entry(prompt, content) { Date = date };
        }
    }
}
