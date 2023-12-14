using System;

class GameClass{
    
    private string _name;
    private string _element;
    private int _difficulty;


    public GameClass(string name, string element){
        _name = name;
        _element = element;
        _difficulty = calculateDifficulty();
    }

    private int calculateDifficulty(){
        return 0; //Use logic and calculate difficulty
    }


    public string getClass(){
        return $"{_element} {_name}";
    }

    public int getDifficulty(){
        return _difficulty;
    }
}