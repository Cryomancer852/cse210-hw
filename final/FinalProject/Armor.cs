using System;



class Armor : Gear{

    private List<int> _stats = new List<int>();

    private int _slot;

    public Armor(string name, int power, int rarity,int slot, int focus) : base(name, power, rarity){
        _slot = slot;
        if(_slot != 5){
            rollStats(focus);
        }
    }


    public void rollStats(int focus = 5){ //stat 5 is one that is always useful.
        Random rng = new Random();

        if(_rarity < 2){ //stats are all 6s with two 10s for the bottom two rarities
            _stats = new List<int>() {6,6,6,6,6,6};
            _stats[rng.Next(0,6)] += 4;
            _stats[rng.Next(0,6)] += 4;
        }else if(_rarity == 2){ //two 6s, two 10s, two 12s
            List<int> blue = new List<int>() {6, 6, 10, 10, 12, 12};
            for(int i = 0; i < 6; i++){
                int stat = rng.Next(0,blue.Count());
                _stats[i] = blue[stat];
            }
        }else{ //top two rarities have large stat ranges, only these use focus
            _stats = new List<int>() {2,2,2,2,2,2}; //12 points used to get minimum stats
            _stats[focus] += 10; // Focus gives +10 to a given stat

            int total = rng.Next(48, 70) - 22; // Account for the 22 points already alotted
            for(int i = 0; i < 6; i++){
                int iStat = rng.Next(0,total/3);
                total -= iStat;
                _stats[i] += iStat;
            }
            if(total != 0){
                _stats[focus] += total;
            }
        }

    }

    public override List<int> GetStats(){
        return _stats;
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
            rollStats();
        }else if(_power > 1750 && _rarity == 2){
            _rarity += 1; //Blue -> Purple
            rollStats();
        }
    }

    public override string getDescription()
    {
        return $" {_name}: {_power} | {_stats.Sum()} Total Stats";
    }
}