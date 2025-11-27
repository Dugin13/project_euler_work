using System;

internal class Program
{
    private static void Main(string[] args)
    {
        const int targetDivisorCount = 500;  // Problem 12 asks for over 500 divisors
        
        long result = FindFirstTriangularNumberWithDivisorCount(targetDivisorCount);
        
        Console.WriteLine($"First triangular number with over {targetDivisorCount} divisors: {result}");
        Console.WriteLine($"Number of divisors: {CountDivisors(result)}");
        
        Console.ReadLine();
    }
    
    private static long FindFirstTriangularNumberWithDivisorCount(int targetCount)
    {
        long n = 1;
        
        while (true)
        {
            long triangularNumber = GenerateTriangularNumber(n);
            
            if (CountDivisors(triangularNumber) > targetCount)
            {
                return triangularNumber;
            }
            
            n++;
        }
    }
    
    private static long GenerateTriangularNumber(long n)
    {
        return n * (n + 1) / 2;
    }
    
    private static int CountDivisors(long number)
    {
        int count = 0;
        long sqrt = (long)Math.Sqrt(number);
        
        for (long divisor = 1; divisor <= sqrt; divisor++)
        {
            if (number % divisor == 0)
            {
                count++; // Count the divisor
                
                // If divisor is not the square root, count its pair too
                if (divisor != number / divisor)
                {
                    count++;
                }
            }
        }
        
        return count;
    }
}