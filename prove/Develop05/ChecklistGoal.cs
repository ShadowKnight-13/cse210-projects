using System;
using System.Security.Cryptography.X509Certificates;

public class ChecklistGoal : SimpleGoal
{
    private int _MaxCompletion = 999;
    private int _CurrentCompletion = 0;
    private int _BonusPoints = 0;

    public ChecklistGoal(int maxcompletion = 999, int bonuspoints=0) : base("", 0, "Checklist Goal")
    {
        UpdateMaxCompletion(maxcompletion);
        UpdateBonusPoints(bonuspoints);
    }

    public void UpdateMaxCompletion(int UpdateValue)
    {
        _MaxCompletion = UpdateValue;
    }

    public int GetMaxCompetion()
    {
        return _MaxCompletion;
    }

    public void UpdateCurrentCompletion(int UpdateValue=1)
    {
        _CurrentCompletion += UpdateValue;
    }

    public int GetCurrentCompletion()
    {
        return _CurrentCompletion;
    }

    public override int FinishGoal()
    {
        int points = 0;
        UpdateCurrentCompletion();

        if (GetCurrentCompletion() != GetMaxCompetion())
        {
            points  = GetPointValue();
        }
        else
        {
            points = GetBonusPoints();
            base.FinishGoal();
        }
        
        return points;
    }

    public void UpdateBonusPoints(int UpdateValue)
    {
        _BonusPoints = UpdateValue;
    }

    public int GetBonusPoints()
    {
        return _BonusPoints;
    }



    public override void GetPointValueFromUser()
    {
        bool updated = false;
        Console.WriteLine("What is the point value for each step completed on this goal?");
        string Value = Console.ReadLine();

        do
        {
            try { Console.Clear(); } catch (IOException) { Console.WriteLine("Console.Clear() failed."); }

            if (int.TryParse(Value, out int PValue))
            {   
                UpdatePointValue(PValue);
                updated = true;
            }
            else
            {
                Console.WriteLine("What is the point value for each step completed on this goal?");
                Value = Console.ReadLine();
            }
        } while (updated == false);

        Console.WriteLine("What is the Bonus point value for finishing all steps of this goal?");
        Value = Console.ReadLine();

        do
        {
            try { Console.Clear(); } catch (IOException) { Console.WriteLine("Console.Clear() failed."); }

            if (int.TryParse(Value, out int PValue))
            {   
                UpdateBonusPoints(PValue);
                updated = false;
            }
            else
            {
                Console.WriteLine("What is the Bonus point value for finishing all steps of this goal?");
                Value = Console.ReadLine();
            }
        } while (updated == true);

    }

    public void getMaxCompletionFromUser()
    {
        Console.WriteLine("How many times does this task need to be marked off before it is finished?");
        string input = Console.ReadLine();
        bool updated = false;

        do 
        {
            if (int.TryParse(input, out int max))
                {   
                    UpdateMaxCompletion(max);
                    updated = true;
                }
                else
                {
                    Console.WriteLine("How many times does this task need to be marked off before it is finished?");
                    input = Console.ReadLine();
                }
        } while (updated == false);
        _CurrentCompletion = 0;
    }
    

}