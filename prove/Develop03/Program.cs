using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Scripture Memorizing program!");

        Reference ref1 = new Reference();
        ref1.GetReferenceFromUser();

        Scripture script1 = new Scripture();
        script1.GetScriptureFromUser();

        script1.Memorizor(ref1);
        
    }
}