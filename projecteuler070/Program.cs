using System;
using System.Collections.Generic;
using System.Linq;

namespace projecteuler070
{
    class Program
    {
        static void Main(string[] args)
        {
            //test();
            int limit = 1000000;
            int resultN = 0;
            double resultRatio = 0.0;
            for (int i = 2; i < limit; i++)
            {
                int phi = EulerTotient(i);
                if (isPermutation(i, phi))
                {
                    double ratio = (double)i / phi;
                    if (ratio > resultRatio)
                    {
                        resultRatio = ratio;
                        resultN = i;
                    }
                }
            }

            Console.WriteLine($"Result: n = {resultN}, ratio = {resultRatio}");
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

        static bool isPermutation(int a, int b)
        {
            string aText = a.ToString();
            string bText = b.ToString();
            return string.Concat(aText.OrderBy(c => c)) == string.Concat(bText.OrderBy(c => c));
        }
        static void test()
        {
            int test = 87109;
            Console.WriteLine("n = " + test);
            int phi = EulerTotient(test);
            Console.WriteLine("φ(n) = " + phi);
            Console.WriteLine("length of relatively prime numbers: " + GetRelativelyPrime(test).Length);

            string testText = test.ToString();
            string phiText = phi.ToString();
            char[] testChars = testText.ToCharArray();
            char[] phiChars = phiText.ToCharArray();
            Array.Sort(testChars);
            Array.Sort(phiChars);
            string testSorted = new string(testChars);
            string phiSorted = new string(phiChars);
            bool arePermutations = testSorted == phiSorted;
            Console.WriteLine($"Are n and φ(n) permutations of each other? {arePermutations}");
            Console.WriteLine("n sorted: " + testSorted);
            Console.WriteLine("φ(n) sorted: " + phiSorted);
        }
    }
}
