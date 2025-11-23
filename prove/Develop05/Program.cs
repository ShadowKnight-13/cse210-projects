using System;
using System.Collections;
using System.Data.SqlTypes;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Goal Program!");

        string choice = "";
        int current_points = 0;
        List<SimpleGoal> simplegoals = [];
        List<EternalGoal> eternalgoals = [];
        List<ChecklistGoal> checklistgoals = [];

        do
        {
            Console.WriteLine("\n Please select one option below: \n1: Create Simple Goal \n2: Create Eternal Goal");
            Console.WriteLine("3: Create Checklist Goal \n4: Mark off Goals \n5: Save Progress \n6: Load File \n7: Quit");
            choice = Console.ReadLine();
            

            while (choice != "1" && choice != "2" && choice != "3" && choice != "4" && choice != "5" && choice != "6" && choice != "7")
            {
                Console.WriteLine("Invaild input, please try again.");
                choice = Console.ReadLine();
            }


            if (choice == "1")
            {
                try { Console.Clear(); } catch (IOException) { Console.WriteLine("Console.Clear() failed."); }
                
                SimpleGoal sg = new SimpleGoal();
                sg.GetGoalNameFromUser();
                sg.GetPointValueFromUser();

                simplegoals.Add(sg);

            }
            else if (choice == "2")
            {
                try { Console.Clear(); } catch (IOException) { Console.WriteLine("Console.Clear() failed."); }
                EternalGoal eg = new EternalGoal();
                eg.GetGoalNameFromUser();
                eg.GetPointValueFromUser();

                eternalgoals.Add(eg);
        
            }
            else if (choice == "3")
            {
                try { Console.Clear(); } catch (IOException) { Console.WriteLine("Console.Clear() failed."); }
                
                ChecklistGoal cg = new ChecklistGoal();
                cg.GetGoalNameFromUser();
                cg.GetPointValueFromUser();
                cg.getMaxCompletionFromUser();

                checklistgoals.Add(cg);
            }
            else if (choice == "4")
            {
                string choice2 = "";

                while (choice2 != "quit")
                {
                   try { Console.Clear(); } catch (IOException) { Console.WriteLine("Console.Clear() failed."); }

    
                    Console.WriteLine("\n Which goal do you wish to check off?");

                    int counter = 1;
                    foreach (SimpleGoal sg in simplegoals)
                    {
                        if (sg.GetGoalStatus() == false)
                        {
                            Console.WriteLine($"{counter}: [ ] {sg.GetGoalName()}");
                        }
                        else
                        {
                            Console.WriteLine($"{counter}: [x] {sg.GetGoalName()}");
                        }
                        counter++;
                    }

                    foreach (EternalGoal eg in eternalgoals)
                    {

                        Console.WriteLine($"{counter}: [{eg.GetCounter()}] {eg.GetGoalName()}");
                        counter++;
                    }

                    foreach (ChecklistGoal cg in checklistgoals)
                    {
                        Console.WriteLine($"{counter}: [{cg.GetCurrentCompletion()}/{cg.GetMaxCompetion()}] {cg.GetGoalName()}");
                        counter++;
                    }

                    Console.WriteLine($"{counter}: Quit");

                    Console.WriteLine($"\nPoints: {current_points}");


                    choice2 = Console.ReadLine();

                    if (int.TryParse(choice2, out int choice2num))
                    {   
                        if (choice2num < counter)
                        {
                            if (choice2num <= simplegoals.Count())
                            {
                                if (simplegoals[choice2num -1].GetGoalStatus())
                                {
                                    Console.WriteLine("Goal has already been completed.");
                                }
                                else
                                {
                                    current_points += simplegoals[choice2num -1].FinishGoal();
                                }
                            }
                            else if (choice2num <= (simplegoals.Count() + eternalgoals.Count()))
                            {
                                choice2num -= simplegoals.Count();
                                current_points += eternalgoals[choice2num -1].FinishGoal();
                            }
                            else
                            {
                                choice2num -= simplegoals.Count();
                                choice2num -= eternalgoals.Count();

                                if (checklistgoals[choice2num -1].GetGoalStatus())
                                {
                                    Console.WriteLine("Goal has already been completed.");
                                }
                                else
                                {
                                    current_points += checklistgoals[choice2num -1].FinishGoal();
                                }
                            }
                        }
                        else if (choice2num == counter)
                        {
                            choice2 = "quit";
                        }
                        else
                        {
                            Console.WriteLine("\n Which goal do you wish to check off?");
                            choice2 = Console.ReadLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("\n Which goal do you wish to check off?");
                        choice2 = Console.ReadLine();
                    } 
                }


            }
            else if (choice == "5")
            {
                Fileloader.filesaver(simplegoals,eternalgoals,checklistgoals,current_points);
            }
            else if (choice == "6")
            {

                string type = "";
                string name = "";

                int pointvalue = 0;

                bool goalstatus = false;

                int bonuspoints = 0;
                int currentcompletion = 0;
                int maxcompletion = 0;

                string[] lines = Fileloader.fileloadera();

                foreach (string line in lines)
                {
                    string[] parts = line.Split(",");
                    int counter = 0;

                    if (parts.Count() == 2)
                    {
                        current_points = int.Parse(parts[counter]);
                    }
                    else
                    {
                        while (counter < parts.Count())
                        {
                            if (counter == 0)
                            {
                                type = parts[counter];
                            }
                            else if (counter == 1)
                            {
                                name = parts[counter];
                            }
                            else if (counter == 2)
                            {
                                pointvalue = int.Parse(parts[counter]);
                            }
                            else if (counter == 3)
                            {
                                goalstatus = bool.Parse(parts[counter]);
                            }
                            else if (counter == 4)
                            {
                                bonuspoints = int.Parse(parts[counter]);
                            }
                            else if (counter == 5)
                            {
                                currentcompletion = int.Parse(parts[counter]);
                            }
                            else if (counter == 6)
                            {
                                maxcompletion = int.Parse(parts[counter]);
                            }
                            counter++;
                        }
    
                        if (type == "Simple Goal")
                        {
                            SimpleGoal SG = new SimpleGoal(name,pointvalue);
                            SG.UpdateGoalStatus(goalstatus);
    
                            simplegoals.Add(SG);
                        }
                        else if (type == "Eternal Goal")
                        {
                            EternalGoal EG = new EternalGoal();
                            EG.UpdateGoalName(name);
                            EG.UpdatePointValue(pointvalue);
                            EG.UpdateCounter(bonuspoints);
    
                            eternalgoals.Add(EG);
                        }
                        else
                        {
                            ChecklistGoal CG = new ChecklistGoal(maxcompletion, bonuspoints);
                            CG.UpdateGoalName(name);
                            CG.UpdatePointValue(pointvalue);
                            CG.UpdateCurrentCompletion(currentcompletion);
                            CG.UpdateGoalStatus(goalstatus);
    
                            checklistgoals.Add(CG);
                        }
 
                    }

                }
            }

        }while (choice != "7");
        

    }
}