using System;

public class Circle : Shape
{
    private double _radius;

    public Circle(double radius = 0) : base("Green")
    {
        SetRadius(radius);
    }

    public void SetRadius(double radius)
    {
        _radius = radius;
    }

    public override double GetArea()
    {
        return _radius * 3.14;
    }
}