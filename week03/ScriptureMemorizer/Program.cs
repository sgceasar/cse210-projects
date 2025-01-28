using System;
using System.Collections.Generic;
using System.Linq;

// Classe Reference
public class Reference
{
    public string Book { get; }
    public int Chapter { get; }
    public int StartVerse { get; }
    public int? EndVerse { get; }

    public Reference(string book, int chapter, int verse)
    {
        Book = book;
        Chapter = chapter;
        StartVerse = verse;
        EndVerse = null;
    }

    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        Book = book;
        Chapter = chapter;
        StartVerse = startVerse;
        EndVerse = endVerse;
    }

    public override string ToString()
    {
        if (EndVerse.HasValue)
        {
            return $"{Book} {Chapter}:{StartVerse}-{EndVerse}";
        }
        return $"{Book} {Chapter}:{StartVerse}";
    }
}

// Classe Word
public class Word
{
    public string Text { get; private set; }
    public bool IsHidden { get; private set; }

    public Word(string text)
    {
        Text = text;
        IsHidden = false;
    }

    public void Hide()
    {
       
        IsHidden = true;
    }
    
    public override string ToString()
    {
        return IsHidden ? new string('_', Text.Length) : Text;
    }
}

// Classe Scripture
public class Scripture
{
    public Reference Reference { get; }
    public List<Word> Words { get; }

    public Scripture(Reference reference, string text)
    {
        Reference = reference;
        // Dividir o texto em palavras
        Words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    public void HideRandomWord()
    {
        Random random = new Random();
       
        var wordsNotHidden = Words.Where(word => !word.IsHidden).ToList();
        if (wordsNotHidden.Count > 0){
            int index = random.Next(wordsNotHidden.Count);
            wordsNotHidden[index].Hide();
        }
    }
    
     public override string ToString()
    {
        return $"{Reference} {string.Join(" ", Words)}";
    }
}

// Classe Program
public class Program
{
    public static void Main(string[] args)
    {
        Reference reference = new Reference("John", 3, 16);
        string text = "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.";
        Scripture scripture = new Scripture(reference, text);

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture);

            if (scripture.Words.All(word => word.IsHidden))
            {
                Console.WriteLine("All words are hidden. Program Ended.");
                break;
            }

            Console.WriteLine("\nPress Enter to hide a word or type 'quit' to exit.");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWord();
        }
    }
}
