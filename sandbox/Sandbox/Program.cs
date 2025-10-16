using System;
using System.Diagnostics.Metrics;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = [0, 1, 2, 3, 4];
        List<string> words = ["Hello", "World", "I", "am", "Parker"];
        List<string> blankList = [];

        foreach (string word in words)
        {
            Console.Write(word + " ");
        }
        Console.Write("\n");

        string input = "";
        int counter1 = 0;
        while (counter1 < words.Count() & input != "quit")
        {

            blankList.Clear();
            foreach (string word in words)
            {
                blankList.Add("Blank");
            }

            Random randomGenerator = new Random();
            int ranNumber = randomGenerator.Next(1, numbers.Count());

            numbers.RemoveAt(ranNumber - 1);
            foreach (int number in numbers)
            {
                blankList[number] = "Not Blank";
            }

            int counter = 0;
            while (counter < words.Count())
            {
                if (blankList[counter] == "Blank")
                {
                    foreach (char letter in words[counter])
                    {
                        Console.Write("_");
                    }
                    Console.Write(" ");
                }
                else
                {
                    Console.Write(words[counter] + " ");
                }
                counter++;
            }
            Console.Write("\n");
            counter1++;

            input = Console.ReadLine();
            try
            {
                Console.Clear();
            }
            catch (IOException)
            {
                Console.WriteLine("Console.Clear() failed.");
            }

        }
    }
}