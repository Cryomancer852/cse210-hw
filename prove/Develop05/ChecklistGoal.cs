using System;

public class ChecklistGoal : Goal{

    private bool _complete;
    private int _target;
    private int _current;
    private int _bonus;

    public ChecklistGoal(string name, string desc, int points, int target, int completionBonus, bool done = false, int times = 0) : base(name, desc, points){
        _complete = done;
        _target = target;
        _current = times;
        _bonus = completionBonus;
    }

    public override bool IsComplete()
    {
        return _complete;
    }

    public override string ToString()
    {
        if(_complete){
        return $"[X]{_name}: {_task} [{_bonus + _points * _current}] -{_current}/{_target}";
        }else{
            return $"[ ]{_name}: {_task} [{_points * _current}] -{_current}/{_target}";
        }
    }
    public override string GetSaveFormat()
    {
        return $"checklist,{_name},{_task},{_points},{_complete},{_target},{_current},{_bonus}";
    }

    public override void RecordEvent()
    {
        _current++;
        _complete = _current >= _target;
        if(_complete){
            Console.WriteLine($"Comepleted {_name} for {_bonus} points");
        }else{
            Console.WriteLine($"Progressed {_name} for {_points} points");
        }
    }

    public override int GetPoints()
    {
        if(_complete){
            return _bonus;
        }else{
            return _points;
        }
    }
}