using System;

public class Verse{
    private string _book;
    private int _chapter;
    private int[] _verses;

    private string _text;

    private string[] _blanks;

    public Verse(){
        _book = "John";
        _chapter = 3;
        _verses = new int[] {16};
        _text = "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life";
        _blanks = _text.Split(" ");
    }

    public string GetHeading(){
        if (_verses.Length == 1){ // Allows for Verse objects with multiple actual verses 
            return $"{_book} {_chapter}:{_verses[0]}";
        }else{
            return $"{_book} {_chapter}:{_verses[0]}-{_verses[_verses.Length - 1] }";
        }
    }

    public void FullDisplay(){
        Console.WriteLine($"{GetHeading()} {_text}.");
    }

    public void RedactedDisplay(){
        string redacted = "";
        foreach(string word in _blanks){
            redacted += $"{word} ";
        }
        Console.WriteLine($"{GetHeading()} {redacted}.");
    }

    public void Redact(int rolls){
        Random rng = new Random();

        int remainingWords = 0;
        foreach(string word in _blanks){ // Ensuring that the user doesn't get stuck in an infinite loop due to the i-- line below
            if(!word.StartsWith("_")){
                remainingWords++;
            }
        }
        if(remainingWords < rolls){
            rolls = remainingWords;
        }



        for(int i = 0; i < rolls; i++){
            int hit = rng.Next(0,_blanks.Length);
            if(_blanks[hit].StartsWith("_")){
                i--;// Ensures the the user gets a consistent number of words removed Potential problem accounted for above
            }else{
                string removed = "";
                foreach(char letter in _blanks[hit]){
                    removed += "_"; //Used to keep the word length consistent to help with UX
                }
                _blanks[hit] = removed;
            }

        }

        
    }

}