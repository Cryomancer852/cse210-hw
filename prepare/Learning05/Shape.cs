using System;

public abstract class Shape{
    private string _color;

    public Shape(string color){
        _color = color;
    }
    public string GetColor(){
        return _color;
    }
    public void SetColor(string newColor){
        _color = newColor;
    }

    public abstract double getArea();
}