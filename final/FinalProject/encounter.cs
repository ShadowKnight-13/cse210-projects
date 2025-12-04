using System;

public class Encounter
{
    
    public void Combat(List<PlayerCharacter> _playerCharacters, List<Monster> _monsters)
    {
        Initiative fight = new Initiative();
        DiceRoller dice = new DiceRoller();
        string choice2 = "";
        int round = 1;
        int turn = 1;
        bool linearInitiative = true;
        int True = 0;
        int False = 0;

        try { Console.Clear(); } catch (IOException) { Console.WriteLine("Console.Clear() failed."); }

        fight.CreateInitiativeOrder(_playerCharacters, _monsters);
        List<Character> characters = fight.GetOrder();

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

        if (True > False) { linearInitiative = true; }

        

        while (choice2 != "quit")
        {
            Console.WriteLine($"\nRound: {round} | Turn: {turn} | {fight.GetCurrentTurn(turn-1)}");
            Console.WriteLine($"Hp: {characters[turn-1].GetCurrentHP()}/{characters[turn-1].GetMaxHP()} | AC: {characters[turn-1].GetAC()}");
            
            if(characters[turn-1].GetActiveConditions() is not null)
            {
               foreach (string condition in characters[turn-1].GetActiveConditions())
                {
                    Console.Write($"{condition}, ");
                } 
                Console.WriteLine(" ");
            }

            Console.WriteLine($"\n1: See Order\n2: Damage \n3: Saving Throw\n4: Add/Remove Condition\n5: Next Turn\n6: Quit");
            choice2 = Console.ReadLine();

            while (choice2 != "1" & choice2!= "2" & choice2!= "3" & choice2!= "4" & choice2!= "5" & choice2!= "6")
            {
                Console.WriteLine("Invaild Input, Please Try again.");
                choice2 = Console.ReadLine();
            }

            if (choice2 == "1")
            {
                try { Console.Clear(); } catch (IOException) { Console.WriteLine("Console.Clear() failed."); }
                Console.WriteLine($"Round: {round} | Turn: {turn} | {fight.GetCurrentTurn(turn-1)}");
                Console.WriteLine($"Hp: {characters[turn-1].GetCurrentHP()}/{characters[turn-1].GetMaxHP()} | AC: {characters[turn-1].GetAC()}\n");
                fight.DisplayOrder();
                Console.WriteLine("\nPress [Enter] to Continue.");
                Console.ReadLine();
                
            }
            else if (choice2 == "2")
            {
                try { Console.Clear(); } catch (IOException) { Console.WriteLine("Console.Clear() failed."); }
                Console.WriteLine($"Round: {round} | Turn: {turn} | {fight.GetCurrentTurn(turn-1)}");
                Console.WriteLine($"Hp: {characters[turn-1].GetCurrentHP()}/{characters[turn-1].GetMaxHP()} | AC: {characters[turn-1].GetAC()}\n");
                fight.DisplayOrder();

                Console.WriteLine("Choose someone to Damage:");
                int choice3 = fight.ChoiceOfCharacter();

                Console.WriteLine("How much Damage is inflicted?");
                bool valid = false;
                int damage = 0;
                while (!valid)
                {
                    if (int.TryParse(Console.ReadLine(),out damage)) { valid = true; }
                    else { Console.WriteLine("Invaild Input, Please Try again."); }
                }
                
                characters[choice3-1].TakeDamage(damage);
            }
            else if (choice2 == "3")
            {
                try { Console.Clear(); } catch (IOException) { Console.WriteLine("Console.Clear() failed."); }
                int choice6 = 0;
                Console.WriteLine($"Round: {round} | Turn: {turn} | {fight.GetCurrentTurn(turn-1)}");
                Console.WriteLine($"Hp: {characters[turn-1].GetCurrentHP()}/{characters[turn-1].GetMaxHP()} | AC: {characters[turn-1].GetAC()}\n");

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

                            switch (choice7num)
                            {
                                case 1:
                                    Console.WriteLine(dice.RollDice(20, m.modifierCalulator(m.GetSTR())));
                                    break;

                                case 2:
                                    Console.WriteLine(dice.RollDice(20, m.modifierCalulator(m.GetDEX())));
                                    break; 

                                case 3:
                                    Console.WriteLine(dice.RollDice(20, m.modifierCalulator(m.GetCON())));
                                    break;

                                case 4:
                                    Console.WriteLine(dice.RollDice(20, m.modifierCalulator(m.GetINT())));
                                    break;

                                case 5:
                                    Console.WriteLine(dice.RollDice(20, m.modifierCalulator(m.GetWIS())));
                                    break;

                                case 6:
                                    Console.WriteLine(dice.RollDice(20, m.modifierCalulator(m.GetCHA())));
                                    break;

                                case 7:
                                    Console.WriteLine(dice.RollDice(20));
                                    break;                
                            }
                            Console.WriteLine("Press [Enter] to Continue");
                            Console.ReadLine();

                        }
                        else
                        {
                            Console.WriteLine($"{characters[choice6-1].GetName()} has to make a saving throw.");
                            Console.WriteLine("Press [Enter] to Continue");
                            Console.ReadLine(); 
                        }
                        
                    }
                }
            }
            else if (choice2 == "4")
            {
                try { Console.Clear(); } catch (IOException) { Console.WriteLine("Console.Clear() failed."); }
                Console.WriteLine($"Round: {round} | Turn: {turn} | {fight.GetCurrentTurn(turn-1)}");
                Console.WriteLine($"Hp: {characters[turn-1].GetCurrentHP()}/{characters[turn-1].GetMaxHP()} | AC: {characters[turn-1].GetAC()}\n");
                fight.DisplayConditions();

                Console.WriteLine("\n\n1: Add Condition\n2: Remove Condition\n3: Clear Conditions\n4: Back");
                string choice4 = Console.ReadLine();

                while (choice4 != "1" & choice4!= "2" & choice4!= "3" & choice4!= "4")
                {
                    Console.WriteLine("Invaild Input, Please Try again.");
                    choice4 = Console.ReadLine();
                }

                if (choice4 == "1")
                {
                    fight.DisplayConditions();
                    Console.WriteLine("Which character would you like to add a Condition to?");
                    int choice5 = fight.ChoiceOfCharacter();

                    Console.WriteLine("What Condition do you add?");
                    string Condition = Console.ReadLine();

                    characters[choice5-1].AddCondition(Condition);
                }
                else if (choice4 == "2")
                {
                    fight.DisplayConditions();
                    Console.WriteLine("Which character would you like to remove a Condition from?");
                    int choice5 = fight.ChoiceOfCharacter();

                    characters[choice5-1].RemoveCondition();
                }
                else if (choice4 == "3")
                {
                    fight.DisplayConditions();
                    Console.WriteLine("Which character would you like to clear of all Conditions?");
                    int choice5 = fight.ChoiceOfCharacter();

                    characters[choice5-1].ClearConditions();
                }

            }
            else if (choice2 == "5")
            {
                turn++;

                if (turn > characters.Count())
                {
                    round++;
                    turn = 1;

                    if (linearInitiative == false)
                    {
                        fight.CreateInitiativeOrder2(characters);
                        characters = fight.GetOrder();
                    }
                }
            }
            else
            {
                choice2 = "quit";
            }
                
            
        }
    }
}