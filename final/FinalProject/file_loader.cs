using System;

public class FileLoader
{
    private List<string> _FilesUsed;

    public void SavePlayerCharacters(List<PlayerCharacter> SaveList)
    {
        Console.WriteLine("Enter the file name you want to save your entries into:");
        string filename = $"..//..//..//{Console.ReadLine()}";

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
                Console.WriteLine("There are no Player Characters currently on file. Can not save. Press [Enter] to Continue.");
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

        Console.WriteLine("Enter the file name you want to load into the system: ");
        string filename = $"..//..//..//{Console.ReadLine()}";

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
        }

        string[] lines = System.IO.File.ReadAllLines(filename);
        List<Monster> NewMonsters = [];

        if (file_used == false)
        {
            foreach (string line in lines)
            {
                string[] parts = line.Split(",");

                Monster M = new Monster(parts[0],parts[1],int.Parse(parts[4]),int.Parse(parts[2]),int.Parse(parts[3]),int.Parse(parts[8]),int.Parse(parts[9]),int.Parse(parts[10]),int.Parse(parts[11]),int.Parse(parts[12]),int.Parse(parts[13]));
                M.UpdateInitiative(int.Parse(parts[6]));
                M.UpdateLinearInitiativeStick(bool.Parse(parts[7]));
                M.UpdateInitiativeBonus(int.Parse(parts[5]));

                NewMonsters.Add(M);
            }
        }
        return NewMonsters;
    }




    public List<PlayerCharacter> LoadPlayerCharacterFile()
    {
        bool file_used = false;

        Console.WriteLine("Enter the file name you want to load into the system: ");
        string filename = $"..//..//..//{Console.ReadLine()}";

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
        }

        string[] lines = System.IO.File.ReadAllLines(filename);
        List<PlayerCharacter> NewPlayers = [];

        if (file_used == false)
        {
            foreach (string line in lines)
            {
                string[] parts = line.Split(",");

                PlayerCharacter pc = new PlayerCharacter(parts[0],parts[1],int.Parse(parts[4]),int.Parse(parts[2]),int.Parse(parts[3]),int.Parse(parts[5]));
                pc.UpdateInitiative(int.Parse(parts[6]));
                pc.UpdateLinearInitiativeStick(bool.Parse(parts[7]));

                NewPlayers.Add(pc);
            }
        }
        return NewPlayers;
    }
}