using System;
using System.Xml;

public class GoalManager{
    private List<Goal> _goals = new List<Goal>();
    private int _score;

    public GoalManager(){
        _score = 0;
    }

    public void Start(){
        string response = "";
        while(response != "6"){

            Console.WriteLine($"Menu Selection - Points:{_score}\n  1. Create New Goal\n  2. List Goals\n  3. Save Goals\n  4. Load Goals\n  5. Complete a Goal\n  6. Quit\n");
            Console.Write("Select an option from the menu: ");
            response = Console.ReadLine();

            if(response == "1"){
                Console.Write("\n1. Simple Goal\n2. Eternal Goal\n3.Checklist Goal\nWhat kind of Goal would you like to create: ");
                string newGoal = Console.ReadLine();
                _goals.Add(CreateGoal(int.Parse(newGoal)));
                Console.Clear();
            }else if(response == "2"){
                Console.WriteLine();
                foreach(Goal i in _goals){
                    Console.WriteLine(i.ToString());
                }
                Console.WriteLine();
            }else if(response == "3"){
                SaveFile();
                Console.Clear();
            }else if(response == "4"){
                LoadFile();
                Console.Clear();
            }else if(response == "5"){
                Console.Clear();
                Console.WriteLine("Select a goal to complete:");
                foreach(Goal i in _goals){
                    Console.WriteLine($"{_goals.IndexOf(i) + 1}. {i.ToString()}");
                }
                int target = int.Parse(Console.ReadLine()) - 1;
                _goals[target].RecordEvent();
                _score += _goals[target].GetPoints();
                Console.Clear();
            }



        }
    }

/*
Reference for file save formatting:
12345
simple,{_name},{_task},{_points},{_complete}
eternal,{_name},{_task},{_points},{_complete},{_timesCompleted}
checklist,{_name},{_task},{_points},{_complete},{_target},{_current},{_bonus}


*/
    public void LoadFile(){
        
        Console.Write("Please enter your name: ");
        string file = Console.ReadLine().ToLower();
        if(!File.Exists($"{file}.txt")){ //Reusing code from Develop 2
            Console.WriteLine("No previous data found, creating new file.");
            using(StreamWriter newJ = File.CreateText($"{file}.txt")){} 
        }

        string[] lines = System.IO.File.ReadAllLines($"{file}.txt"); 

        foreach(string line in lines){
            if(line == lines[0]){
                _score = int.Parse(line);
            }else{
            string[] parts = line.Split(",");
            if(parts[0] == "simple"){
                SimpleGoal newSimple = new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]), bool.Parse(parts[4]));
                _goals.Add(newSimple);
            }else if(parts[0] == "eternal"){
                EternalGoal newEternal = new EternalGoal(parts[1], parts[2], int.Parse(parts[3]), bool.Parse(parts[4]), int.Parse(parts[5]));
                _goals.Add(newEternal);
            }else if(parts[0] == "checklist"){
                ChecklistGoal newCheck = new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[5]), int.Parse(parts[7]), bool.Parse(parts[4]), int.Parse(parts[6]));
                _goals.Add(newCheck);
            }
           // writeEntry(parts[0], parts[1], parts[2]);
            }
        }
    }


    public void SaveFile(){

        Console.Write("Please enter your name: ");
        string user = Console.ReadLine().ToLower(); //file name

        using (StreamWriter outputFile = new StreamWriter($"{user}.txt")){ //creating file

            outputFile.WriteLine(_score); // points are tracked at the top of the file
            
            foreach(Goal GoalIterator in _goals){
                outputFile.WriteLine(GoalIterator.GetSaveFormat());
                
            }
        }
    }


    public Goal CreateGoal(int kind){

        Console.Write("What is the name of this Goal? ");
        string name = Console.ReadLine();

        Console.Write("Give a brief description of the Goal: ");
        string desc = Console.ReadLine();

        Console.Write("How many Points is this goal worth? ");
        int points = int.Parse(Console.ReadLine());
        

        if(kind == 1){
            return new SimpleGoal(name, desc, points);

        }else if(kind == 2){
            return new EternalGoal(name, desc, points);

        }else{

                Console.WriteLine("How many times do you need to repeat this Goal? ");
                int target = int.Parse(Console.ReadLine());

                Console.WriteLine("How many points is reaching the target worth? ");
                int bonus = int.Parse(Console.ReadLine());
            

            return new ChecklistGoal(name, desc, points, target, bonus);
        }
    }
}