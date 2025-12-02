using System;

public class DiceRoller
{
    private Random _rng = new Random();

    public DiceRoller(){}

    public int RollDice(int dice, int modifier=0, int numberOfDice=1)
    {
        if (dice <= 0)
        {
            Console.WriteLine("Dice sides must be positive");

            bool valid = false;
            while (!valid)
            {
                if (int.TryParse(Console.ReadLine(),out dice)) { valid = true; }
                else { Console.WriteLine("Invaild Input, Please Try again."); }
            }
        
        }
        if (numberOfDice <= 0)
        {
            Console.WriteLine("Number of dice must be positive");

            bool valid = false;
            while (!valid)
            {
                if (int.TryParse(Console.ReadLine(),out numberOfDice)) { valid = true; }
                else { Console.WriteLine("Invaild Input, Please Try again."); }
            }

        }

        int total = modifier;
        for (int i = 0; i < numberOfDice; i++)
        {
            total += _rng.Next(1, dice + 1);
        }
        return total;
    }
}