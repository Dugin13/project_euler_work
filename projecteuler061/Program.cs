using System;
using System.Collections.Generic;
using System.Linq;

namespace projecteuler061
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Solving Project Euler Problem 61: Cyclical figurate numbers");
            
            // Generate all 4-digit figurate numbers for each type
            var triangular = GenerateFigurateNumbers(3);
            var square = GenerateFigurateNumbers(4);
            var pentagonal = GenerateFigurateNumbers(5);
            var hexagonal = GenerateFigurateNumbers(6);
            var heptagonal = GenerateFigurateNumbers(7);
            var octagonal = GenerateFigurateNumbers(8);

            var sets = new List<HashSet<int>> { triangular, square, pentagonal, hexagonal, heptagonal, octagonal };
            
            // Find cyclical chains
            var result = FindCyclicalChain(sets, new List<int>(), new bool[6]);
            
            if (result != null)
            {
                Console.WriteLine($"Cyclical chain found: {string.Join(" -> ", result)}");
                Console.WriteLine($"Sum: {result.Sum()}");
            }
            else
            {
                Console.WriteLine("No cyclical chain found");
            }
        }
        
        static List<int> FindCyclicalChain(List<HashSet<int>> sets, List<int> chain, bool[] used)
        {
            if (chain.Count == 6)
            {
                // Check if the chain is cyclical (last number connects to first)
                string lastTwo = chain.Last().ToString().Substring(2);
                string firstTwo = chain.First().ToString().Substring(0, 2);
                if (lastTwo == firstTwo)
                {
                    return new List<int>(chain);
                }
                return null;
            }
            
            for (int setIndex = 0; setIndex < sets.Count; setIndex++)
            {
                if (used[setIndex]) continue;
                
                foreach (int number in sets[setIndex])
                {
                    // Check if this number can be the next in the chain
                    if (chain.Count == 0 || 
                        chain.Last().ToString().Substring(2) == number.ToString().Substring(0, 2))
                    {
                        chain.Add(number);
                        used[setIndex] = true;
                        
                        var result = FindCyclicalChain(sets, chain, used);
                        if (result != null) return result;
                        
                        // Backtrack
                        chain.RemoveAt(chain.Count - 1);
                        used[setIndex] = false;
                    }
                }
            }
            
            return null;
        }
        
        static HashSet<int> GenerateFigurateNumbers(int type)
        {
            var numbers = new HashSet<int>();
            int n = 1;
            
            while (true)
            {
                int number = type switch
                {
                    3 => n * (n + 1) / 2,           // Triangular
                    4 => n * n,                     // Square
                    5 => n * (3 * n - 1) / 2,      // Pentagonal
                    6 => n * (2 * n - 1),          // Hexagonal
                    7 => n * (5 * n - 3) / 2,      // Heptagonal
                    8 => n * (3 * n - 2),          // Octagonal
                    _ => 0
                };
                
                if (number >= 10000) break;  // Stop when we exceed 4-digit numbers
                if (number >= 1000) numbers.Add(number);  // Only include 4-digit numbers
                n++;
            }
            
            return numbers;
        }
    }
}
