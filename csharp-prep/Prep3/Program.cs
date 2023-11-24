using System;

class Program
{
    static void Main(string[] args)
    {
        Random rng = new Random();
        string play = "yes";
        while(play.ToLower() == "yes" || play.ToLower() == "y"){
            int rand = rng.Next(1,11);
            int tries = 0;
            Console.WriteLine("Let's play a game of higher or lower!");
            bool end = false;

            while(!end){
            Console.Write("What's your guess: ");
            tries++;
            if(int.TryParse(Console.ReadLine(),out int guess)){
                if(guess > rand){
                    Console.WriteLine("Lower");
                }else if(guess < rand){
                    Console.WriteLine("Higher");
                }else{
                    Console.WriteLine($"Correct, it took you {tries} tries!");
                    end = true;
                }
            }else{
                Console.WriteLine("Numbers only!");
            }

            }

            Console.Write("Would you like to play again? ");

            play = Console.ReadLine();
        }
    }
}