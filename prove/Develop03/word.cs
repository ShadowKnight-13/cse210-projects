using System;
using System.ComponentModel;

public class Word
{
    private string _word = " ";
    private bool _isBlank = false;



    public Word(string text)
    {
        UpdateWord(text);
    }



    public bool UpdateWord(string word)
    {
        if (string.IsNullOrWhiteSpace(word))
        {
            return false;
        }
        _word = word;
        return true;
    }



    public void Hide()
    {
        _isBlank = true;
    }

    public void UnHide()
    {
        _isBlank = false;
    }

    public bool IsHidden()
    {
        return _isBlank;
    }



    public void DisplayWord()
    {
        if (_isBlank)
        {
            foreach (char letter in _word)
            {
                Console.Write("_");
            }
        }
        else
        {
            Console.Write(_word);
        }
    }

}