using System;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        string again = "yes";
        while (again == "yes")
        {
            Random randomGenerator = new Random();
            int magicNumberInt = randomGenerator.Next(1, 101);
            
            Console.Write("Guess the magic number: ");
            string guess = Console.ReadLine();
            int guessInt = int.Parse(guess);
            int guesses = 1;
            do
            {
                if (guessInt < magicNumberInt)
                {
                    Console.WriteLine("Higher");
                }
                else if (guessInt > magicNumberInt)
                {
                    Console.WriteLine("Lower");
                }
                Console.Write("Guess the magic number: ");
                guess = Console.ReadLine();
                guessInt = int.Parse(guess);

                guesses++;
            } while (guessInt != magicNumberInt);
            Console.WriteLine("You guessed it!");
            Console.WriteLine($"It took you {guesses} guess(es).");
            Console.Write("Play again? (yes/no): ");
            again = Console.ReadLine();
        }
    }
}