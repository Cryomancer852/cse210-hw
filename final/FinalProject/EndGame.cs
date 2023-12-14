using System;


class EndGame : Activity{
    
    private bool _isWeekly;
    private bool _completedWeekly;
    private bool _exoticObtained; //That is a capital o, not a 0


    public EndGame(int min, int eff, int size, bool weekly) : base(min, eff, size){
        _isWeekly = weekly;
        _completedWeekly = false;
        _exoticObtained = false;
    }

    public void runComplete(bool exotic){
        _exoticObtained = exotic;
        _completedWeekly = true;
    }



    public override bool isReady(int power)
    {
        if(power > 1750){
            return true;
        }else{
            return false;
        }
    }

    public override bool isWorth()
    {
        if(!_exoticObtained && _isWeekly){
            return true;
        }else if(!_isWeekly && _completedWeekly){
            return false;
        }else {
            return true;
        }
    }




}