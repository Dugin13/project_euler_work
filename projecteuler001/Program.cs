using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectEuler001
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Welcome to Project Euler 001!");
            int numberLimit = 1000;
            // Run both methods asynchronously
            Task<List<int>> task3 = MultiplesAsync(numberLimit, 3);
            Task<List<int>> task5 = MultiplesAsync(numberLimit, 5);
            
            // Wait for both to complete
            var multiples3 = await task3;
            var multiples5 = await task5;

            var combined = new List<int>(multiples3);
            combined.AddRange(multiples5);
            
            // Remove duplicates using HashSet and sort
            var uniqueCombined = new HashSet<int>(combined);
            var sortedUnique = new List<int>(uniqueCombined);
            sortedUnique.Sort();
            
            // Display results
            Console.WriteLine($"Multiples of 3 below {numberLimit}: [{string.Join(", ", multiples3)}]");
            Console.WriteLine($"Multiples of 5 below {numberLimit}: [{string.Join(", ", multiples5)}]");
            Console.WriteLine($"Combined unique multiples: [{string.Join(", ", sortedUnique)}]");
            Console.WriteLine($"Sum of unique multiples: {sortedUnique.Sum()}");
            
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
        static async Task<List<int>> MultiplesAsync(int limit, int factor)
        {
            return await Task.Run(() =>
            {
                List<int> multiples = new List<int>();
                bool found = false;
                int x = 0;
                while (!found)
                {
                    int result = factor * x;
                    if (result < limit)
                    {
                        multiples.Add(result);
                        x++;
                    }
                    else
                    {
                        found = true;
                    }
                }
                return multiples;
            });
        }
        
    }
}