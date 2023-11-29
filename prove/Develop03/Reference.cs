using System;

public class Reference{

    private string _book;
    private int _chapter;
    private List<int> _verses = new List<int>();

    public Reference(){
        _book = "John";
        _chapter = 3;
        _verses.Add(16);
    }

    public string GetHeading(){
            if (_verses.Count == 1){ // Allows for Verse objects with multiple actual verses 
                return $"{_book} {_chapter}:{_verses[0]}";
            }else{
                return $"{_book} {_chapter}:{_verses[0]}-{_verses[_verses.Count - 1] }";
            }
        }


}