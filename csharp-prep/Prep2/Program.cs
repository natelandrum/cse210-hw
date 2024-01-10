using System;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade? ");
        string input = Console.ReadLine();
        int grade = int.Parse(input);
        string letter;

        if (grade >= 90)
        {
            letter = "A";
        }
        else if (grade >= 80)
        {
            letter = "B";
        }
        else if (grade >= 70) 
        {
            letter = "C";
        }
        else if (grade >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        if (grade % 10 >= 7 && !(letter == "A" || letter == "F"))
        {
            letter += "+";
        }

        if (grade % 10 <= 3 && !(letter == "F"))
        {
            letter += "-";
        }

        Console.WriteLine($"Your letter grade is {letter}.");

        if (grade > 70)
        {
            Console.WriteLine("You passed!");
        }
        else
        {
            Console.WriteLine("You failed! Try Harder next time!");
        }
    }
}