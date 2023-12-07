using System;
using System.Diagnostics;
// using System.Buffers;
// using System.IO;


public class Activity{

    private string _kind;

    private string _description;
    protected int _duration;
    
    public Activity(string kind, string text, int time){
        _kind = kind;
        _description = text;
        _duration = time;
    }

    public void Begin(){
        Console.Clear();
        Console.WriteLine($"Beginning {_kind} Activity\n");
        Console.WriteLine($"{_description}\n");
        if(_kind == "Reflection"){
            Console.Write("How many questions would you like to ponder? ");
        }else{
            Console.Write("How long would you like to do this activity? ");
        }
        _duration = int.Parse(Console.ReadLine());
        Animate(5);
        
    }

    public void EndActivity(){
        Console.WriteLine($"Completed {_kind} Activity, would you like to continue?");
        Console.Write("Press Enter to return to the program...");
        Console.ReadLine();
        Console.Clear();
    }

    public void Countdown(int duration){
        for(int i = duration; i > 0; i--){
            Console.Write($"\b{i}");
            Thread.Sleep(1000);
        }
        Console.Write("\b"); //remove the remaining 1
    }
    public void Animate(int duration){   
        for(int i = 0; i < duration; i++){
            Console.Write("\b-");
            Thread.Sleep(250);
            Console.Write("\b\\");
            Thread.Sleep(250);
            Console.Write("\b|");
            Thread.Sleep(250);
            Console.Write("\b/");
            Thread.Sleep(250);
            Console.Write("\b-");
        }
        Console.Write("\b");
        
        
    }



}


