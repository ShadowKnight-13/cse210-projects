using System;
using System.Diagnostics.CodeAnalysis;

public class Listing_Activity : Activity
{
    private List<string> _strings = new List<string>(){};
    private List<string> _prompts = new List<string>()
    {
        "Who are the people that you appreciate?",
        "What are personal strenghts of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heros?"
    };

    public Listing_Activity() : base("Listing Activity", "This activity will help you refelct on the good things in your life by having you list as many things as you can in a certain area.")
    {
    }

    public void ExecuteListingActivity()
    {
        DisplayStartingMessage();
        Random rand = new Random();
        string prompt = _prompts[rand.Next(_prompts.Count)];
        Console.WriteLine("Consider the following prompt:");
        Thread.Sleep(2000);
        Console.WriteLine($"-{prompt}-");
        Console.WriteLine("When you are ready to begin, press Enter.");
        Console.ReadLine();
        try { Console.Clear(); } catch (IOException) { Console.WriteLine("Console.Clear() failed."); }

        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());
        Console.WriteLine(prompt);
        while (DateTime.Now < endTime)
        {
            _strings.Add(Console.ReadLine());
        }
        DisplayEndingMessage();
    }
}