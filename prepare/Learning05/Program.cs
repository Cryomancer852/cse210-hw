using System;

class Program
{
    static void Main(string[] args)
    {
        Square bob = new Square(5, "red");
        Console.WriteLine($"This square is {bob.GetColor()} and has a area of {bob.getArea()}");

        Rectangle greg = new Rectangle(5, 7, "red");
        Console.WriteLine($"This rectangle is {greg.GetColor()} and has a area of {greg.getArea()}");

        Circle jim = new Circle(5, "red");
        Console.WriteLine($"This circle is {jim.GetColor()} and has a area of {jim.getArea()}");
    }
}