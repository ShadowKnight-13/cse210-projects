using System;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();

        Rectangle rec1 = new Rectangle();
        rec1.SetLenght(3);
        rec1.SetWidth(4);
        rec1.SetColor("blue");
        shapes.Add(rec1);

        Square squ1 = new Square();
        squ1.SetSide(5);
        squ1.SetColor("Purple");
        shapes.Add(squ1);

        Circle cir1 = new Circle();
        cir1.SetColor("Gray");
        cir1.SetRadius(5);
        shapes.Add(cir1);

        foreach (Shape i in shapes)
        {
            Console.WriteLine(i.GetColor());
            Console.WriteLine(i.GetArea());
            Console.WriteLine();
        }

    }
}