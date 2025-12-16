using System;

public class Log
{
    private List<string> _log = new List<string>();

    public Log() { }

    public void UpdateLog(string input)
    {
        _log.Add(input);
    }

    public void ClearLog()
    {
        _log.Clear();
    }

    public void SaveLog()
    {
        // need to build system
        Console.WriteLine("Enter the file name you want to save your entries into:");
        string filename = Console.ReadLine();
       
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            if (_log.Count() > 0)
            {
                foreach (string line in _log)
                {
                    outputFile.WriteLine(line);
                }

                Console.WriteLine("Saved... Press [Enter] to Continue.");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Theres nothing to save...\nPress [Enter] to continue");
                Console.ReadLine();
                
            }
        }
    }

    public void viewlog()
    {
        try { Console.Clear(); } catch (IOException) { Console.WriteLine("Console.Clear() failed."); }

        foreach (string line in _log)
        {
            Console.WriteLine(line);
        }
    }


}