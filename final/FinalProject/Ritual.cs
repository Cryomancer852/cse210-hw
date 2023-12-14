using System;

class Ritual : Activity{

    private int _completions;
    private int _bountyProgress;



    public Ritual(int min, int eff, int size, int comp, int bounty) : base(min, eff, size){
        _completions = comp;
        _bountyProgress = bounty;
    }
    public void progressBounty(int x){
        _bountyProgress += x;
    }

    public void logCompletions(int x){
        _completions += x;
    }


    public override bool isReady(int power)
    {
        return true; //Ritual Activities are designed for the player to hop into whenever they feel like it
    }

    public override bool isWorth()
    {
        if(_completions > 9 && _bountyProgress > 8){
            Console.WriteLine("Do you have a Quest for an Exotic Cipher or Exotic Catalyst?");
            string worth = Console.ReadLine();
            if(worth.ToLower().StartsWith('y')){
                return true;
            }else{
                return false;
            }
        }else if(_bountyProgress < 8){
            Console.WriteLine("Make sure to gather Bounties first!");
            return true;
        }else if(_completions < 9){
            return true;
        }else{
            return false;
        }
    }
}