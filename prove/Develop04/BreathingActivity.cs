using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

public class BreathingActivity :  Activity{

    public BreathingActivity(int duration = 7) : base("Breathing", "Take a measured time to slow your breathing and relax.", duration){
        
    }

    public void Run(){
        if(_duration % 10 != 0){
            _duration += 10 - (_duration % 10);
            Console.WriteLine($"This activity uses intervals of 10 seconds, rounding up to {_duration}");
        }
        Console.Write("Beginning in  ");
        Countdown(5);
        Console.WriteLine();
        for(int i = 0; i < _duration; i+=10){
            Console.WriteLine("[  Breathe In   ]");
            Countdown(5);
            Console.WriteLine("  [Breathe Out]");
            Countdown(5);
        }
        EndActivity();
    }

}