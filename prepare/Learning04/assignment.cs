using System;

public class Assignment
{
    private string _studentName;
    private string _topic;
    public string GetSummary()
    {
        return $"Student Name: {GetName()} \nTopic: {GetTopic()}";
    }

    public Assignment()
    {
        Console.Write("Enter the student's name: ");
        UpdateName(Console.ReadLine());

        Console.Write("\nEnter the topic of the assignment: ");
        UpdateTopic(Console.ReadLine());
    }

    private string GetName()
    {
        return _studentName;
    }

    private string GetTopic()
    {
        return _topic;
    }

    private void UpdateName(string name)
    {
        _studentName = name;
    }

    private void UpdateTopic(string topic)
    {
        _topic = topic;
    }
}