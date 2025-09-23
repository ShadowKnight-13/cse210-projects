using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep5 World!");
    }

    static void DisplayWelcom() { Console.WriteLine("Welcome to the Program"); }

    static string PromptUserName()
    {
        Console.WriteLine("Please type your name: ");
        string input = Console.ReadLine();

        return input;
    }

    static int PromptUserNumber()
    {
        Console.WriteLine("What is your favorite number? ");
        string input = Console.ReadLine();
        int number = int.Parse(input);

        return number;
    }

    
}