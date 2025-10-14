using System;
using System.Diagnostics.Tracing;
using System.Dynamic;
using System.Reflection.Metadata.Ecma335;

class Fraction
{
    private int top = new int();
    private int bottom = new int();

    public void setStartingFraction()
    {
        top = 1;
        bottom = 1;
    }

    public void setWholeNumber(int number)
    {
        top = number;
        bottom = 1;
    }

    public void setFraction(int numerator, int denominator)
    {
        top = numerator;
        bottom = denominator;
    }

    public List<int> getFraction()
    {
        List<int> fractionList = new List<int>();
        fractionList.Add(top);
        fractionList.Add(bottom);
        return fractionList;
    }

    public int getTop()
    {
        return top;
    }

    public int getBottom()
    {
        return bottom;
    }

    public string getFractionString()
    {
        string fractionstring = new string("");
        fractionstring = $"{top}/{bottom}";

        return fractionstring;
    }

    public double getDecimalvalue()
    {
        double fractionDecimal = new double();
        fractionDecimal = (double)top / bottom;
        return fractionDecimal;
    }

}