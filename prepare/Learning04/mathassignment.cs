using System;

public class MathAssignment : Assignment
{
    private string _texbookSection;
    private string _problems;

    public MathAssignment()
    {
        new Assignment();
        Console.Write("\nEnter the textbook section: ");
        UpdateTexbookSection(Console.ReadLine());

        Console.Write("\nEnter the problems assigned: ");
        UpdateProblems(Console.ReadLine());
    }

    private void UpdateTexbookSection(string section)
    {
        _texbookSection = section;
    }

    private void UpdateProblems(string problems)
    {
        _problems = problems;
    }   
    
    public string GetHomeworkList()
    {
        return $"{GetSummary()} \nSection:{_texbookSection} Problems: {_problems}";
    }
}