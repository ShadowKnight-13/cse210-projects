using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction fract1 = new Fraction();
        List<int> fractionList = new List<int>();

        fract1.setStartingFraction();
        fractionList = fract1.getFraction();
        Console.WriteLine($"{fractionList[0]}/{fractionList[1]}");

        fract1.setWholeNumber(6);
        Console.WriteLine($"{fract1.getTop()}/{fract1.getBottom()}");

        fract1.setFraction(6, 7);
        Console.WriteLine(fract1.getFractionString());

        fract1.setFraction(1,3);
        Console.WriteLine(fract1.getDecimalvalue());

    }
}