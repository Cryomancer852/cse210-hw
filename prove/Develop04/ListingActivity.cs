using System;
using System.Diagnostics;
using System.Collections.Generic;


public class ListingActivity : Activity{


    public int _count;

    private List<string> _prompts = new List<string>();

    public ListingActivity(int time = 30) : base("Listing", "List things you are grateful for, to open yourself to personal reflection.", time){
        _count = 0;
        _prompts.AddRange(new List<string> {"Who are people that you appreciate?", "What are personal strengths of yours?", "Who are people that you have helped this week?", "When have you felt the Holy Ghost this month?", "Who are some of your personal heroes?"});

    }

    public void GetRandomPrompt(){
        Random rng = new Random();
        int a = rng.Next(0, _prompts.Count());
        Console.WriteLine($"{_prompts[a]}\n");
    }

    public void GetListFromUser(){
        Console.Write("Press Enter when ready to begin...");
        Console.ReadLine();
        DateTime start = DateTime.Now;
        DateTime end = start.AddSeconds(_duration);
        while(start < end){
            Console.Write(">");
            Console.ReadLine();
            start = DateTime.Now;
            _count++;
        }
        Console.WriteLine($"You submitted {_count} answers");
    }

    public void Run(){
        GetRandomPrompt();
        GetListFromUser();
        EndActivity();
    }

}