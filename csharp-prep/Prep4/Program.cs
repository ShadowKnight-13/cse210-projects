using System;
using System.Diagnostics.CodeAnalysis;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        int number = 0;
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        do
        {
            Console.Write("Enter number: ");
            string input = Console.ReadLine();
            number = int.Parse(input);
            numbers.Add(number);

        } while (number != 0);

        double sum = 0;
        int largest = 0;

        foreach (int num in numbers)
        {
            sum += num;
            if (num > largest) { largest = num; }
        }

        Console.WriteLine($"The sum is: {sum}");

        double average = sum / (numbers.Count - 1);

        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {largest}");


        
 

    }
}