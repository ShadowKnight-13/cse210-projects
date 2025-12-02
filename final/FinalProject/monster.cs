using System;
using System.Runtime.Versioning;

public class Monster : Character
{
    private int _STR;
    private int _DEX;
    private int _CON;
    private int _INT;
    private int _WIS;
    private int _CHA;

    private string _monsterID;
    public Monster(string name, string monsterID, int AC, int maxHP, int currentHP, int str, int dex, int con, int Int, int wis, int cha) : base(name,AC,maxHP,currentHP)
    {
        UpdateSTR(str);
        UpdateDEX(dex);
        UpdateCON(con);
        UpdateINT(Int);
        UpdateWIS(wis);
        UpdateCHA(cha);
    }

    public void UpdateMonsterID(string input)
    {
        _monsterID = input;
    }

    public void UpdateSTR(int str)
    {
        _STR = str;
    }
    public void UpdateDEX(int dex)
    {
        _DEX = dex;
    }

    public void UpdateCON(int input)
    {
        _CON = input;
    }

    public void UpdateINT(int input)
    {
        _INT = input;
    }

    public void UpdateWIS(int input)
    {
        _WIS = input;
    }

    public void UpdateCHA(int input)
    {
        _CHA = input;
    }


    public string GetMonsterID()
    {
        return _monsterID;
    }
    public int GetSTR()
    {
        return _STR;
    }

    public int GetDEX()
    {
        return _DEX;
    }

    public int GetCON()
    {
        return _CON;
    }

    public int GetINT()
    {
        return _INT;
    }

    public int GetWIS()
    {
        return _WIS;
    }

    public int GetCHA()
    {
        return _CHA;
    }

    public override string GetDisplayName()
    {
        return $"{GetName()} ({GetMonsterID()})";
    }




    public string GetMonsterIDFromUser()
    {
        Console.WriteLine("Enter the Monster ID");
        string output = Console.ReadLine();
        return output;
    } 
    public int GetSTRFromUser()
    {
        Console.WriteLine("Enter STR Score:");
        int str = GetNumberFromUser();

        return str;
    }

    public int GetDEXFromUser()
    {
        Console.WriteLine("Enter DEX Score:");
        int dex = GetNumberFromUser();

        return dex;
    }

    public int GetCONFromUser()
    {
        Console.WriteLine("Enter CON Score:");
        int con = GetNumberFromUser();

        return con;
    }

    public int GetINTFromUser()
    {
        Console.WriteLine("Enter INT Score:");
        int Int = GetNumberFromUser();

        return Int;
    }

    public int GetWISFromUser()
    {
        Console.WriteLine("Enter WIS Score:");
        int wis = GetNumberFromUser();

        return wis;
    }

    public int GetCHAFromUser()
    {
        Console.WriteLine("Enter CHA Score:");
        int cha = GetNumberFromUser();

        return cha;
    }

    public int modifierCalulator(int input)
    {
        double x = input;

        x -= 10;
        int output = (int)Math.Floor(x/2);
        return output;
    }
}