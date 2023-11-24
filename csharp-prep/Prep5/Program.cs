using System;

class Program
{
    static void welcome(){
        Console.WriteLine("Welcome to the program.");
    }

    static string promptUsername(){
        Console.Write("Enter your name: ");
        return Console.ReadLine();
    }

    static int favNumber(){
        Console.Write("Enter your favorite number: ");
        return int.Parse(Console.ReadLine());
    }

    static int square(int factor){
        return factor * factor;
    }

    static void displayResult(string name, int square){
        Console.WriteLine($"{name} your favorite number squared is {square}.");
    }

    static void Main(string[] args)
    {
        welcome();
        string name = promptUsername();
        int num = favNumber();
        int sqr = square(num);
        displayResult(name,sqr);
    }
}