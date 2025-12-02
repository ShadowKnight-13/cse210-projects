using System;
using System.IO.Compression;
using System.Transactions;

public class PlayerCharacter : Character
{
    private string _playerName;
    

    public PlayerCharacter(string playername, string name, int AC, int maxHP, int currentHP, int initiativeBonus) : base(name, AC, maxHP, currentHP)
    {
        UpdatePlayerName(playername);
    }

    public void UpdatePlayerName(string playername)
    {
        _playerName = playername;
    }

    public string GetPlayerName()
    {
        return _playerName;
    }
    public string GetPlayerNameFromUser()
    {
        Console.WriteLine("Enter the Player's Name");
        string playerName = Console.ReadLine();

        return playerName;
    }

    public override string GetDisplayName()
    {
        return $"{GetName()} ({GetPlayerName()})";
    }
    


}