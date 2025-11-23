using System;
using System.IO;

public class Fileloader
{
    
    public static void filesaver(List<SimpleGoal> simpleGoals, List<EternalGoal> eternalGoals, List<ChecklistGoal> checklistGoals, int current_points)
    {
        Console.WriteLine("Enter the file name you want to save your goals and points into:");
        string filename = $"..//..//..//{Console.ReadLine()}";

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            
            if (simpleGoals.Count() > 0 || eternalGoals.Count() > 0 || checklistGoals.Count() > 0)
            {
                outputFile.WriteLine($"{current_points}, ");

                foreach (SimpleGoal i in simpleGoals)
                {
                    outputFile.WriteLine($"{i.GetGoalType()},{i.GetGoalName()},{i.GetPointValue()},{i.GetGoalStatus()}");
                }

                foreach (EternalGoal e in eternalGoals)
                {
                    outputFile.WriteLine($"{e.GetGoalType()},{e.GetGoalName()},{e.GetPointValue()}, {e.GetGoalStatus()},{e.GetCounter()}");
                }

                foreach (ChecklistGoal c in checklistGoals)
                {
                    outputFile.WriteLine($"{c.GetGoalType()},{c.GetGoalName()},{c.GetPointValue()},{c.GetGoalStatus()},{c.GetBonusPoints()},{c.GetCurrentCompletion()}, {c.GetMaxCompetion()}");
                }
            }
            else
            {
                Console.WriteLine("There's nothing to save.");
                Thread.Sleep(2000);
            }
        }

    }

    public static string[] fileloadera()
    {
        Console.WriteLine("Enter the file name you want to load into the system: ");
        string filename = $"..//..//..//{Console.ReadLine()}";

        string[] lines = System.IO.File.ReadAllLines(filename);

        return lines; 
    }
}