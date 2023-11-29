using System;

class Program
{
    static void Main(string[] args)
    {
        MathAssignment math = new MathAssignment("Scott Doyle", "Exponents", "17", "1-12");
        Console.WriteLine($"{math.GetFullSummary()}\n");

        WritingAssignment essay = new WritingAssignment("Scott Doyle", "Teaching", "Goal Setting and Discipline");
        Console.WriteLine(essay.GetSummary());
        Console.WriteLine(essay.GetWritingInformation());
    }
}