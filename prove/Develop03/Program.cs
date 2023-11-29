using System;

class Program
{
    static void Main(string[] args)
    {
        Verse john = new Verse();
        //Console.WriteLine(john.GetHeading());
        john.FullDisplay();

        string response = "";
        // I didn't see if the project wanted me to include a scripture entry option
        while(response == ""){
            Console.Clear();
            john.RedactedDisplay();
            john.Redact(3);
            Console.WriteLine("Press enter to continue, type quit to end.");
            response = Console.ReadLine();
        }
    }
}