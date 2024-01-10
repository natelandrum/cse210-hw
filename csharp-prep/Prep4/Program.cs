using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {   
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        int number = 1;
        int sum = 0;
        List<int> numbers = new List<int>();
        
        while (number != 0)
        {
        Console.Write("Enter a number: ");
        string input = Console.ReadLine();
        number = int.Parse(input);
        if (number != 0)
        {
            numbers.Add(number);
        }
        }

        int max, min;
        max = min = numbers[0];
        
        foreach(int num in numbers)
        {
            sum += num;
            max = Math.Max(max, num);
            if (num > 0)
            {
                min = Math.Min(min, num);
            }
        }
        float average = (float)sum / numbers.Count;
        numbers.Sort();

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {max}");
        Console.WriteLine($"The smallest positive number is: {min}");
        Console.WriteLine("The sorted list is:")
        foreach(int num in numbers)
        {
            Console.WriteLine($"{num} ");
        }
    }
}