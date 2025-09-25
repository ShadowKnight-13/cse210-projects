using System;
using System.Diagnostics;
using System.Formats.Asn1;

class Program
{
    static void Main(string[] args)
    {

        bool playAgain = false;

        do
        {
            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 100);
            int numberGuess = 0;
            int guessCounter = 0;

            do
            {
                Console.WriteLine("What is your guess? ");
                string numberGuessInput = Console.ReadLine();
                numberGuess = int.Parse(numberGuessInput);
                guessCounter++;

                if (magicNumber > numberGuess)
                { Console.WriteLine("Higher"); }
                else if (magicNumber < numberGuess)
                {
                    Console.WriteLine("Lower");
                }
            } while (magicNumber != numberGuess);

            Console.WriteLine($"You guessed it! The Magic Number was {magicNumber}! It took you {guessCounter} guesses.");
            Console.WriteLine("\nDo you want to play again?");
            string playAgainInput = Console.ReadLine();

            if (playAgainInput == "Y" || playAgainInput == "Yes" || playAgainInput == "YES" || playAgainInput == "y" || playAgainInput == "yes")
            {
                playAgain = true;
            }
            else { playAgain = false; }

        } while (playAgain);
        

    }
}