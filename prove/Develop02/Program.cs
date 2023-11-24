using System;
using System.Buffers;
using System.IO;


class Journal
{
    public string owner = "";
    
    public List<Entry> content = new List<Entry>();

    public Journal readJournal(){
        Journal newJournal = new Journal();
        string[] lines = System.IO.File.ReadAllLines($"{owner}.txt"); //Using the owner's name as the namespace for the file

        foreach(string line in lines){
            string[] parts = line.Split(",");

            writeEntry(parts[0], parts[1], parts[2]);
        }

        return newJournal;
    }

    public void writeEntry(string newDate, string newPrompt, string newText){
        Entry newEntry = new Entry();

        newEntry.date = newDate;
        newEntry.text = newText;
        newEntry.prompt = newPrompt;

        content.Add(newEntry);

    }

    public void displayJournal(){
        foreach(Entry i in content){
            i.readEntry();
            Console.WriteLine();
        }
    }


    public void saveJournal(){
        using (StreamWriter outputFile = new StreamWriter($"{owner}.txt")){
            foreach(Entry log in content){
                outputFile.WriteLine($"{log.date},{log.prompt},{log.text}");
            }
        }
    }
}

class Entry
{
    public string text = "";
    public string prompt = "";
    public string date = "";

    

    public void readEntry(){
        Console.WriteLine($"Date: {date} - Prompt: {prompt}");
        Console.WriteLine(text);
    }
}
class Program
{
    static void Main(string[] args)
    {
        Random rng = new Random();
        List<string> prompts = new List<string>(); 
        prompts.Add("What was the first thing you did this morning?");
        prompts.Add("Who was the first person who did something nice for you today?");
        prompts.Add("What good thing happened in the last 10 minutes");
        prompts.Add("Where are you headed or what are you doing right now?");
        prompts.Add("What are you looking forward to today?");

        Console.WriteLine("Welcome to the Journal Program");

        Journal activeJournal = new Journal();
        Console.Write("Please enter your name: ");
        activeJournal.owner = Console.ReadLine();
        if(!File.Exists($"{activeJournal.owner}.txt")){
            using(StreamWriter newJ = File.CreateText($"{activeJournal.owner}.txt")){}
        }
        activeJournal.readJournal();

        bool response = true;
        while(response){
            Console.WriteLine("What would you like to do?\n1. Write\n2. Display\n3. Save\n4. Quit");

            if(int.TryParse(Console.ReadLine(),out int input)){ //Valid Input

                if(input == 1){ //Writing
                    DateTime current = DateTime.Now;
                    string date = current.ToShortDateString();
                    string prompt = prompts[rng.Next(0,prompts.Count)];
                    Console.WriteLine(prompt);
                    string answer = Console.ReadLine();
                    activeJournal.writeEntry(date, prompt, answer);

                }else if(input == 2){ //Reading
                    activeJournal.displayJournal();

                }else if(input == 3){ //Saving
                    activeJournal.saveJournal();
                }else{ //Closing
                    response = false;
                }
            }else{ //Invalid Input
                Console.WriteLine("Type the number for the action you want.");
            }
        }

    }
}