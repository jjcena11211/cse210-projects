using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        int userNumber = -1;

        while (userNumber != 0)
        {
            Console.Write("Enter a number (0 to stop): ");
            userNumber = int.Parse(Console.ReadLine());

            // Add the number to the list if it's not zero
            if (userNumber != 0)
            {
                numbers.Add(userNumber);
            }
        }

        // computing the sum
        int sum = 0;

        foreach (int number in numbers)
        {
            sum += number;
        }

        Console.WriteLine($"The sum is: {sum}");

        // computing the average
        float average = (float)sum / numbers.Count;

        Console.WriteLine($"The average is: {average}");

        // find the largest number
        int max = numbers[0];

        foreach (int number in numbers)
        {
            if (number > max)
            {
                max = number;
            }
        }

        Console.WriteLine($"The largest number is: {max}");

        // stretch challenge 1
        // find the smallest positive number

        int smallestPositive = int.MaxValue;

        foreach (int number in numbers)
        {
            if (number > 0 && number < smallestPositive)
            {
                smallestPositive = number;
            }
        }

        Console.WriteLine($"The smallest positive number is: {smallestPositive}");

        // stretch challenge 2
        // sort and display the list

        numbers.Sort();

        Console.WriteLine("The sorted list is: ");

        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }
    }
}