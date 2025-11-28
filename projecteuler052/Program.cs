/*
well the AI made this one for me :)
Project Euler Problem 52: Permuted multiples

It can be seen that the number, 125874, and its double, 251748, contain exactly the same digits, but in a different order.

Find the smallest positive integer, x, such that 2x, 3x, 4x, 5x, and 6x contain the same digits.
*/

using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Project Euler Problem 52: Permuted multiples");
        Console.WriteLine("Finding the smallest positive integer x such that 2x, 3x, 4x, 5x, and 6x contain the same digits...\n");
        
        int result = FindPermutedMultiples();
        
        Console.WriteLine($"Answer: {result}");
        Console.WriteLine($"Verification:");
        Console.WriteLine($"1x: {result} -> {SortDigits(result)}");
        Console.WriteLine($"2x: {2 * result} -> {SortDigits(2 * result)}");
        Console.WriteLine($"3x: {3 * result} -> {SortDigits(3 * result)}");
        Console.WriteLine($"4x: {4 * result} -> {SortDigits(4 * result)}");
        Console.WriteLine($"5x: {5 * result} -> {SortDigits(5 * result)}");
        Console.WriteLine($"6x: {6 * result} -> {SortDigits(6 * result)}");
    }
    
    static int FindPermutedMultiples()
    {
        int x = 1;
        
        while (true)
        {
            if (HasSameDigits(x, 2 * x) &&
                HasSameDigits(x, 3 * x) &&
                HasSameDigits(x, 4 * x) &&
                HasSameDigits(x, 5 * x) &&
                HasSameDigits(x, 6 * x))
            {
                return x;
            }
            x++;
        }
    }
    
    static bool HasSameDigits(int num1, int num2)
    {
        return SortDigits(num1) == SortDigits(num2);
    }
    
    static string SortDigits(int number)
    {
        return new string(number.ToString().OrderBy(c => c).ToArray());
    }
}
