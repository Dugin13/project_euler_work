/*
 * Project Euler Problem 4: Largest Palindrome Product
 * 
 * A palindromic number reads the same both ways. The largest palindrome made
 * from the product of two 2-digit numbers is 9009 = 91 × 99.
 * 
 * Find the largest palindrome made from the product of two 3-digit numbers.
 */

using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Project Euler Problem 4: Largest Palindrome Product");
        Console.WriteLine("Finding the largest palindrome made from the product of two 3-digit numbers...");
        
        int largestPalindrome = FindLargestPalindromeProduct();
        
        Console.WriteLine($"The largest palindrome is: {largestPalindrome}");
    }
    
    static int FindLargestPalindromeProduct()
    {
        int maxPalindrome = 0;
        
        // Check all products of two 3-digit numbers (100-999)
        for (int i = 999; i >= 100; i--)
        {
            for (int j = i; j >= 100; j--)
            {
                int product = i * j;
                
                // Early termination: if product is smaller than current max, break
                if (product <= maxPalindrome)
                    break;
                
                if (IsPalindrome(product))
                {
                    maxPalindrome = product;
                    Console.WriteLine($"Found palindrome: {product} = {i} × {j}");
                }
            }
        }
        
        return maxPalindrome;
    }
    
    static bool IsPalindrome(int number)
    {
        string str = number.ToString();
        int length = str.Length;
        
        for (int i = 0; i < length / 2; i++)
        {
            if (str[i] != str[length - 1 - i])
                return false;
        }
        
        return true;
    }
}
