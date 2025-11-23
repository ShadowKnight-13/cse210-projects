using System;
using System.Data;

public class EternalGoal : SimpleGoal
{
    private int _counter = 0;
    public EternalGoal() : base("", 0, "Eternal Goal"){}

    public override int FinishGoal()
    {
        UpdateCounter(1);
        return base.GetPointValue();
    }

    public void UpdateCounter(int updatevalue)
    {
        _counter += updatevalue;
    }

    public int GetCounter()
    {
        return _counter;
    }
}