using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

public class Encounter
{
    
    public void Combat(List<PlayerCharacter> _playerCharacters, List<Monster> _monsters)
    {
        Initiative fight = new Initiative();
        DiceRoller dice = new DiceRoller();
        Log log = new Log();
        string choice2 = "";

        int round = 1;
        int turn = 1;
        int turnmod = 1;


        bool linearInitiative = false;
        int True = 0;
        int False = 0;

        try { Console.Clear(); } catch (IOException) { Console.WriteLine("Console.Clear() failed."); }

        log.UpdateLog("--Encounter Start--");
        fight.CreateInitiativeOrder(_playerCharacters, _monsters, log);
        List<Character> characters = fight.GetOrder();

        foreach (Character c in characters)
        {
            if (c.GetLinearInitiativeStick())
            {
                True++;
            }
            else
            {
                False ++;
            }
        }

        if (True > False) { linearInitiative = true; }
        else { linearInitiative = false;}

        

        while (choice2 != "quit")
        {
            int idx = Math.Clamp(turn - turnmod, 0, Math.Max(characters.Count() - 1, 0));
            Console.WriteLine($"\nRound: {round} | Turn: {turn} | {fight.GetCurrentTurn(idx)}");
            if (characters.Count() > 0)
            {
                Console.WriteLine($"Hp: {characters[idx].GetCurrentHP()}/{characters[idx].GetMaxHP()} | AC: {characters[idx].GetAC()}");
            }
            
            if (characters.Count() > 0 && characters[idx].GetActiveConditions() is not null)
            {
               foreach (string condition in characters[idx].GetActiveConditions())
                {
                    Console.Write($"{condition}, ");
                } 
                Console.WriteLine(" ");
            }

            Console.WriteLine($"\n1: See Order\n2: Damage \n3: Saving Throw\n4: Roll Dice\n5: Add/Remove Condition\n6: Remove Character\n7: Next Turn\n8: Quit");
            choice2 = Console.ReadLine();

            while (choice2 != "1" & choice2!= "2" & choice2!= "3" & choice2!= "4" & choice2!= "5" & choice2!= "6" & choice2!= "7" & choice2!= "8")
            {
                Console.WriteLine("Invaild Input, Please Try again.");
                choice2 = Console.ReadLine();
            }

            if (choice2 == "1")
            {
                try { Console.Clear(); } catch (IOException) { Console.WriteLine("Console.Clear() failed."); }
                idx = Math.Clamp(turn - turnmod, 0, Math.Max(characters.Count() - 1, 0));
                Console.WriteLine($"Round: {round} | Turn: {turn} | {fight.GetCurrentTurn(idx)}");
                if (characters.Count() > 0)
                {
                    Console.WriteLine($"Hp: {characters[idx].GetCurrentHP()}/{characters[idx].GetMaxHP()} | AC: {characters[idx].GetAC()}\n");
                }
                fight.DisplayOrder();
                Console.WriteLine("\nPress [Enter] to Continue.");
                Console.ReadLine();
                try { Console.Clear(); } catch (IOException) { Console.WriteLine("Console.Clear() failed."); }
            }
            else if (choice2 == "2")
            {
                DisplayTurnHeader(characters,round,turn,fight,turnmod);
                fight.DisplayOrder();

                Console.WriteLine("Choose someone to Damage:");
                int choice3 = fight.ChoiceOfCharacter();

                Console.WriteLine("\nHow much Damage is inflicted?");
                bool valid = false;
                int damage = 0;
                while (!valid)
                {
                    if (int.TryParse(Console.ReadLine(),out damage)) { valid = true; }
                    else { Console.WriteLine("Invaild Input, Please Try again."); }
                }
                
                characters[choice3-1].TakeDamage(damage);

                if (damage > 0)
                {
                    log.UpdateLog($"{DateTime.Now}: {fight.GetCurrentTurn(turn - turnmod)} damaged {characters[choice3-1].GetDisplayName()} for {damage} point/s.");
                }
                else
                {
                    log.UpdateLog($"{DateTime.Now}: {fight.GetCurrentTurn(turn - turnmod)} Healed {characters[choice3-1].GetDisplayName()} for {damage} point/s.");
                }
                try { Console.Clear(); } catch (IOException) { Console.WriteLine("Console.Clear() failed."); }
            }
            else if (choice2 == "3")
            {
                
                int choice6 = 0;
                DisplayTurnHeader(characters,round,turn,fight,turnmod);

                while (choice6 != -100)
                {
                    fight.DisplayOrder();
                    Console.WriteLine($"{fight.CountOfCharacters() + 1}: Quit");

                    Console.WriteLine($"Who would you like to make a saving thow? (Type {fight.CountOfCharacters()+1} or Quit to quit)");
                    choice6 = fight.ChoiceOfCharacter(true);

                    if (choice6 != -100)
                    {
                        if (characters[choice6-1] is Monster m)
                        {
                            Console.WriteLine($"{m.GetDisplayName()} has to make a saving throw.\n");
                            Console.WriteLine("What ability is required?");
                            Console.WriteLine("1: STR\n2: DEX\n3: CON\n4: INT\n5: WIS\n6: CHA\n7: None");

                            string choice7 = Console.ReadLine();
                            while (choice7 != "1" & choice7!= "2" & choice7!= "3" & choice7!= "4" & choice7!= "5" & choice7!= "6" & choice7!= "7")
                            {
                                Console.WriteLine("Invaild Input, Please Try again.");
                                choice7 = Console.ReadLine();
                            }

                            bool valid = false;
                            int choice7num = 0;
                            while (!valid)
                            {
                                if (int.TryParse(choice7,out choice7num)) { valid = true; }
                                else { Console.WriteLine("Please enter the number index"); choice7 = Console.ReadLine();}
                            }

                            int roll;
                            switch (choice7num)
                            {
                                case 1:
                                    roll = dice.RollDice(20, m.modifierCalulator(m.GetSTR()));
                                    Console.WriteLine(roll);
                                    log.UpdateLog($"{DateTime.Now}: {fight.GetCurrentTurn(turn - turnmod)} caused {m.GetDisplayName()} to make a STR saving throw. [{roll}]");
                                    break;

                                case 2:
                                    roll = dice.RollDice(20, m.modifierCalulator(m.GetDEX()));
                                    Console.WriteLine(roll);
                                    log.UpdateLog($"{DateTime.Now}: {fight.GetCurrentTurn(turn - turnmod)} caused {m.GetDisplayName()} to make a DEX saving throw. [{roll}]");
                                    break; 

                                case 3:
                                    roll = dice.RollDice(20, m.modifierCalulator(m.GetCON()));
                                    Console.WriteLine(roll);
                                    log.UpdateLog($"{DateTime.Now}: {fight.GetCurrentTurn(turn - turnmod)} caused {m.GetDisplayName()} to make a CON saving throw. [{roll}]");
                                    break;

                                case 4:
                                    roll = dice.RollDice(20, m.modifierCalulator(m.GetINT()));
                                    Console.WriteLine(roll);
                                    log.UpdateLog($"{DateTime.Now}: {fight.GetCurrentTurn(turn - turnmod)} caused {m.GetDisplayName()} to make a INT saving throw. [{roll}]");
                                    break;

                                case 5:
                                    roll = dice.RollDice(20, m.modifierCalulator(m.GetWIS()));
                                    Console.WriteLine(roll);
                                    log.UpdateLog($"{DateTime.Now}: {fight.GetCurrentTurn(turn - turnmod)} caused {m.GetDisplayName()} to make a WIS saving throw. [{roll}]");
                                    break;

                                case 6:
                                    roll = dice.RollDice(20, m.modifierCalulator(m.GetCHA()));
                                    Console.WriteLine(roll);
                                    log.UpdateLog($"{DateTime.Now}: {fight.GetCurrentTurn(turn - turnmod)} caused {m.GetDisplayName()} to make a CHA saving throw. [{roll}]");
                                    break;

                                case 7:
                                    roll = dice.RollDice(20);
                                    Console.WriteLine(roll);
                                    log.UpdateLog($"{DateTime.Now}: {fight.GetCurrentTurn(turn - turnmod)} caused {m.GetDisplayName()} to make a saving throw. [{roll}]");
                                    break;                
                            }
                            Console.WriteLine("Press [Enter] to Continue");
                            Console.ReadLine();

                        }
                        else
                        {
                            Console.WriteLine($"{characters[choice6-1].GetDisplayName()} has to make a saving throw.");
                            log.UpdateLog($"{DateTime.Now}: {fight.GetCurrentTurn(turn - turnmod)} caused {characters[choice6-1].GetDisplayName()} to make a saving throw.");
                            Console.WriteLine("Press [Enter] to Continue");
                            Console.ReadLine(); 
                        }
                        
                    }
                }
            }
            else if (choice2 == "4")
            {
                DisplayTurnHeader(characters,round,turn,fight,turnmod);

                Console.WriteLine(" \nHow many sides are on the dice?");
                idx = Math.Clamp(turn - turnmod, 0, Math.Max(characters.Count() - 1, 0));
                int diceSides = characters[idx].GetNumberFromUser();
                Console.WriteLine(" \nHow many Dice do you wish to roll?");
                int numOfDice = characters[idx].GetNumberFromUser();

                int roll = dice.RollDice(diceSides,0,numOfDice);
                Console.WriteLine($" \n{roll}");
                log.UpdateLog($"{DateTime.Now}: {fight.GetCurrentTurn(idx)} rolled {numOfDice} {diceSides} sided dice. [{roll}]");
                Console.WriteLine("Press [Enter] to Continue");
                Console.ReadLine();
            }
            else if (choice2 == "5")
            {
                DisplayTurnHeader(characters,round,turn,fight,turnmod);
                Console.WriteLine("Character's Conditions");
                fight.DisplayConditions();

                Console.WriteLine(" \n Menu Options:");
                Console.WriteLine("1: Add Condition\n2: Remove Condition\n3: Clear Conditions\n4: Back");
                string choice4 = Console.ReadLine();

                while (choice4 != "1" & choice4!= "2" & choice4!= "3" & choice4!= "4")
                {
                    Console.WriteLine("Invaild Input, Please Try again.");
                    choice4 = Console.ReadLine();
                }

                if (choice4 == "1")
                {
                    fight.DisplayConditions();
                    Console.WriteLine(" \nWhich character would you like to add a Condition to?");
                    int choice5 = fight.ChoiceOfCharacter();

                    Console.WriteLine("What Condition do you add?");
                    string Condition = Console.ReadLine();

                    characters[choice5-1].AddCondition(Condition);
                    log.UpdateLog($"{DateTime.Now}: {fight.GetCurrentTurn(turn - turnmod)} added the '{Condition}' condition to {characters[choice5 - 1].GetDisplayName()}");
                }
                else if (choice4 == "2")
                {
                    fight.DisplayConditions();
                    Console.WriteLine(" \nWhich character would you like to remove a Condition from?\n ");
                    int choice5 = fight.ChoiceOfCharacter();

                    characters[choice5-1].RemoveCondition();
                    log.UpdateLog($"{DateTime.Now}: {characters[choice5 - 1].GetDisplayName()} had a condition was removed.");

                }
                else if (choice4 == "3")
                {
                    fight.DisplayConditions();
                    Console.WriteLine(" \nWhich character would you like to clear of all Conditions?\n ");
                    int choice5 = fight.ChoiceOfCharacter();

                    characters[choice5-1].ClearConditions();
                    log.UpdateLog($"{DateTime.Now}: {characters[choice5 - 1].GetDisplayName()} was cleared of all conditions.");
                }

            }
            else if (choice2 == "6")
            {
                DisplayTurnHeader(characters,round,turn,fight,turnmod);

                fight.DisplayOrder();
                Console.WriteLine($"{fight.CountOfCharacters() + 1}: Quit");

                Console.WriteLine($"Who would you like to remove from the encounter? (Type {fight.CountOfCharacters()+1} or Quit to quit)");
                int choice20 = fight.ChoiceOfCharacter(true);

                if (choice20 > 0 & choice20 <=characters.Count())
                {
                    log.UpdateLog($"{DateTime.Now}: {characters[choice20 - 1].GetDisplayName()} was removed from the encounter.");
                    
                    fight.RemoveFromOrder(choice20 -1);
                    characters = fight.GetOrder();
                    turnmod +=1;
                }
                
                
            }
            else if (choice2 == "7")
            {
                turn++;
                try { Console.Clear(); } catch (IOException) { Console.WriteLine("Console.Clear() failed."); }

                if (turn > characters.Count())
                {
                    round++;
                    turn = 1;
                    turnmod = 1;

                    try { Console.Clear(); } catch (IOException) { Console.WriteLine("Console.Clear() failed."); }

                    if (linearInitiative == false)
                    {
                        Console.WriteLine(" ");
                        fight.CreateInitiativeOrder2(characters, log);
                        characters = fight.GetOrder();
                    }
                }
            }
            else
            {
                choice2 = "quit";
                log.UpdateLog("--Encounter End--");

                Console.WriteLine(" \nDo you wish to save this encounter's log? (Y/N)");
                string savelog = Console.ReadLine().ToUpper();

                while (savelog != "Y" & savelog != "N")
                {
                    Console.WriteLine("Invaild Input, Please Try again.");
                    savelog = Console.ReadLine();
                }

                if (savelog == "Y")
                {
                    log.SaveLog();
                }
            }
        }
    }


    static void DisplayTurnHeader(List<Character> characters, int round, int turn, Initiative fight, int turnmod)
    {
        try { Console.Clear(); } catch (IOException) { Console.WriteLine("Console.Clear() failed."); }
        int idx = Math.Clamp(turn - turnmod, 0, Math.Max(characters.Count() - 1, 0));
        Console.WriteLine($"Round: {round} | Turn: {turn} | {fight.GetCurrentTurn(idx)}");
        if (characters.Count() > 0)
        {
            Console.WriteLine($"Hp: {characters[idx].GetCurrentHP()}/{characters[idx].GetMaxHP()} | AC: {characters[idx].GetAC()}\n");
        }
    }
}