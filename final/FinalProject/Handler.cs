using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;


class Handler{

    public Handler(){}

    public void MenuLoop(Guardian bob){

        List<Activity> _modes = new List<Activity>(){
            new Ritual(1600, 1600, 3, 0, 0),
            new Ritual(1600, 1600, 3, 0, 0),
            new Ritual(1600, 1600, 3, 0, 0),
            new EndGame(1750, 1810, 3, false),
            new EndGame(1750, 1810, 6, false),
            new EndGame(1800, 1810, 3, true),
            new EndGame(1800, 1810, 8, true),
        };



        string loop = "";
        string subInput = "";
        while(loop != "3"){
            Console.WriteLine("What would you like to do?\n 1. Check Guardian\n 2. Check Activities\n 3. Quit");
            loop = Console.ReadLine();
            Console.Clear();

            if(int.TryParse(loop,out int input)){
                if(input == 1){
                    Console.WriteLine("What would you like to check about your Guardian?\n 1. Power Level\n 2. Stats\n 3. Gear");
                    subInput = Console.ReadLine();
                    Console.Clear();

                    if(int.Parse(subInput) == 1){
                        Console.WriteLine($"  Power: {bob.getPower()}");
                    }else if(int.Parse(subInput) == 2){
                        bob.getStats();
                    }else if(int.Parse(subInput) == 3){
                        bob.getGear();
                    }
                    // what would you like to check?
                }else if(input == 2){
                    Console.WriteLine("Which would you like to check?\n 1. Ritual Activities\n 2. End Game Activities\n 3. PvP Activities");
                    subInput = Console.ReadLine();
                    Console.Clear();
                    if(int.Parse(subInput) == 1){
                        int intI = 1;
                        foreach(Activity i in _modes){
                            if(i.GetType() == _modes[0].GetType()){
                            Console.WriteLine($"{intI}. Ready: True | Worth: {i.isWorth()}");
                            intI++;
                        }}
                    }else if(int.Parse(subInput) == 2){
                        int intI = 1;
                        foreach(Activity i in _modes){
                            if(i.GetType() == _modes[3].GetType()){
                            Console.WriteLine($"{intI}. Ready: {i.isReady(bob.getPower())} | Worth: {i.isWorth()}");
                            intI++;
                        }}
                    }else if(int.Parse(subInput) == 3){
                        Console.WriteLine("You will never be ready, nor will it ever be worth it.");
                    }

                    // what activity would you like to check Ritual, EndGame, PVP
                }
            }
            Console.WriteLine();
        }

    }
}