using System;
using System.IO;
using System.Reflection.Metadata.Ecma335;


public static class File
{
    public static List<List<string>> fileloader(List<string> datetimelist, List<string> choosenpromptlist, List<string> entrylist, List<string> files_loaded, string filename = "none")
    { //loads data from a csv file, then adds them to the golbal lists, then sorts the data.

        bool saving = false;
        bool file_used = false;

        if (filename == "none")
        {
            Console.WriteLine("Enter the file name you want to load into the system: ");
            filename = $"..//..//..//{Console.ReadLine()}";
        }
        else
        {
            saving = true;
        }

        foreach (string file in files_loaded)
        {

            if (file == filename)
            {
                file_used = true;
            }
        }

        if (file_used == false)
        {
            files_loaded.Add(filename);
        }

        string[] lines = System.IO.File.ReadAllLines(filename);

        List<string> newdatetimelist = new List<string>();
        List<string> newchoosenpromptlist = new List<string>();
        List<string> newentrylist = new List<string>();
        List<List<string>> mixed_list = new List<List<string>>();


        if (file_used == false)
        {


            foreach (string line in lines)
            {
                string[] parts = line.Split(",");

                int counter = 0;
                while (counter < parts.Count())
                {
                    if (saving == false)
                    {
                        Console.WriteLine(parts[counter]);
                    }
                    if (counter == 0)
                    {
                        newdatetimelist.Add(parts[counter]);
                    }
                    else if (counter == 1)
                    {
                        newchoosenpromptlist.Add(parts[counter]);
                    }
                    else if (counter == 2)
                    {
                        newentrylist.Add(parts[counter]);
                    }
                    counter++;
                }
            }
        }


        if (entrylist.Count > 0 || newentrylist.Count > 0)
        {
            int counter = 0;
            while (counter < entrylist.Count)
            {
                newdatetimelist.Add(datetimelist[counter]);
                newchoosenpromptlist.Add(choosenpromptlist[counter]);
                newentrylist.Add(entrylist[counter]);
                counter++;
            }
        }
        else
        {
            Console.WriteLine("There are no entries currently on file.");
        }

        mixed_list.Add(newchoosenpromptlist);
        mixed_list.Add(newentrylist);
        mixed_list.Add(newdatetimelist);
        mixed_list.Add(files_loaded);

        return mixed_list;
    }

    public static void filesaver(List<string> datetimelist, List<string> choosenpromptlist, List<string> entrylist, List<string> files_loaded)
    {

        Console.WriteLine("Enter the file name you want to save your entries into:");
        string filename = $"..//..//..//{Console.ReadLine()}";

        List<List<string>> mixed_list = File.fileloader(datetimelist, choosenpromptlist, entrylist,files_loaded, filename);
        choosenpromptlist = mixed_list[0];
        entrylist = mixed_list[1];
        datetimelist = mixed_list[2];

        string savedatetime = new("");
        string savechoosenprompt = new("");
        string saveentry = new("");

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            if (datetimelist.Count > 0)
            {
                int counter = 0;
                while (counter < datetimelist.Count)
                {
                    savedatetime = datetimelist[counter];
                    savechoosenprompt = choosenpromptlist[counter];
                    saveentry = entrylist[counter];
                    outputFile.WriteLine($"{savedatetime},{savechoosenprompt},{saveentry}");
                    counter++;
                }
            }
            else
            {
                Console.WriteLine("There are no entries currently on file. Can not save.");
            }
        }

    }





}
