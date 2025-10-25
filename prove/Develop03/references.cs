using System;
using System.Runtime.CompilerServices;

public class Reference
{
    private string _book;
    private int _chapter;
    private int _startVerse;
    private int _endVerse;

    public void GetReferenceFromUser()
    {
        string input = "";
        do
        {
            Console.WriteLine("Does Your reference contain more than 1 verse? (Y/N)");
            input = Console.ReadLine().ToUpper();
            try { Console.Clear(); } catch (IOException) { Console.WriteLine("Console.Clear() failed."); }
        } while (input != "Y" & input != "N");

        bool input1;
        do
        {
            Console.WriteLine("Please enter the Book that the scripture reference is in. (Example: John)");
            input1 = UpdateBook(Console.ReadLine());
            try { Console.Clear(); } catch (IOException) { Console.WriteLine("Console.Clear() failed."); }
        } while (input1 != true);

        bool input2;
        do
        {
            Console.WriteLine("Please Enter the Chapter of the scripture reference.");
            input2 = UpdateChapter(Console.ReadLine());
            try { Console.Clear(); } catch (IOException) { Console.WriteLine("Console.Clear() failed."); }
        } while (input2 != true);

        bool input3;
        do
        {
            if (input == "Y")
            {
                Console.WriteLine("Please Enter the number of the starting verse of the scripture reference.");
            }
            else
            {
                Console.WriteLine("Please Enter the number of the verse of the scripture reference.");
            }

            input3 = UpdateStartVerse(Console.ReadLine());
            try { Console.Clear(); } catch (IOException) { Console.WriteLine("Console.Clear() failed."); }
        } while (input3 != true);

        bool input4;
        if (input == "Y")
        {
            do
            {
                Console.WriteLine("Please Enter the number of the ending verse of the scripture reference.");
                input4 = UpdateEndVerse(Console.ReadLine());
                try { Console.Clear(); } catch (IOException) { Console.WriteLine("Console.Clear() failed."); }
            } while (input4 != true);
        }


    }

    private bool UpdateBook(string book)
    {
        if (string.IsNullOrWhiteSpace(book))
        {
            return false;
        }
        _book = book;
        return true;
    }

    private bool UpdateChapter(string chapter)
    {
        if (string.IsNullOrWhiteSpace(chapter))
        {
            return false;
        }
        if (int.TryParse(chapter, out _chapter))
        {
            return true;
        }
        return false;
    }

    private bool UpdateStartVerse(string startverse)
    {
        if (string.IsNullOrWhiteSpace(startverse))
        {
            return false;
        }
        if (int.TryParse(startverse, out _startVerse))
        {
            return true;
        }
        return false;
    }

    private bool UpdateEndVerse(string endverse)
    {
        if (string.IsNullOrWhiteSpace(endverse))
        {
            return false;
        }
        if (int.TryParse(endverse, out _endVerse))
        {
            return true;
        }
        return false;
    }

    public string GetBook()
    {
        return _book;
    }

    public int GetChapter()
    {
        return _chapter;
    }

    public int GetStartVerse()
    {
        return _startVerse;
    }

    public int GetEndVerse()
    {
        return _endVerse;
    }

    public void DisplayReference()
    {
        if (_endVerse == 0)
        {
            Console.WriteLine($"{_book} {_chapter}:{_startVerse}");
        }
        else
        {
           Console.WriteLine($"{_book} {_chapter}:{_startVerse}-{_endVerse}"); 
        }
        
    }
}