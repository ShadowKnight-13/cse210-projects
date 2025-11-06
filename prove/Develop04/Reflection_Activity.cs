using System;

public class Reflection_Activity : Activity
{
    private List<string> _prompts = new List<string>()
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new List<string>()
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public Reflection_Activity() : base("Reflection Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
    }

    public void ExacuteRefelctionActivity()
    {
        DisplayStartingMessage();
        Random rand = new Random();
        string prompt = _prompts[rand.Next(_prompts.Count)];
        Console.WriteLine("Consider the following prompt:");
        Thread.Sleep(2000);
        Console.WriteLine($"-{prompt}-");
        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();
        try { Console.Clear(); } catch (IOException) { Console.WriteLine("Console.Clear() failed."); }

        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());
        while (DateTime.Now < endTime)
        {
            string question = _questions[rand.Next(_questions.Count)];
            if (GetDuration() > 100)
            {
                DisplayAnimation(20, question);
            }
            else
            {
                DisplayAnimation(10, question);
            }
            _questions.Remove(question);
        }

        DisplayEndingMessage();
    }
}