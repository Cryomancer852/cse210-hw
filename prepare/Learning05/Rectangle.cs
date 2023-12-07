using System;

public class Rectangle : Shape{
    private double _length;
    private double _width;

    public Rectangle(double l, double w, string color) : base(color){
        _length = l;
        _width = w;
    }

    public override double getArea()
    {
        return _length * _width;
    }
}