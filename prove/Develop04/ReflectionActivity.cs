using System;
using System.Diagnostics;
using System.Collections.Generic;


public class ReflectionActivity : Activity{
    private List<string> _prompts = new List<string>();
    private List<string> _questions = new List<string>();
    private List<bool> _promptUsed = new List<bool>();
    private List<bool> _questionUsed = new List<bool>();

    public ReflectionActivity(int duration = 10) : base("Reflection", "Reflect on parts of your life that may go unappreciated.", duration){

        _questions.AddRange(new List<string>{"Why was this experience meaningful to you?", "Have you ever done anything like this before?", "How did you get started?", "How did you feel when it was complete?", "What made this time different than other times when you were not as successful?", "What is your favorite thing about this experience?", "What could you learn from this experience that applies to other situations?", "What did you learn about yourself through this experience?", "How can you keep this experience in mind in the future?"});
        _prompts.AddRange(new List<string>{"Think of a time when you stood up for someone else.", "Think of a time when you did something really difficult.", "Think of a time when you helped someone in need.", "Think of a time when you did something truly selfless."});

        foreach(string i in _prompts){
            _promptUsed.Add(false);
        }
        foreach(string i in _questions){
            _questionUsed.Add(false);
        }

    }

    public string GetRandomQuestion(){


        if(!_questionUsed.Contains(false)){ //Check if all questions have been used
            for(int i = 0; i < _questionUsed.Count; i++){
                _questionUsed[i] = false;
            }
        }

        Random rng = new Random();
        int a = rng.Next(0,_questions.Count); //Get random question

        while(_questionUsed[a] != false){
        a = rng.Next(0,_questions.Count);       // If question has been used, reroll
        }

        _questionUsed[a] = true;        //Make question as used and return question
        return _questions[a];
    }


    public string GetRandomPrompt(){


        if(!_promptUsed.Contains(false)){       //Check if all prompts have been used
            for(int i = 0; i < _promptUsed.Count; i++){
                _promptUsed[i] = false;
            }
        }

        Random rng = new Random();
        int a = rng.Next(0,_prompts.Count);     //Get random prompt

        while(_promptUsed[a] != false){
        a = rng.Next(0,_prompts.Count);         // If prompt has been used, reroll
        }

        _promptUsed[a] = true;                  //Mark prompt as used and return prompt
        return _prompts[a];
    }

    public void DisplayPrompt(){
        Console.WriteLine($"{GetRandomPrompt()}\n");
    }

    public void DisplayQuestion(){
        Console.WriteLine(GetRandomQuestion());
    }

    public void Run(){
        Console.WriteLine("Consider the following prompt:\n");
        DisplayPrompt();
        Console.Write("Press Enter when you are ready...");
        Console.ReadLine();
        Console.WriteLine("---------------");
        for(int i = 0; i < _duration; i++){
            DisplayQuestion();
            Animate(5);
        }
        EndActivity();
    }
}