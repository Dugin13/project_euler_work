using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace projecteuler069
{
    class Program
    {
        static void Main(string[] args)
        {
            int limit = 1000000;

            // Original solution (slow - commented out)
            /*
            PrintArray(GetAllCommonDivisors(1, 10), "Common Divisors of 1 and 10");
            PrintArray(GetAllCommonDivisors(2, 10), "Common Divisors of 2 and 10");
            PrintArray(GetAllCommonDivisors(3, 10), "Common Divisors of 3 and 10");
            PrintArray(GetAllCommonDivisors(4, 10), "Common Divisors of 4 and 10");
            PrintArray(GetAllCommonDivisors(5, 10), "Common Divisors of 5 and 10");
            PrintArray(GetAllCommonDivisors(6, 10), "Common Divisors of 6 and 10");
            PrintArray(GetAllCommonDivisors(7, 10), "Common Divisors of 7 and 10");
            PrintArray(GetAllCommonDivisors(8, 10), "Common Divisors of 8 and 10");
            PrintArray(GetAllCommonDivisors(9, 10), "Common Divisors of 9 and 10");

            PrintArray(GetRelativelyPrime(10), "Relatively Prime to 10");
            
            int resultN = 0;
            double resultRatio = 0.0;
            int[] resultRelativelyPrime = null;
            for (int i = 0; i < limit; i++)
            {
                int[] relativelyPrime = GetRelativelyPrime(i);
                double ratio = (double)i / relativelyPrime.Length;
                if (ratio > resultRatio)
                {
                    resultRatio = ratio;
                    resultN = i;
                    resultRelativelyPrime = relativelyPrime;
                }
            }
            Console.WriteLine($"Result: n = {resultN}, φ(n) = {resultRelativelyPrime.Length}, n/φ(n) = {resultRatio}");
            PrintArray(resultRelativelyPrime, $"Relatively Prime to {resultN}");
            */

            // Optimized solution using Euler's totient function
            int resultN = 0;
            double maxRatio = 0.0;
            
            for (int n = 2; n <= limit; n++)
            {
                int phi = EulerTotient(n);
                double ratio = (double)n / phi;
                
                if (ratio > maxRatio)
                {
                    maxRatio = ratio;
                    resultN = n;
                }
            }
            
            Console.WriteLine($"Project Euler 069: Totient Maximum");
            Console.WriteLine($"Result: n = {resultN}");
            Console.WriteLine($"φ(n) = {EulerTotient(resultN)}");
            Console.WriteLine($"n/φ(n) = {maxRatio}");
            Console.WriteLine("lenght of relatively prime numbers: " + GetRelativelyPrime(resultN).Length);
        }
        internal static int GCD(int a, int b)
        {
            if (a < b)
            {   
                int temp = a;
                a = b;
                b = temp;
                
            }
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        internal static int[] GetAllCommonDivisors(int a, int b)
        {
            // First find the GCD
            int gcd = GCD(a, b);
            
            // Then find all divisors of the GCD
            List<int> divisors = new List<int>();
            for (int i = 1; i <= gcd; i++)
            {
                if (gcd % i == 0)
                {
                    divisors.Add(i);
                }
            }
            
            return divisors.ToArray();
        }

        internal static int[] GetRelativelyPrime(int n)
        {
            List<int> relativelyPrime = new List<int>();
            for (int i = 1; i < n; i++)
            {
                if (GCD(i, n) == 1)
                {
                    relativelyPrime.Add(i);
                }
            }
            return relativelyPrime.ToArray();
        }

        internal static int EulerTotient(int n)
        {
            int result = n;
            
            // Find all prime factors and apply formula
            for (int p = 2; p * p <= n; p++)
            {
                // If p is a prime factor
                if (n % p == 0)
                {
                    // Remove all factors of p
                    while (n % p == 0)
                        n /= p;
                    
                    // Apply formula: φ(n) = n * (1 - 1/p)
                    result -= result / p;
                }
            }
            
            // If n > 1, then it's a prime factor
            if (n > 1)
                result -= result / n;
            
            return result;
        }

        internal static void PrintArray(int[] array, string label = "")
        {
            if (!string.IsNullOrEmpty(label))
            {
                Console.Write($"{label}: ");
            }
            Console.WriteLine($"[{string.Join(", ", array)}]");
        }

    }
}
