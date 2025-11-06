using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        ;
        string menuChoice = "";
        do
        {
            Activity activity = new Activity("", "");
            activity.DisplayAnimation(1);

            try { Console.Clear(); } catch (IOException) { Console.WriteLine("Console.Clear() failed."); }
            menuChoice = DisplayMenu();

        } while (menuChoice != "4");
    }

    static string DisplayMenu()
    {
        string menuchoice = "";
        Console.WriteLine("Welcome to the mindfulness program!");
        Console.WriteLine("Please select one of the following activities:");
        Console.WriteLine("1. Breathing Activity");
        Console.WriteLine("2. Reflection Activity");
        Console.WriteLine("3. Listing Activity");
        Console.WriteLine("4. Quit");

        menuchoice = Console.ReadLine();
        while (menuchoice != "1" && menuchoice != "2" && menuchoice != "3" && menuchoice != "4")
        {
            Console.WriteLine("Invalid choice. Please select a valid option.");
            Console.ReadLine();
        }

        if (menuchoice == "1")
        {
            Breathing_Activity breathingActivity = new Breathing_Activity();
            breathingActivity.exucute_breathing_activity();
        }
        else if (menuchoice == "2")
        {
            Reflection_Activity reflectionActivity = new Reflection_Activity();
            reflectionActivity.ExacuteRefelctionActivity();
        }
        else if (menuchoice == "3")
        {
            Listing_Activity listingActivity = new Listing_Activity();
            listingActivity.ExecuteListingActivity();
        }

        return menuchoice;
    }
}