using System;
using System.Diagnostics;
using System.Dynamic;

public abstract class Character
{
    private string _name;
    private int _maxHP;
    private int _currentHP;

    private int _AC;
    private int _initiative;
    private int _initiativeBonus;
    private bool _linearInitiativeStick = true;

    private List<string> _activeConditions = [];

    

    public Character(string name, int AC, int maxHP, int currentHP)
    {
        UpdateName(name);
        UpdateAC(AC);
        UpdateMaxHP(maxHP);
        UpdateCurrentHP(currentHP);
    }

    public void UpdateName(string name)
    {
        _name = name;
    }

    public void UpdateAC(int AC)
    {
        _AC = AC;
    }

    public void UpdateMaxHP(int maxHP)
    {
        _maxHP = maxHP;
    }

    public void UpdateCurrentHP(int currentHP)
    {
        _currentHP = currentHP;
    }

    public void UpdateInitiative(int input)
    {
        _initiative = input;
    }

    public void UpdateLinearInitiativeStick(bool input)
    { 
        _linearInitiativeStick = input;   
    }



    public string GetName()
    {
        return _name;
    }

    public int GetAC()
    {
        return _AC;
    }

    public int GetMaxHP()
    {
        return _maxHP;
    }

    public int GetCurrentHP()
    {
        return _currentHP;
    }

    public int GetInitiative()
    {
        return _initiative;
    }

    public virtual string GetDisplayName()
    {
        return GetName();
    }

    public bool GetLinearInitiativeStick()
    {
        return _linearInitiativeStick;
    }
    



    public void TakeDamage(int damage)
    {
        _currentHP -= damage;
    }


    public void AddCondition(string condition)
    {
        _activeConditions.Add(condition);
    }


    public void RemoveCondition()
    {
        Console.WriteLine("Which Condition Would you like to remove?");

        int counter = 1;
        foreach (string condition in _activeConditions)
        {
            Console.WriteLine($"{counter}: {condition}");
            counter++;           
        }

        int index = GetNumberFromUser();
        _activeConditions.RemoveAt(index - 1);

        try { Console.Clear(); } catch (IOException) { Console.WriteLine("Console.Clear() failed."); }
    }

    public void ClearConditions()
    {
        _activeConditions.Clear();
    }

    public List<string> GetActiveConditions()
    {
        return _activeConditions;
    }




    public string GetCharacterNameFromUser()
    {
        Console.WriteLine("Enter the Character's name:");
        string name = Console.ReadLine();
        return name;
    }

    public int GetCharacterACFromUser()
    {
        Console.WriteLine("Enter the Character's AC:");
        int AC = GetNumberFromUser();

        return AC;
    }

    public int GetMaxHPFromUser()
    {
        Console.WriteLine("Enter the Character's Max HP:");
        int MaxHP = GetNumberFromUser();

        return MaxHP;
    }

    public int StartingCurrentHP()
    {
        UpdateCurrentHP(GetMaxHP());
        return GetMaxHP();
    }

    public int GetCurrentHPFromUser()
    {
        Console.WriteLine("Enter the Character's Current HP:");
        int currentHP = GetNumberFromUser();

        return currentHP;
    }

    public int GetInitiativeFromUser()
    {
        Console.WriteLine("Enter the Initiative score:");
        int output = GetNumberFromUser();
        return output;
    }

    public void UpdateInitiativeBonus(int input)
    {
        _initiativeBonus = input;   
    }

    public int GetInitiativeBonus()
    {
        return _initiativeBonus;
    }

    public int GetInitiativeBonusFromUser()
    {
        Console.WriteLine("Enter the Initiative Bonus");
        int output = GetNumberFromUser();
        return output;
    }




    public int GetNumberFromUser()
    {
        bool valid = false;
        int output = 0;
        while (!valid)
        {
            if (int.TryParse(Console.ReadLine(),out output)) { valid = true; }
            else { Console.WriteLine("Invaild Input, Please Try again."); }
        }

        return output;
    }

}