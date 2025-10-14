using System;

class Program
{
    static void Main(string[] args)
    {
        string input = "0";

        List<string> choosenpromptlist = new List<string>();
        List<string> entrylist = new List<string>();
        List<string> datetimelist = new List<string>();
        List<string> files_loaded = new List<string>();

        do
        {
            Console.WriteLine("\nPlease select one of the following options: \n1: Write \n2: Display \n3: Load \n4: Save \n5: Quit");
            input = Console.ReadLine();

            while (input != "1" && input != "2" && input != "3" && input != "4" && input != "5")
            {
                Console.WriteLine("Invaild input, please type a number 1-5");
                input = Console.ReadLine();
            }

            if (input == "1")
            {
                List<List<string>> mixed_list = JournalEntry.PromptGenerator(choosenpromptlist, entrylist, datetimelist);
                choosenpromptlist = mixed_list[0];
                entrylist = mixed_list[1];
                datetimelist = mixed_list[2];
            }
            else if (input == "2")
            {
                Display(datetimelist, choosenpromptlist, entrylist);
            }
            else if (input == "3")
            {
                //load feature with journal class
                List<List<string>> mixed_list = File.fileloader(datetimelist, choosenpromptlist, entrylist, files_loaded);
                choosenpromptlist = mixed_list[0];
                entrylist = mixed_list[1];
                datetimelist = mixed_list[2];
                files_loaded = mixed_list[3];
            }
            else if (input == "4")
            {
                //save feature with journal class
                File.filesaver(datetimelist, choosenpromptlist, entrylist, files_loaded);
            }


        } while (input != "5");
    }

    static void Display(List<string> datetimelist, List<string> choosenpromptlist, List<string> entrylist)
    {
        if (entrylist.Count > 0)
        {
            int counter = 0;
            while (counter < entrylist.Count)
            {
                Console.WriteLine($"{datetimelist[counter]} \n{choosenpromptlist[counter]}: \n{entrylist[counter]}\n");
                counter++;
            }
        }
        else
        {
        Console.WriteLine("There are no entries currently on file.");
        }
    }
}