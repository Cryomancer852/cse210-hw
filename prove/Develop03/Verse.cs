using System;
using System.Collections.Generic;

public class Verse{


    private Reference _heading;
    private string _text;

    private List<Word> _words = new List<Word>();

    public Verse(){
        _heading = new Reference();
        _text = "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life";
        foreach(string word in _text.Split(" ")){
            Word i = new Word(word);
            _words.Add(i);
        }
    }


    
    

    public void FullDisplay(){
        Console.WriteLine($"{_heading.GetHeading()} {_text}.");
    }

    public void RedactedDisplay(){
        string redacted = "";
        foreach(Word singleWord in _words){
            redacted += $"{singleWord.GetText()} ";
        }
        Console.WriteLine($"{_heading.GetHeading()} {redacted}.");
    }

    public void Redact(int rolls){
        Random rng = new Random();

        int remainingWords = 0;
        foreach(Word singleWord in _words){ // Ensuring that the user doesn't get stuck in an infinite loop due to the i-- line below
            if(!singleWord.GetText().StartsWith("_")){
                remainingWords++;
            }
        }
        if(remainingWords < rolls){
            rolls = remainingWords;
        }



        for(int i = 0; i < rolls; i++){
            int hit = rng.Next(0,_words.Count);
            if(_words[hit].GetText().StartsWith("_")){
                i--;// Ensures the the user gets a consistent number of words removed Potential problem accounted for above
            }else{
                _words[hit].Hide();
            }

        }

        
    }

}