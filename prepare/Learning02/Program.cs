using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();

        job1._jobTitle = "Software Engineer";
        job1._company = "Apple";
        job1._startYear = 2003;
        job1._endYear = 2023;

        Job job2 = new Job();

        job2._jobTitle = "AI Engineer";
        job2._company = "Open AI";
        job2._startYear = 2023;
        job2._endYear = 2027;

        //job1.Display();
        //job2.Display();

        Resume resume1 = new Resume();
        resume1._name = "Bob Ross";
        resume1._jobs = [job1, job2];

        resume1.Display();
    }
}