using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Assignment Summary Program!");

        WritingAssignment assignment1 = new WritingAssignment();
        Console.WriteLine(assignment1.GetWritingInformation());
       
    }
}