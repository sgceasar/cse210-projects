using System;
using System.Threading;
using System.Collections.Generic;

namespace MindfulnessProgram
{
    //Classe base to mindfullnes activity
    class Activity
    {
        private string _name;
        private string _description;
        protected int _duration; //Protected subclasses

        public Activity(string name, string description)
        {
            _name = name;
            _description = description;
            _duration = 0;
        }

        //Commom initial message
        public void StartMessage()
        {
            Console.WriteLine($"Welcome to the activity {_name}! 👋");
            Console.WriteLine(_description);
            Console.Write("For how long would like to practice this session?⌛");
            _duration = int.Parse(Console.ReadLine());
            Console.WriteLine("⭐ We will start in...");
            Pause(3);
        }

        //Final message common to all activities
        public void EndMessage()
        {
            Console.WriteLine("Well done!");
            Pause(2);
            Console.WriteLine($"You complete the activity {_name} for {_duration} seconds.");
            Pause(3);
        }

        //Pause with animation
        public void Pause(int seconds)
        {
            for (int i = seconds; i > 0; i--)
            {
                Console.Write($"  {i}\b\b");
                Thread.Sleep(1000);
            }
            Console.WriteLine();
        }

        //Method to be implemented by subclasses
        public virtual void Run()
        {
            throw new NotImplementedException("This method must be implemented by the subclasses.");
        }
    }

    //Atividade de respiração
    class BreathingActivity : Activity
    {
        public BreathingActivity() : base("Breathing", "This activity will help you relax, guiding you in slow breathing. Clear your mind and focus on breathing.")
        {
        }

        //Excecutie breating session
        public override void Run()
        {
            StartMessage();
            DateTime endTime = DateTime.Now.AddSeconds(_duration);
            while (DateTime.Now < endTime)
            {
                Console.WriteLine("Inspire...");
                Pause(2);
                Console.WriteLine("Expire...");
                Pause(2);
            }
            EndMessage();
        }
    }

    //reflection activity
    class ReflectionActivity : Activity
    {
        private List<string> _prompts = new List<string>()
        {
            "think of a time when you stood up for someone else.🤝",
            "Think of a time when you did someting really hard.🪨",
            "Think of a time when you helped someone in need.😊",
            "Think of a tie when you did something truly selfless🫶"
        };

        private List<string> _questions = new List<string>()
        {
            "Why was this experience meaningful to you?",
            "Have you done anything like this before?",
            "How did you start?",
            "How did you feel when you finished?",
            "What made this time different from other times when you haven't been so successful?",
            "What's your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What have you learned about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        public ReflectionActivity() : base("Reflection", "This activity will help you reflect on moments in your life when you have demonstrated strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
        {
        }

        //Execute reflection activity
        public override void Run()
        {
            StartMessage();
            Random random = new Random();
            string prompt = _prompts[random.Next(_prompts.Count)];
            Console.WriteLine(prompt);
            DateTime endTime = DateTime.Now.AddSeconds(_duration);
            while (DateTime.Now < endTime)
            {
                string question = _questions[random.Next(_questions.Count)];
                Console.WriteLine(question);
                Pause(4);
            }
            EndMessage();
        }
    }

    //Listening activity
    class ListingActivity : Activity
    {
        private List<string> _prompts = new List<string>()
        {
            "Who are the people you appreciate?",
            "What are your personal strengths?",
            "Who are the people you helped this week?",
            "When did you feel the Holy Spirit this month?",
            "Who are some of your personal heroes?"
        };

        public ListingActivity() : base("Listing", "This activity will help you reflect on the good things in your life by asking you to list as many things as you can in a certain areas.")
        {
        }

        //Execute Listening activity
        public override void Run()
        {
            StartMessage();
            Random random = new Random();
            string prompt = _prompts[random.Next(_prompts.Count)];
            Console.WriteLine(prompt);
            Console.WriteLine("Start in...");
            Pause(5);
            DateTime startTime = DateTime.Now;
            List<string> items = new List<string>();
            while (DateTime.Now - startTime < TimeSpan.FromSeconds(_duration))
            {
                Console.Write("> ");
                string item = Console.ReadLine();
                items.Add(item);
            }
            Console.WriteLine($"You did {items.Count} itens.");
            EndMessage();
        }
    }

    //Main function 
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Breathing Activity🧘");
                Console.WriteLine("2. Reflection Activity💭");
                Console.WriteLine("3. Listing Activity📋");
                Console.WriteLine("4. Exit");

                Console.Write("Choose one activity (1-4): ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        BreathingActivity breathing = new BreathingActivity();
                        breathing.Run();
                        break;
                    case "2":
                        ReflectionActivity reflection = new ReflectionActivity();
                        reflection.Run();
                        break;
                    case "3":
                        ListingActivity listing = new ListingActivity();
                        listing.Run();
                        break;
                    case "4":
                        Console.WriteLine("Thank you for your participation!");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please chosse between 1,2,3 or 4.");
                        break;
                }
            }
        }
    }
}
