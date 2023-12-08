using System;

public class EternalGoal : Goal{

    private bool _complete;

    private int _timesCompleted;

    public EternalGoal(string name, string desc, int points, bool done = false, int times = 0) : base(name, desc, points){
        _complete = done;
        _timesCompleted = times;
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string ToString()
    {
        
        return $"[ ]{_name}: {_task} [{_points}x{_timesCompleted}]";
    }
    public override string GetSaveFormat()
    {
        return $"eternal,{_name},{_task},{_points},{_complete},{_timesCompleted}";
    }

    public override void RecordEvent()
    {
        Console.WriteLine($"Completed {_name} for {_points} points");
    }
}