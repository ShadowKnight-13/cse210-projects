using System;

public class FileLoader
{
    private List<string> _FilesUsed = [];

    public void SavePlayerCharacters(List<PlayerCharacter> SaveList)
    {
        Console.WriteLine("Enter the file name you want to save your entries into:");
        string filename = Console.ReadLine();
       
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            if (SaveList.Count() > 0)
            {
                foreach (PlayerCharacter pc in SaveList)
                {
                    outputFile.WriteLine($"{pc.GetPlayerName()},{pc.GetName()},{pc.GetMaxHP()},{pc.GetCurrentHP()},{pc.GetAC()},{pc.GetInitiativeBonus()},{pc.GetInitiative()},{pc.GetLinearInitiativeStick()}");
                }

                Console.WriteLine("Saved... Press [Enter] to Continue.");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("There are no Player Characters currently on file. Cannot save. Press [Enter] to Continue.");
                Console.ReadLine();
            }
        }
    }





    public void SaveMonsters(List<Monster> SaveList)
    {
        Console.WriteLine("Enter the file name you want to save your entries into:");
        string filename = $"..//..//..//{Console.ReadLine()}";

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            if (SaveList.Count() > 0)
            {
                foreach (Monster M in SaveList)
                {
                    outputFile.WriteLine($"{M.GetName()},{M.GetMonsterID()},{M.GetMaxHP()},{M.GetCurrentHP()},{M.GetAC()},{M.GetInitiativeBonus()},{M.GetInitiative()},{M.GetLinearInitiativeStick()},{M.GetSTR()},{M.GetDEX()},{M.GetCON()},{M.GetINT()},{M.GetWIS()},{M.GetCHA()}");                    
                }

                Console.WriteLine("Saved... Press [Enter] to Continue.");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("There are no Monsters currently on file. Can not save. Press [Enter] to Continue.");
                Console.ReadLine();
            }
        }
    }

public List<Monster> LoadMonsterFile()
    {
        bool file_used = false;
        List<Monster> NewMonsters = [];

        Console.WriteLine("Enter the file name you want to load into the system: ");
        string filenameOG = Console.ReadLine();
        string filename = $"..//..//..//{filenameOG}";

        foreach (string file in _FilesUsed)
        {
            if (file == filename)
            {
                file_used = true;
            }
        }

        if (file_used == false)
        {
            _FilesUsed.Add(filename);
            _FilesUsed.Add(filenameOG);
        }

        try
        { 
            string[] lines = System.IO.File.ReadAllLines(filenameOG);

            if (!file_used)
            {
                foreach (string line in lines)
                {
                    string[] parts = line.Split(",");

                    try
                    {
                        if (parts.Length < 14)
                        {
                            Console.WriteLine($"Warning: Skipping malformed line -> {line}");
                            continue;
                        }
                        Monster M = new Monster( parts[0], parts[1], int.Parse(parts[4]), int.Parse(parts[2]), int.Parse(parts[3]), int.Parse(parts[8]), int.Parse(parts[9]), int.Parse(parts[10]), int.Parse(parts[11]), int.Parse(parts[12]), int.Parse(parts[13]));

                        M.UpdateInitiative(int.Parse(parts[6]));
                        M.UpdateLinearInitiativeStick(bool.Parse(parts[7]));
                        M.UpdateInitiativeBonus(int.Parse(parts[5]));
                        NewMonsters.Add(M);
                    }
                    catch (FormatException fe)
                    {
                        Console.WriteLine($"Data format error in line: {line} -> {fe.Message}");
                    }
                    catch (IndexOutOfRangeException)
                    {
                        Console.WriteLine($"Line does not contain enough fields: {line}");
                    }
                }

                return NewMonsters;
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"Error: The file '{filenameOG}' was not found, Trying Alternitive methood.");

            try
            { 
                string[] lines = System.IO.File.ReadAllLines(filename);

                if (!file_used)
                {
                    foreach (string line in lines)
                    {
                        string[] parts = line.Split(",");

                        try
                        {
                            if (parts.Length < 14)
                            {
                                Console.WriteLine($"Warning: Skipping malformed line -> {line}");
                                continue;
                            }
                            Monster M = new Monster( parts[0], parts[1], int.Parse(parts[4]), int.Parse(parts[2]), int.Parse(parts[3]), int.Parse(parts[8]), int.Parse(parts[9]), int.Parse(parts[10]), int.Parse(parts[11]), int.Parse(parts[12]), int.Parse(parts[13]));

                            M.UpdateInitiative(int.Parse(parts[6]));
                            M.UpdateLinearInitiativeStick(bool.Parse(parts[7]));
                            M.UpdateInitiativeBonus(int.Parse(parts[5]));
                            NewMonsters.Add(M);
                        }
                        catch (FormatException fe)
                        {
                            Console.WriteLine($"Data format error in line: {line} -> {fe.Message}");
                        }
                        catch (IndexOutOfRangeException)
                        {
                            Console.WriteLine($"Line does not contain enough fields: {line}");
                        }
                    }
                }
            
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"Error: The file '{filenameOG}' and '{filename}' was not found. Press [Enter to Continue]");
                Console.ReadLine();
            }

        }
        return NewMonsters;
    }





    public List<PlayerCharacter> LoadPlayerCharacterFile()
    {
        bool file_used = false;
        List<PlayerCharacter> NewPlayers = [];

        Console.WriteLine("Enter the file name you want to load into the system: ");
        string filenameOG = Console.ReadLine();
        string filename = $"..//..//..//{filenameOG}";

        if (_FilesUsed is not null)
        {
            foreach (string file in _FilesUsed)
            {

                if (file == filename)
                {
                    file_used = true;
                }
            }
        }
        

        if (file_used == false)
        {
            _FilesUsed.Add(filename);
        }


        
        try
        {
            string[] lines = System.IO.File.ReadAllLines(filenameOG);
            if (!file_used)
            {
                foreach (string line in lines)
                {
                    string[] parts = line.Split(",");

                    try
                    {
                       if (parts.Length < 6)
                        {
                            Console.WriteLine($"Warning: Skipping malformed line -> {line}");
                            continue;
            
                        }
                        PlayerCharacter pc = new PlayerCharacter( parts[0], parts[1], int.Parse(parts[4]), int.Parse(parts[2]), int.Parse(parts[3]), int.Parse(parts[5]));
                        pc.UpdateInitiative(int.Parse(parts[6]));
                        pc.UpdateLinearInitiativeStick(bool.Parse(parts[7]));
                        NewPlayers.Add(pc);
                    } 
                    catch (FormatException fe)
                    {
                        Console.WriteLine($"Data format error in line: {line} -> {fe.Message}");
                    }
                    catch (IndexOutOfRangeException)
                    {
                        Console.WriteLine($"Line does not contain enough fields: {line}");
                    }
                }
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"Error: The file '{filenameOG}' was not found, Trying Alternitive methood.");

            try
            { 
                string[] lines = System.IO.File.ReadAllLines(filename);
                if (!file_used)
                {
                    foreach (string line in lines)
                    {
                        string[] parts = line.Split(",");
                        try
                        {
                            if (parts.Length < 6)
                            {
                                Console.WriteLine($"Warning: Skipping malformed line -> {line}. Press [Enter to Continue]");
                                Console.ReadLine();
                                continue;
                            }
                            PlayerCharacter pc = new PlayerCharacter( parts[0], parts[1], int.Parse(parts[4]), int.Parse(parts[2]), int.Parse(parts[3]), int.Parse(parts[5]));
                            pc.UpdateInitiative(int.Parse(parts[6]));
                            pc.UpdateLinearInitiativeStick(bool.Parse(parts[7]));
                            NewPlayers.Add(pc);
                        }
                        catch (FormatException fe)
                        {
                            Console.WriteLine($"Data format error in line: {line} -> {fe.Message}. Press [Enter to Continue]");
                            Console.ReadLine();
                        }
                        catch (IndexOutOfRangeException)
                        {
                            Console.WriteLine($"Line does not contain enough fields: {line}. Press [Enter to Continue]");
                            Console.ReadLine();
                        }
                    }
                }

            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"Error: The file '{filenameOG}' and '{filename}' was not found. Press [Enter to Continue]");
                Console.ReadLine();
            }
        }
        return NewPlayers;
    }
        
}