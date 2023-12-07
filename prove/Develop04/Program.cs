using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        string response = "1";
        Console.WriteLine("Welcome to the Mindfulness Program!");
        while(response.ToLower() != "4"){
            Console.WriteLine("Select an option:");
            Console.Write("  1. Breathing Activity\n  2. Reflection Activity\n  3. Listing Activity\n  4. Quit\n");
            response = Console.ReadLine();
            if(response == "1"){
                BreathingActivity act = new BreathingActivity();
                act.Begin();
                act.Run();
            }else if (response == "2"){
                ReflectionActivity act = new ReflectionActivity();
                act.Begin();
                act.Run();
            }else if(response == "3"){
                ListingActivity act = new ListingActivity();
                act.Begin();
                act.Run();
            }else{
                break;
            }
            Console.Clear();
        }


    }
}