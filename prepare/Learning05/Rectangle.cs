using System;

public class Rectangle : Shape
{
    private double _length;
    private double _width;

    public Rectangle(double length = 0, double width = 0) : base("Blue")
    {
        SetLenght(length);
        SetWidth(width);
    }

    public void SetLenght(double length)
    {
        _length = length;
    }

    public void SetWidth(double width)
    {
        _width = width;
    }
    public override double GetArea()
    {
        return _length * _width;
    }
}