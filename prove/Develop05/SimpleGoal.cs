using System;

public class SimpleGoal : Goal{

    private bool _complete;

    public SimpleGoal(string name, string desc, int points, bool done = false) : base(name, desc, points){
        _complete = done;
    }

    public override bool IsComplete()
    {
        return _complete;
    }

    public override string ToString()
    {
        if(_complete){
            return $"[X]{_name}: {_task} [{_points}]";
        }else{
            return $"[ ]{_name}: {_task} [{_points}]";
        }
    }

    public override string GetSaveFormat()
    {
        return $"simple,{_name},{_task},{_points},{_complete}";
    }

    public override void RecordEvent()
    {
        _complete = true;
        Console.WriteLine($"Completed {_name} for {_points} points");
    }
}