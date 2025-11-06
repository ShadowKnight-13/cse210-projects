using System;
using System.Formats.Asn1;

public class Breathing_Activity : Activity
{
    private int _breath_in_lenght;
    private int _breath_out_lenght;
    private int _number_of_breaths;

    public Breathing_Activity(int breath_in_lenght = 0, int breath_out_lenght = 0, int number_of_breaths = 0) : base("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
        _breath_in_lenght = breath_in_lenght;
        _breath_out_lenght = breath_out_lenght;
        _number_of_breaths = number_of_breaths;
    }

    public void calculate_number_of_breaths(int duration)
    {
        int total_breath_length = _breath_in_lenght + _breath_out_lenght;
        _number_of_breaths = duration / total_breath_length;
    }

    public void calculate_breath_lengths(int duration)
    {
        List<int> prime_numbers = new List<int>() { 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71,
        73, 79, 83, 89, 97, 101, 103, 107, 109, 113, 127, 131, 137, 139, 149, 151, 157, 163, 167, 173, 179, 181, 191, 193, 197,
        199, 211, 223, 227, 229, 233, 239, 241, 251, 257, 263, 269, 271, 277, 281, 283, 293, 307, 311, 313, 317, 331, 337, 347,
        349, 353, 359, 367, 373, 379, 383, 389, 397, 401, 409, 419, 421, 431, 433, 439, 443, 449, 457, 461, 463, 467, 479, 487,
        491, 499, 503, 509, 521, 523, 541, 547, 557, 563, 569, 571, 577, 587, 593, 599, 601, 607, 613, 617, 619, 631, 641, 643,
        647, 653, 659, 661, 673, 677, 683, 691, 701, 709, 719, 727, 733, 739, 743, 751, 757, 761, 769, 773, 787, 797, 809, 811,
        821, 823, 827, 829, 839, 853, 857, 859, 863, 877, 881, 883, 887, 907, 911, 919, 929, 937, 941, 947, 953, 967, 971, 977,
        983, 991, 997
        };

        foreach (int i in prime_numbers)
        {
            if (duration == i)
            {
                duration++;
                break;
            }
        }

        if (duration % 9 == 0)
        {
            _breath_in_lenght = 4;
            _breath_out_lenght = 5;
        }
        else if (duration % 8 == 0)
        {
            _breath_in_lenght = 3;
            _breath_out_lenght = 5;
        }
        else if (duration % 7 == 0)
        {
            _breath_in_lenght = 3;
            _breath_out_lenght = 4;
        }
        else if (duration % 6 == 0)
        {
            _breath_in_lenght = 2;
            _breath_out_lenght = 4;
        }
        else if (duration % 5 == 0)
        {
            _breath_in_lenght = 2;
            _breath_out_lenght = 3;
        }
        else if (duration % 4 == 0)
        {
            _breath_in_lenght = 2;
            _breath_out_lenght = 2;
        }
        else if (duration % 3 == 0)
        {
            _breath_in_lenght = 1;
            _breath_out_lenght = 2;
        }
        else if (duration % 2 == 0)
        {
            if (duration >= 10)
            {
                _breath_in_lenght = 4;
                _breath_out_lenght = 6;
            }
            else if (duration >= 8)
            {
                _breath_in_lenght = 3;
                _breath_out_lenght = 5;
            }
            else if (duration >= 6)
            {
                _breath_in_lenght = 3;
                _breath_out_lenght = 3;
            }
            else if (duration >= 4)
            {
                _breath_in_lenght = 2;
                _breath_out_lenght = 2;
            }
            else
            {
                _breath_in_lenght = 1;
                _breath_out_lenght = 1;
            }
            
        }
    }

    public void exucute_breathing_activity()
    {
        DisplayStartingMessage();
        calculate_breath_lengths(GetDuration());
        calculate_number_of_breaths(GetDuration());

        for (int i = 0; i < _number_of_breaths; i++)
        {
            DisplayAnimation(_breath_in_lenght, "Breathe in");
            DisplayAnimation(_breath_out_lenght, "Breathe in \nBreathe out");
        }

        DisplayEndingMessage();
    }

}