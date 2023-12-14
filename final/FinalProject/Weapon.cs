using System;



class Weapon : Gear{

    private string _element;

    private int _weight;
    private int _slot;

    public Weapon(string name, int power, int rarity, string element, int weight, int slot) : base (name, power, rarity){
        _element = element;
        _weight = weight;
        _slot = slot;
    }

    public override void newGear()
    {
        Random rng = new Random();
        if(_power < 1750){
            _power += rng.Next(4,16); //Power increases quickly up until 1750
        }else if(_power < 1800){
            _power += 1;              //Power slows a bit as the player nears the maximum
        }else if(_power < 1810 && rng.Next(0,8) == 0){
            _power += 1;              //The final 10 levels can take weeks
        }

        if(_power > 1650 && _rarity == 0){
            _rarity += 1; // White -> Green
        }else if(_power > 1680 && _rarity == 1){
            _rarity += 1; // Green -> Blue
        }else if(_power > 1750 && _rarity == 2){
            _rarity += 1; //Blue -> Purple
        }
    }

    public override string getDescription()
    {
        string a = "";
        if(_weight == 0){
            a = "Primary";
        }else if(_weight == 1){
            a = "Special";
        }else{
            a = "Heavy";
        }
        return $" {_name}: {_power} | {_element} {a} Weapon";
    }
}









