using System;

public class Square : Shape
{
    private double _side;

    public Square(double side = 0) : base("Red")
    {
        SetSide(side);
    }

    public void SetSide(double side)
    {
        _side = side;
    }

    public override double GetArea()
    {
        return _side * _side;
    }
}