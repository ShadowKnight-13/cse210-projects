using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();
        string name = PromptUserName();

        double number = PromptUserNumber();

        int birthyear;
        PromptUserBirthYear(out birthyear);

        double squaredNumber = SquareNumber(number);

        DisplayResults(name, squaredNumber, birthyear);
    }

    static void DisplayWelcome() { Console.WriteLine("Welcome to the Program"); }

    static string PromptUserName()
    {
        Console.WriteLine("Please type your name: ");
        string input = Console.ReadLine();

        return input;
    }

    static double PromptUserNumber()
    {
        Console.WriteLine("What is your favorite number? ");
        string input = Console.ReadLine();
        double number = double.Parse(input);

        return number;
    }

    static void PromptUserBirthYear(out int birthyear)
    {
        Console.WriteLine($"Please enter the year you were born: ");
        birthyear = int.Parse(Console.ReadLine());
    }

    static double SquareNumber(double number)
    {
        double squared = number * number;
        return squared;
    }

    static void DisplayResults(string name, double squaredNumber, int birthYear)
    {
        int age = 2025 - birthYear;
        Console.WriteLine($"{name}, the square of your number is {squaredNumber}");
        Console.WriteLine($"{name}, you will turn {age} this year.");

    }
    
}