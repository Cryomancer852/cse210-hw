using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {

        
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type a non-number to end.");
        string input = "0";

        while(int.TryParse(input, out int a)){
            Console.Write("Enter a number: ");
            input = Console.ReadLine();
            if(int.TryParse(input,out int num)){
                numbers.Add(num);
            }
        }
        int sum = 0;
        int max = -999999999;
        foreach(int num in numbers){
            sum += num;
            if(num > max){
                max = num;
            }
        }

        float avg = sum / numbers.Count;

        Console.WriteLine($"The Sum is {sum}.");
        Console.WriteLine($"The Max is {max}.");
        Console.WriteLine($"The Average is {avg}.");



    }
}