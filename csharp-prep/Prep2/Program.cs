using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Input your grade: ");
        string gradeBad = Console.ReadLine();
        string letterGrade = String.Empty;

        if(int.TryParse(gradeBad, out int grade)){

            if(grade >= 90){
                letterGrade = "A";
            }else if(grade >= 80){
                letterGrade = "B";
            }else if(grade >= 70){
                letterGrade = "C";
            }else if(grade >= 60){
                letterGrade = "D";
            }

            //Stretch 1
            if(grade % 10 >= 7){
                letterGrade += "+";
            }else if( grade % 10 < 4){
                letterGrade += "-";
            }


            if(grade == 100){ 
                //While schools may not officially recognize A+ as a grade many teachers do so I've kept this. This is here because my +/- detection removes the + from a perfect score
                letterGrade = "A+";
            }
            if(grade < 60){
                //Stretch 3
                letterGrade = "F";
            }

        }

        Console.WriteLine($"Your letter grade is {letterGrade}.");

    }
}