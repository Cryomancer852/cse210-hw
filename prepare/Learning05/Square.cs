using System;

public class Square : Shape{
    private double _side;

    public Square(double s, string color) : base(color){
        _side = s;
    }

    public override double getArea()
    {
        return _side * _side;
    }
}