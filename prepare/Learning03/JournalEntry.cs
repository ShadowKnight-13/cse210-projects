using System;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

public class JournalEntry
{
    public static List<List<string>> PromptGenerator(List<string> choosenpromptlist, List<string> entrylist, List<string> datetimelist)
    {
        List<string> promptlist = ["Who was the most interesting person I interacted with today?", "What was the best part of my day?", "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?", "If I had one thing I could do over today what would it be?", "What surprised me today?", "What did I learn today — about myself others or the world?",
        "What challenged me today and how did I respond?", "What am I most grateful for today?", "What moment would I like to remember forever?", "What thoughts kept recurring today?",
        "Did I feel peace today? If so when?", "What drained my energy today? What restored it?", "What did I do today that made me feel proud?", "What scripture or spiritual insight stood out to me today?",
        "Did I feel prompted by the Spirit today? How did I respond?", "How did I show love or compassion today?", "What did I pray for today and why?", "What habit am I working on and how did I do today?",
        "What's one thing I avoided today and why?", "What's one small win I had today?", "What's something I could do tomorrow to grow?", "If today were a chapter in a book what would its title be?",
        "What metaphor best describes my day?", "What question do I wish someone had asked me today?", "What's one thing I want to ask God about?"];

        Random randomGenerator = new Random();
        int randomNumber = randomGenerator.Next(1,promptlist.Count);

        choosenpromptlist.Add(promptlist[randomNumber - 1]);

        Console.WriteLine(promptlist[randomNumber - 1]);
        entrylist.Add(Console.ReadLine());

        DateTime currentdatetime = DateTime.Now;
        string currentdatetimestring = currentdatetime.ToString("yyyy-MM-dd HH:mm:ss");

        datetimelist.Add(currentdatetimestring);

        List<List<string>> mixed_list = new List<List<string>>{};

        mixed_list.Add(choosenpromptlist);
        mixed_list.Add(entrylist);
        mixed_list.Add(datetimelist);

        return mixed_list;
    }
}