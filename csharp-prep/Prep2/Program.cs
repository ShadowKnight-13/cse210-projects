using System;
using System.ComponentModel;

class Program
{
    static void Main(string[] args)
    {
        string letter_grade = "Z";
        Console.WriteLine("What was the number grade recieved? ");
        string input = Console.ReadLine();
        int number = int.Parse(input);

        if (number > 89)
        {
            letter_grade = "A";
        }
        else if (number > 79)
        {
            letter_grade = "B";
        }
        else if (number > 69)
        {
            letter_grade = "C";
        }
        else if (number > 59)
        {
            letter_grade = "D";
        }
        else
        {
            letter_grade = "F";
        }

        Console.Write($"You got a {letter_grade} in the class.");

        if (number < 70)
        {
            Console.Write(" You failed, but there's always next time!");
        }
        else
        {
            Console.Write(" You Passed! Good Job!");
         }

    }
}