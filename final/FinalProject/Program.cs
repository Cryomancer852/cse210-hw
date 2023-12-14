using System;
using System.ComponentModel.Design;

class Program
{
    
    static void Main(string[] args)
    {
        Guardian bob = new Guardian();
        Console.WriteLine(bob.getPower());

            Console.Clear();
        Handler game = new Handler();

        game.MenuLoop(bob);
    }
}