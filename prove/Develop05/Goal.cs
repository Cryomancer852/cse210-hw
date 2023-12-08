using System;

public abstract class Goal{
    protected string _name;
    protected string _task;
    protected int _points;

    public Goal(string name, string task, int point){
        _name = name;
        _task = task;
        _points = point;
    }

    public abstract void RecordEvent();
    public abstract bool IsComplete();
    //public abstract string ToString(); It's a lot simpler to just use ToString
    public string GetDetails(){
        return _task;
    }
    public virtual int GetPoints(){
        return _points;
    }

    public abstract string GetSaveFormat();
}