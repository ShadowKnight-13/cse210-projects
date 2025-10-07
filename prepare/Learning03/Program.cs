using System;

class Program
{
    static void Main(string[] args)
    {
        string input = "0";

        List<string> choosenpromptlist = new List<string>();
        List<string> entrylist = new List<string>();
        List<string> datetimelist = new List<string>();

        do
        {
            Console.WriteLine("Please select one of the following options: \n1: Write \n2: Display \n3: Load \n4: Save \n5: Quit");
            input = Console.ReadLine();

            while (input != "1" && input != "2" && input != "3" && input != "4" && input != "5")
            {
                Console.WriteLine("Invaild input, please type a number 1-4");
                input = Console.ReadLine();
            }

            if (input == "1")
            {
                List<List<string>> mixed_list = JournalEntry.PromptGenerator(choosenpromptlist, entrylist, datetimelist);
                choosenpromptlist = mixed_list[0];
                entrylist = mixed_list[1];
            }
            else if (input == "2")
            {
                if (entrylist.Count > 0)
                {
                    int counter = 0;
                    while (counter < entrylist.Count)
                    {
                        Console.WriteLine($"{datetimelist[counter]} {choosenpromptlist[counter]}: \n{entrylist[counter]}");
                        counter++;
                    }
                }
            }



        } while (input != "5");
    }
}