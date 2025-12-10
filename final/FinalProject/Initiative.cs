using System;
using System.Runtime.Intrinsics.X86;

public class Initiative
{
    private List<Character> _Order = [];
    private  Random rng = new Random();

    
    
    public void CreateInitiativeOrder(List<PlayerCharacter> _playerCharacters, List<Monster> _monsters, Log log)
    {
        _Order.Clear();
        DiceRoller D20 = new DiceRoller();

        
        foreach (PlayerCharacter pc in _playerCharacters)
        {
            pc.UpdateInitiative(D20.RollDice(20,pc.GetInitiativeBonus()));
            Console.WriteLine($"{pc.GetDisplayName()} rolled {pc.GetInitiative()}");
            log.UpdateLog($"{DateTime.Now}: {pc.GetDisplayName()} rolled {pc.GetInitiative()} for Initiative.");
            _Order.Add(pc);
        }

        foreach (Monster m in _monsters)
        {
            m.UpdateInitiative(D20.RollDice(20,m.modifierCalulator(m.GetDEX())));
            Console.WriteLine($"{m.GetDisplayName()} rolled {m.GetInitiative()}");
            log.UpdateLog($"{DateTime.Now}: {m.GetDisplayName()} rolled {m.GetInitiative()} for Initiative.");
            _Order.Add(m);
        }

        Console.WriteLine(" ");
        _Order = _Order.OrderByDescending(Character => Character.GetInitiative()).ToList();
    }






    public void CreateInitiativeOrder2(List<Character> characters,Log log)
    {
        var snapshot = new List<Character>(characters);
        List<PlayerCharacter> PCs = [];
        List<Monster> Ms = [];

        foreach (Character c in snapshot)
        {
            if (c is PlayerCharacter pc)
            {
                PCs.Add(pc);
            }
            else if(c is Monster M)
            {
                Ms.Add(M);
            }
        }

        CreateInitiativeOrder(PCs, Ms, log);
    }






    public string GetCurrentTurn(int turn)
    {
        return _Order[turn].GetDisplayName();
    }

    public int CountOfCharacters()
    {
        return _Order.Count();
    }

    public List<Character> GetOrder()
    {
        return _Order;
    }






    public void DisplayOrder()
    {
        int counter1 = 1;
        foreach (Character c in _Order)
        {
            Console.WriteLine($"{counter1}: {c.GetDisplayName()} | Initiative Score: {c.GetInitiative()}");
            Console.WriteLine($"    Hp: {c.GetCurrentHP()}/{c.GetMaxHP()} | AC: {c.GetAC()}\n");
            counter1++;
        }
    }





    public void DisplayConditions()
    {
        int counter1 = 1;
        foreach (Character c in _Order)
        {
            Console.Write($"\n{counter1}: {c.GetDisplayName()} ");
            foreach (string condition in c.GetActiveConditions())
            {
                Console.Write($"{condition}, ");
            }
            counter1++;
        }
    }





    public int ChoiceOfCharacter(bool quitOption=false)
    {
        int choice = 0;
        bool valid = false;
        bool secertExit = false;
        
        if (quitOption)
        {
            while (choice < 1 || choice > CountOfCharacters())
            {
                while (!valid)
                {
                    string input = Console.ReadLine();
                    if (int.TryParse(input,out choice)) { valid = true; }
                    else 
                    { 
                        if (input.ToLower() == "quit") { valid = true; secertExit = true; choice = 1;}
                        else { Console.WriteLine("Invaild Input, Please Try again."); }
                         
                    }
                }
                if (choice == CountOfCharacters() + 1)
                {
                    valid = true; secertExit = true; choice = 1;
                }
                else if (choice < 1 || choice > CountOfCharacters())
                {
                    Console.WriteLine("Please enter a number in range.");
                }
            }
        }
        else
        {
            while (choice < 1 || choice > CountOfCharacters())
            {
                while (!valid)
                {
                    if (int.TryParse(Console.ReadLine(),out choice)) { valid = true; }
                    else { Console.WriteLine("Invaild Input, Please Try again."); }
                }
                if (choice < 1 || choice > CountOfCharacters())
                {
                    Console.WriteLine("Please enter a number in range.");
                }
            }
        }
            
        if (secertExit){ choice = -100;}
        return choice;
    }


}