using System;


public abstract class Activity{
    protected int _minimumReq;
    protected int _effectiveCap;
    protected int _teamSize;


    public Activity(int min, int eff, int size){
        _minimumReq = min;
        _effectiveCap = eff;
        _teamSize = size;
    }

    public abstract bool isReady(int power);

    public abstract bool isWorth();
}