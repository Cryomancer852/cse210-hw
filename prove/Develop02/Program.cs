using System;
using System.Buffers;
using System.IO;


class Journal
{
    public string _owner = "";
    
    public List<Entry> content = new List<Entry>();

    public Journal readJournal(){
        Journal newJournal = new Journal();
        string[] lines = System.IO.File.ReadAllLines($"{_owner}.txt"); //Using the owner's name as the namespace for the file

        foreach(string line in lines){
            string[] parts = line.Split(",");

            writeEntry(parts[0], parts[1], parts[2]);
        }

        return newJournal;
    }

    public void writeEntry(string newDate, string newPrompt, string newText){ //Since it adds the entry to the journal it's here instead of in the Entry class
        Entry newEntry = new Entry();

        newEntry._date = newDate;
        newEntry._text = newText;
        newEntry._prompt = newPrompt;

        content.Add(newEntry);

    }

    public void displayJournal(){
        foreach(Entry i in content){
            i.readEntry();
            Console.WriteLine();
        }
    }


    public void saveJournal(){
        using (StreamWriter outputFile = new StreamWriter($"{_owner}.txt")){
            foreach(Entry log in content){
                outputFile.WriteLine($"{log._date},{log._prompt},{log._text}");
            }
        }
    }
}

class Entry
{
    public string _text = "";
    public string _prompt = "";
    public string _date = "";

    

    public void readEntry(){
        Console.WriteLine($"Date: {_date} - Prompt: {_prompt}");
        Console.WriteLine(_text);
    }
}
class Program
{
    static void Main(string[] args)
    {
        Random rng = new Random();
        List<string> prompts = new List<string>(); //Tried using string[] and defining the items when the array was declared, but I started getting issues with prompts.Count while using that
        prompts.Add("What was the first thing you did this morning?");
        prompts.Add("Who was the first person who did something nice for you today?");
        prompts.Add("What good thing happened in the last 10 minutes");
        prompts.Add("Where are you headed or what are you doing right now?");
        prompts.Add("What are you looking forward to today?");

        Console.WriteLine("Welcome to the Journal Program");

        Journal activeJournal = new Journal();
        Console.Write("Please enter your name: ");
        activeJournal._owner = Console.ReadLine(); //Using the user's name as the file name, this lets me load the file automatically and removes an input

        if(!File.Exists($"{activeJournal._owner}.txt")){ //Checks if there is a journal to open

            using(StreamWriter newJ = File.CreateText($"{activeJournal._owner}.txt")){} //Creates and closes an empty journal to write to
        }
        activeJournal.readJournal();

        Console.WriteLine();

        bool response = true; //Break condition
        while(response){
            Console.WriteLine("What would you like to do?\n1. Write\n2. Display\n3. Save\n4. Quit");

            if(int.TryParse(Console.ReadLine(),out int input)){ //Valid Input
                Console.WriteLine();

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
                    activeJournal.saveJournal(); //Save and close seems like a logical addition, but it may make the option to only save obselete. If the user gets repeat prompts they won't make multiple entries back to back
                    response = false;
                }
            }else{ //Invalid Input
                Console.WriteLine("Type the number for the action you want.");
            }
        }

    }
}