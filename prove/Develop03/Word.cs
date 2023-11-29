using System;

public class Word{

    private string _text;
    private bool _hidden;
    private string _blank;

    public Word(string text){
        _text = text;
        _hidden = false;
        foreach(char i in _text){
            _blank += "_";
        }
    }


    public void Hide(){
        _hidden = true;
    }

    public string GetText(){
        if(_hidden){
            return _blank;
        }else{
            return _text;
        }
    }

}