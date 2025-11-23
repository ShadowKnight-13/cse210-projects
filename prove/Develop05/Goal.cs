using System;

public class SimpleGoal
{  
    private string _goalType = "Simple Goal";
    private string _goalName = "";
    private int _pointValue = 0;
    private bool _finished = false;
    public SimpleGoal(string goalname = "", int pointvalue = 0, string goaltype = "Simple Goal")
    {
        UpdateGoalType(goaltype);
        UpdateGoalName(goalname);
        UpdatePointValue(pointvalue);
    }

    public virtual int FinishGoal()
    {
        _finished = true;
        return _pointValue;
    } 

    public virtual bool GetGoalStatus()
    {
        return _finished;
    }

    public void UpdateGoalStatus(bool status)
    {
        _finished = status;
    }

    public virtual string GetGoalType()
    {
        return _goalType;
    }

    public virtual string GetGoalName()
    {
        return _goalName;
    }

    public virtual int GetPointValue()
    {
        return _pointValue;
    }


    public virtual void UpdateGoalType(string goaltype)
    {
        _goalType = goaltype;
    }
    public virtual void UpdatePointValue(int pointvalue)
    {
        _pointValue = pointvalue;
    }

    public virtual void UpdateGoalName(string goalname)
    {
      _goalName = goalname;   
    }

    public void GetGoalNameFromUser()
    {
        Console.WriteLine("What is the name of this Goal?");
        UpdateGoalName(Console.ReadLine());
        try { Console.Clear(); } catch (IOException) { Console.WriteLine("Console.Clear() failed."); }
    }

    public virtual void GetPointValueFromUser()
    {
        bool updated = false;
        Console.WriteLine("What is the point value of this goal?");
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
                Console.WriteLine("What is the point value of this goal?");
                Value = Console.ReadLine();
            }
        } while (updated == false);
        

        
    }
}