using System;

public class WritingAssignment : Assignment
{
    private string _title;

    public WritingAssignment()
    {
        new Assignment();
        Console.Write("\nEnter the title of the writing assignment: ");
        UpdateTitle(Console.ReadLine());
    }

    public void UpdateTitle(string title)
    {
        _title = title;
    }

    public string GetWritingInformation()
    {
        return $"{GetSummary()} \nTitle: {_title}";
    }
}