using System;

class Guardian{
    
    protected GameClass _class; //temp
    protected List<Gear> _equipment = new List<Gear>();
    protected int _powerLevel;
    protected List<int> _stats = new List<int>() {0, 0, 0, 0, 0, 0};

    public Guardian(string roleClass = "Warlock", string element = "Void"){
        // Class
        _class = new GameClass(roleClass, element);
        // Starter Weapons
        _equipment.Add(new Weapon("Khvostov",1600, 0, "Kinetic", 0, 1));
        _equipment.Add(new Weapon("Stubborn Oak",1600, 0, "Solar", 1, 2));
        _equipment.Add(new Weapon("Butler RS/2",1600, 0, "Arc", 2, 3));
        // Starter Armor
        _equipment.Add(new Armor("Ruined Helm", 1600, 0, 0, 1));
        _equipment.Add(new Armor("Ruined Robes", 1600, 0, 1, 1));
        _equipment.Add(new Armor("Ruined Gloves", 1600, 0, 2, 1));
        _equipment.Add(new Armor("Ruined Boots", 1600, 0, 3, 1));
        _equipment.Add(new Armor("Ruined Bond", 1600, 0, 4, 1));
        
        totalPower();
        sumStats();
    }


    public void totalPower(){
        int power = 0;
        foreach(Gear i in _equipment){
            power += i.getPower();
        }
        power /= 8;
        _powerLevel = power;
    }

    public int getPower(){
        totalPower(); // Make certain it's up to date
        return _powerLevel;
    }

    public void randomDrop(){
        Random rng = new Random();
        _equipment[rng.Next(0,_equipment.Count)].newGear();
    }

    public void sumStats(){
        List<int> tempStats = new List<int>(){0, 0, 0, 0, 0, 0};
        foreach(Gear i in _equipment){
            List<int> gearStat = i.GetStats();
            for(int x = 0; x < 6; x++){
                tempStats[x] += gearStat[x];
            }
        }
        _stats = tempStats;
    }

    public void getStats(){
        Console.WriteLine($"   Mobility: {_stats[0]}");
        Console.WriteLine($" Resilience: {_stats[1]}");
        Console.WriteLine($"   Recovery: {_stats[2]}");
        Console.WriteLine($" Discipline: {_stats[3]}");
        Console.WriteLine($"   Intelect: {_stats[4]}");
        Console.WriteLine($"   Strength: {_stats[5]}");
        
    }

    public void getGear(){
        foreach(Gear i in _equipment){
            Console.WriteLine(i.getDescription());
        }
    }
}