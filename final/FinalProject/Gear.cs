using System;
using System.Runtime.CompilerServices;

abstract class Gear{
    
    protected int _power; 
    protected string _name;
    protected int _rarity;
    

    public Gear(string name, int power, int rarity){
        _name = name;
        _power = power;
        _rarity = rarity;
    }

    public int getPower(){
        return _power;
    }

    public abstract void newGear();

    public virtual List<int> GetStats(){
        return new List<int>() {0,0,0,0,0,0};
    }

    public abstract string getDescription();

}




