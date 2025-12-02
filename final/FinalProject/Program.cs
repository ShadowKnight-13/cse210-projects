using System;
using System.Dynamic;

class Program
{
    static void Main(string[] args)
    {
        List<PlayerCharacter> _playerCharacters = [];
        List<Monster> _monsters = [];

        
        Console.WriteLine("Welcome to the DND Encounter Tracker!\n");
        int choice1num = DisplayMenu();

        while (choice1num != 8)
        {
            switch (choice1num)
            {
                case 1:
                    break;

                case 2:
                    break;

                case 3:
                    _playerCharacters = AddPlayerCharacter(_playerCharacters);
                    break;

                case 4:
                    _monsters = AddMonster(_monsters);
                    break;

                case 5:
                    Encounter fight1 = new Encounter();
                    fight1.Combat(_playerCharacters,_monsters);
                    break;

                case 6:
                    List<Character> characters = editEncounter(_playerCharacters,_monsters);
                    _playerCharacters.Clear();
                    _monsters.Clear();

                    foreach (Character c in characters)
                    {
                        if (c is PlayerCharacter pc) { _playerCharacters.Add(pc); }
                        else if (c is Monster M) { _monsters.Add(M); }
                    }
                    break;

                case 7:
                    break;

                case 8:
                    break;
            }

            Console.WriteLine("Welcome to the DND Encounter Tracker!\n");
            choice1num = DisplayMenu();
        }

    }

    static int DisplayMenu()
    {
        Console.WriteLine("Choose an option from the menu below.\n");
        Console.WriteLine("1: Load File\n2: Save File\n3: Add Player Character\n4: Add Monster\n5: Start Encounter\n6: Edit Encounter\n7: View Log\n8: Quit");

        string choice1 = Console.ReadLine();

        while (choice1 != "1" & choice1!= "2" & choice1!= "3" & choice1!= "4" & choice1!= "5" & choice1!= "6" & choice1!= "7" & choice1!= "8")
        {
            Console.WriteLine("Invaild Input, Please Try again.");
            choice1 = Console.ReadLine();
        }

        bool valid = false;
        int choice1num = 0;
        while (!valid)
        {
            if (int.TryParse(choice1,out choice1num)) { valid = true; }
            else { Console.WriteLine("Please enter the number index"); choice1 = Console.ReadLine();}
        }

        return choice1num;
    }

    static List<PlayerCharacter> AddPlayerCharacter(List<PlayerCharacter> _playerCharacter)
    {
        PlayerCharacter player = new PlayerCharacter("","",0,0,0,0);

        player.UpdatePlayerName(player.GetPlayerNameFromUser());
        player.UpdateName(player.GetCharacterNameFromUser());
        player.UpdateAC(player.GetCharacterACFromUser());
        player.UpdateMaxHP(player.GetMaxHPFromUser());
        player.UpdateCurrentHP(player.StartingCurrentHP());
        player.UpdateInitiativeBonus(player.GetInitiativeBonusFromUser());

        List<Character> characters = [];
        foreach(PlayerCharacter pc in _playerCharacter)
        {
            characters.Add(pc);
        }

        if (linearInitiativeTorF(characters))
        {
            player.UpdateLinearInitiativeStick(true);
        }
        else
        {
            player.UpdateLinearInitiativeStick(false);
        }
        
        _playerCharacter.Add(player);

        return _playerCharacter;
    }

    static List<Monster> AddMonster(List<Monster> _monsters)
    {
        Monster monster = new Monster("","",0,0,0,0,0,0,0,0,0);

        monster.UpdateName(monster.GetCharacterNameFromUser());
        monster.UpdateMonsterID(monster.GetMonsterIDFromUser());
        monster.UpdateAC(monster.GetCharacterACFromUser());
        monster.UpdateMaxHP(monster.GetMaxHPFromUser());
        monster.UpdateCurrentHP(monster.StartingCurrentHP());

        monster.UpdateSTR(monster.GetSTRFromUser());
        monster.UpdateDEX(monster.GetDEXFromUser());
        monster.UpdateCON(monster.GetCONFromUser());
        monster.UpdateINT(monster.GetINTFromUser());
        monster.UpdateWIS(monster.GetWISFromUser());
        monster.UpdateCHA(monster.GetCHAFromUser());

        monster.UpdateInitiativeBonus(monster.modifierCalulator(monster.GetDEX()));

        List<Character> characters = [];
        foreach(Monster m in _monsters)
        {
            characters.Add(m);
        }

        if (linearInitiativeTorF(characters))
        {
            monster.UpdateLinearInitiativeStick(true);
        }
        else
        {
            monster.UpdateLinearInitiativeStick(false);
        }

        _monsters.Add(monster);
        return _monsters;
    }

    public static List<Character> editEncounter(List<PlayerCharacter> _playerCharacters, List<Monster> _monsters)
    {
        string choice10 = "";

        while ( choice10 != "6")
        {
            Console.WriteLine("What do you wish to edit?");
            Console.WriteLine("1: Remove Character\n2: Clone Monster\n3: Edit Player Character\n4: Edit Monster\n5: Toggle Linear Initivate\n6: Quit");

            choice10 = Console.ReadLine();

            while (choice10 != "1" & choice10 != "2" & choice10 != "3" & choice10 != "4" & choice10 != "5" & choice10 != "6")
            {
                Console.WriteLine("Invaild Input, Please Try again.");
                choice10 = Console.ReadLine();
            }

            if (choice10 == "1")
            {

                List<Character> characters = [];

                foreach(PlayerCharacter pc in _playerCharacters)
                {
                    characters.Add(pc);
                }
                foreach(Monster m in _monsters)
                {
                    characters.Add(m);
                }

                int choice13 = chooseCharacter(characters);

                if (choice13 == 0){}
                else if (choice13 < _playerCharacters.Count())
                {
                    _playerCharacters.RemoveAt(choice13 - 1);
                }
                else
                {
                    _monsters.RemoveAt(choice13 - 1);
                }

            }
            else if (choice10 == "2")
            {
                List<Character> characters = [];

                if (_monsters.Count()> 0)
                {
                    foreach(Monster M in _monsters)
                    {
                        characters.Add(M);
                    }

                    int choice14 = chooseCharacter(characters);

                    Monster m = _monsters[choice14-1];

                    m.UpdateMonsterID(m.GetMonsterIDFromUser());

                    _monsters.Add(m);
                }
                else
                {
                    Console.WriteLine("There are no Monsters Loaded in.");
                }            
            }
            else if (choice10 == "3")
            {
                
                List<Character> characters = [];

                foreach(PlayerCharacter pc in _playerCharacters)
                {
                    characters.Add(pc);
                }

                int choice15 = chooseCharacter(characters);

                PlayerCharacter PC = _playerCharacters[choice15 -1];

                string choice16 = "";
                while (choice16 != "8")
                {
                    Console.WriteLine("What would you like to edit?\n");
                    Console.WriteLine("1: Player's Name\n2: Character's Name\n3: AC\n4: Current HP\n5: Max HP\n6: Initiative Bonus\n7: Conditions\n8: Quit");

                    choice16 = Console.ReadLine();

                    while (choice16 != "1" & choice16 != "2" & choice16 != "3" & choice16 != "4" & choice16 != "5" & choice16 != "6" & choice16 != "7" & choice16 != "8")
                    {
                        Console.WriteLine("Invaild Input, Please Try again.");
                        choice16 = Console.ReadLine();
                    }

                    if (choice16 == "1")
                    {
                        PC.UpdatePlayerName(PC.GetPlayerNameFromUser());
                    }
                    else if (choice16 == "2")
                    {
                       PC.UpdateName(PC.GetCharacterNameFromUser()); 
                    }
                    else if (choice16 == "3")
                    {
                      PC.UpdateAC(PC.GetCharacterACFromUser());  
                    }
                    else if (choice16 == "4")
                    {
                      PC.UpdateCurrentHP(PC.GetCurrentHPFromUser());  
                    }
                    else if (choice16 == "5")
                    {
                        PC.UpdateMaxHP(PC.GetMaxHPFromUser());
                    }
                    else if (choice16 == "6")
                    {
                        PC.UpdateInitiativeBonus(PC.GetInitiativeBonusFromUser());
                    }
                    else if (choice16 == "7")
                    {
                        if(PC.GetActiveConditions() is not null)
                        {
                           foreach (string condition in PC.GetActiveConditions())
                            {
                                Console.Write($"{condition}, ");
                            } 
                            Console.WriteLine(" ");
                        }

                        Console.WriteLine("\n\n1: Add Condition\n2: Remove Condition\n3: Clear Conditions\n4: Back");
                        string choice17 = Console.ReadLine();

                        while (choice17 != "1" & choice17!= "2" & choice17!= "3" & choice17!= "4")
                        {
                            Console.WriteLine("Invaild Input, Please Try again.");
                            choice17 = Console.ReadLine();
                        }

                        if (choice17 == "1")
                        {
                            Console.WriteLine("What Condition do you add?");
                            string Condition = Console.ReadLine();

                            PC.AddCondition(Condition);
                        }
                        else if (choice17 == "2")
                        {
                            PC.RemoveCondition();
                        }
                        else if (choice17 == "3")
                        {
                            PC.ClearConditions();
                        }
                    }

                    _playerCharacters.RemoveAt(choice15 -1);
                    _playerCharacters.Add(PC);
                }  
            }
            else if (choice10 == "4")
            {

              List<Character> characters = [];

                foreach(Monster m in _monsters)
                {
                    characters.Add(m);
                }

                int choice15 = chooseCharacter(characters);

                Monster M = _monsters[choice15 -1];

                string choice16 = "";
                while (choice16 != "9")
                {
                    Console.WriteLine("What would you like to edit?\n");
                    Console.WriteLine("1: Monster's Name\n2: Monster's ID\n3: AC\n4: Current HP\n5: Max HP\n6: Initiative Bonus\n7: Conditions\n8: Ability Scores\n9: Quit");

                    choice16 = Console.ReadLine();

                    while (choice16 != "1" & choice16 != "2" & choice16 != "3" & choice16 != "4" & choice16 != "5" & choice16 != "6" & choice16 != "7" & choice16 != "8" & choice16 !="9")
                    {
                        Console.WriteLine("Invaild Input, Please Try again.");
                        choice16 = Console.ReadLine();
                    }

                    if (choice16 == "1")
                    {
                        M.UpdateName(M.GetCharacterNameFromUser());
                    }
                    else if (choice16 == "2")
                    {
                        M.UpdateMonsterID(M.GetMonsterIDFromUser());
                    }
                    else if (choice16 == "3")
                    {
                      M.UpdateAC(M.GetCharacterACFromUser());  
                    }
                    else if (choice16 == "4")
                    {
                      M.UpdateCurrentHP(M.GetCurrentHPFromUser());  
                    }
                    else if (choice16 == "5")
                    {
                        M.UpdateMaxHP(M.GetMaxHPFromUser());
                    }
                    else if (choice16 == "6")
                    {
                        M.UpdateInitiativeBonus(M.GetInitiativeBonusFromUser());
                    }
                    else if (choice16 == "7")
                    {
                        if(M.GetActiveConditions() is not null)
                        {
                           foreach (string condition in M.GetActiveConditions())
                            {
                                Console.Write($"{condition}, ");
                            } 
                            Console.WriteLine(" ");
                        }

                        Console.WriteLine("\n\n1: Add Condition\n2: Remove Condition\n3: Clear Conditions\n4: Back");
                        string choice17 = Console.ReadLine();

                        while (choice17 != "1" & choice17!= "2" & choice17!= "3" & choice17!= "4")
                        {
                            Console.WriteLine("Invaild Input, Please Try again.");
                            choice17 = Console.ReadLine();
                        }

                        if (choice17 == "1")
                        {
                            Console.WriteLine("What Condition do you add?");
                            string Condition = Console.ReadLine();

                            M.AddCondition(Condition);
                        }
                        else if (choice17 == "2")
                        {
                            M.RemoveCondition();
                        }
                        else if (choice17 == "3")
                        {
                            M.ClearConditions();
                        }
                    }
                    else if (choice16 == "8")
                    {

                        Console.WriteLine("Which Ability Do you want to update?");
                        Console.WriteLine("1: STR\n2: DEX\n3: CON\n4: INT\n5: WIS\n6: CHA\n7: None");
                        string choice18 = Console.ReadLine();

                        while (choice18 != "1" & choice18 != "2" & choice18 != "3" & choice18 != "4" & choice18 != "5" & choice18 != "6" & choice18 != "7")
                        {
                            Console.WriteLine("Invaild Input, Please Try again.");
                            choice18 = Console.ReadLine();
                        }

                        if (choice18 == "1")
                        {
                            M.UpdateSTR(M.GetSTRFromUser());
                        }
                        else if (choice18 == "2")
                        {
                            M.UpdateDEX(M.GetDEXFromUser());
                            M.UpdateInitiativeBonus(M.modifierCalulator(M.GetDEX()));
                        }
                        else if (choice18 == "3")
                        {
                            M.UpdateCON(M.GetCONFromUser());
                        }
                        else if (choice18 == "4")
                        {
                            M.UpdateINT(M.GetINTFromUser());
                        }
                        else if (choice18 == "5")
                        {
                            M.UpdateWIS(M.GetWISFromUser());
                        }
                        else if (choice18 == "6")
                        {
                            M.UpdateCHA(M.GetCHAFromUser()); 
                        }
                    
                    }
                }  
            }
            else if (choice10 == "5")
            {
                int True = 0;
                int False = 0;

                List<Character> characters = [];

                foreach(PlayerCharacter pc in _playerCharacters)
                {
                    characters.Add(pc);
                }
                foreach(Monster m in _monsters)
                {
                    characters.Add(m);
                }

                foreach (Character c in characters)
                {
                    if (c.GetLinearInitiativeStick() == true)
                    {
                        True++;
                    }
                    else
                    {
                        False ++;
                    }
                }

                if (True > False)
                {
                    Console.WriteLine("Linear Initiative [ON]\n");
                }
                else
                {
                    Console.WriteLine("Linear Initiative [OFF]\n");
                }

                Console.WriteLine("Do you wish to Toggle? (Y/N)");
                string choice19 = Console.ReadLine().ToUpper();

                while (choice19 != "Y" & choice19 != "N")
                {
                    Console.WriteLine("Invaild Input please type (Y/N)");
                    choice19 = Console.ReadLine().ToUpper();
                }

                if (choice19 == "Y")
                {
                    if (True > False)
                    {
                        foreach (Character c in characters)
                        {
                            c.UpdateLinearInitiativeStick(false);
                        }
                    }
                    else
                    {
                        foreach(Character c in characters)
                        {
                            c.UpdateLinearInitiativeStick(true);
                        }
                    }
                }
            }
        }

        List<Character> charactersout = [];

        foreach(PlayerCharacter pc in _playerCharacters)
        {
            charactersout.Add(pc);
        }
        foreach(Monster m in _monsters)
        {
            charactersout.Add(m);
        }

        return charactersout;

    }


    static int chooseCharacter(List<Character> list)
    {

        if (list.Count()>0)
        {
            int counter = 1;
            foreach (Character c in list)
            {
                Console.WriteLine($"{counter}: {c.GetDisplayName()}");
                counter++;
            }
            Console.WriteLine(" \nWhich Character Would you like to choose");
            int choice12 = 0;
            bool valid = false;
            while (choice12 < 1 || choice12 > list.Count())
            {
                while (!valid)
                {
                    string input = Console.ReadLine();
                    if (int.TryParse(input,out choice12)) { valid = true; }
                    else 
                    { 
                        if (input.ToLower() == "quit") { valid = true;}
                        else { Console.WriteLine("Invaild Input, Please Try again."); }
                    }
                }
                if (choice12 < 1 || choice12 > list.Count())
                {
                    Console.WriteLine("Please enter a number in range.");
                }
            }
            return choice12;
        }
        else
        {
            Console.WriteLine("No Characters are currently loaded into this list.");
        }
        return 0;
    }

    public static bool linearInitiativeTorF(List<Character> list)
    {
        int True = 0;
        int False = 0;
        if (list.Count()>0)
        {
            foreach(Character c in list)
            {
                if (c.GetLinearInitiativeStick() == true)
                {
                    True++;
                }
                else
                {
                    False ++;
                }
            }
        }

        if (True>False)
        {
            return true;
        }
        else if (False >= True)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

}