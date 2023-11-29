using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction test = new Fraction();
        
        Console.WriteLine("Innitialize");
        Console.WriteLine($"  {test.GetNumerator()}, {test.GetDenominator()}");
        

        test.WholeToFraction(5);

        Console.WriteLine("Whole to Fraction");
        Console.WriteLine($"  {test.GetNumerator()}, {test.GetDenominator()}");
        
        
        test.SetFraction(3,2);

        Console.WriteLine("Set whole Fraction");
        Console.WriteLine($"  {test.GetNumerator()}, {test.GetDenominator()}");
        
        
        test.SetNumerator(9);

        Console.WriteLine("Just Numerator");
        Console.WriteLine($"  {test.GetNumerator()}, {test.GetDenominator()}");
        
        
        test.SetDenominator(7);

        Console.WriteLine("Just Denominator");
        Console.WriteLine($"  {test.GetNumerator()}, {test.GetDenominator()}");

        Console.WriteLine("To String");
        Console.WriteLine($"  {test.ToString()}");

        Console.WriteLine("Float");
        Console.WriteLine(test.ToFloat());

    }
}