using System;
using System.Security.Cryptography.X509Certificates;

public class Activity
{
    private string _activityName;
    private string _activitymessage;
    private int _duration;

    public Activity(string name, string message)
    {
        _activityName = name;
        _activitymessage = message;
    }
    public void DisplayStartingMessage()
    {
        try { Console.Clear(); } catch (IOException) { Console.WriteLine("Console.Clear() failed."); }
        Console.WriteLine($"Welcome to the {_activityName} activity.");
        Console.WriteLine(_activitymessage);
        Thread.Sleep(2000);
        Console.WriteLine();
        Console.Write("How long, in seconds, would you like for your session? ");
        _duration = int.Parse(Console.ReadLine());
        try { Console.Clear(); } catch (IOException) { Console.WriteLine("Console.Clear() failed."); }

        DisplayAnimation(2, "Get ready");
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine("Well done!!");
        Thread.Sleep(1500);
        DisplayAnimation(4,$"Well done!! \nYou have completed {_duration} seconds of the {_activityName} activity");
    }

    public void DisplayAnimation(int seconds, string message = "")
    {
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);

        while (DateTime.Now < endTime)
        {
            try { Console.Clear(); } catch (IOException) { Console.WriteLine("Console.Clear() failed."); }
            Console.Write(message);
            Thread.Sleep(300);
            Console.Write(" .");
            Thread.Sleep(300);

            Console.Write(" .");
            Thread.Sleep(300);

            Console.Write(" .");
            Thread.Sleep(300);

            try { Console.Clear(); } catch (IOException) { Console.WriteLine("Console.Clear() failed."); }
        }
    }

    public int GetDuration()
    {
        return _duration;
    }   
    
}