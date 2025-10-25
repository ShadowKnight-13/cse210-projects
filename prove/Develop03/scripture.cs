using System;
using System.Diagnostics.Metrics;

public class Scripture
{
    private List<Word> _scripture = new List<Word>();

    public void GetScriptureFromUser()
    {
        Console.WriteLine("Please Enter the Scripture you want to Memorize.");
        UpdateScripture(Console.ReadLine());

        try { Console.Clear(); } catch (IOException) { Console.WriteLine("Console.Clear() failed."); }

    }

    private bool UpdateScripture(string word)
    {
        if (string.IsNullOrWhiteSpace(word))
        {
            return false;
        }
        List<string> scripture = word.Split(" ").ToList();

        int counter = 0;
        foreach (string w in scripture)
        {
            _scripture.Add(new Word(w));

            counter++;
        }
        return true;
    }

    public void DisplayScripture()
    {
        foreach (Word word in _scripture)
        {
            word.DisplayWord();
            Console.Write(" ");
        }
        Console.Write("\n");
    }

    public void Memorizor(Reference r)
    {
        List<int> numberList = new List<int>();
        int counter = 0;
        string input = "";

        Console.WriteLine("Type 'quit' to quit or press enter to continue.");
        r.DisplayReference();
        DisplayScripture();
        input = Console.ReadLine();
        try { Console.Clear(); } catch (IOException) { Console.WriteLine("Console.Clear() failed."); }

        foreach (Word w in _scripture)
        {
            numberList.Add(counter);
            counter++;
        }

        int counter1 = 0;
        while (counter1 < _scripture.Count() & input != "quit")
        {
            Random randomGenerator = new Random();
            int ranNumber1 = randomGenerator.Next(1, numberList.Count());
            numberList.RemoveAt(ranNumber1 - 1); counter1++;

            if (numberList.Count() > 1)
            {
                int ranNumber2 = randomGenerator.Next(1, numberList.Count() - 1);
                numberList.RemoveAt(ranNumber2 - 1);
                counter1++;
            }

            if (numberList.Count() > 2)
            {
                int ranNumber3 = randomGenerator.Next(1, numberList.Count()- 2);
                numberList.RemoveAt(ranNumber3 - 1);
                counter1++;
            }

            foreach (Word w in _scripture) { w.Hide(); }

            foreach (int number in numberList)
            {
                _scripture[number].UnHide();
            }

            Console.WriteLine("Type 'quit' to quit or press enter to continue.");
            r.DisplayReference();
            DisplayScripture();
            input = Console.ReadLine();
            try { Console.Clear(); } catch (IOException) { Console.WriteLine("Console.Clear() failed."); }

        }

    }
}