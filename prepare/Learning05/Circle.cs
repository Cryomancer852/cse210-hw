using System;

public class Circle : Shape{
    private double _radius;

    public Circle(double r, string color) : base(color){
        _radius = r;
    }

    public override double getArea()
    {
        return _radius * _radius * Math.PI;
    }
}