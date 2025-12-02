using System;
using System.Numerics;
using System.Linq;

namespace projecteuler061
{
    class ownStuff
    {
        static void doStuff()
        {
            /* seem like I misunderstood the problem
            
            
            */
            Console.WriteLine("Hello, World!");
            bool solved = false;
            int limit = 10000;
            int n = 1;
            int hexSolutionsFound = 0;
            int heptSolutionsFound = 0;
            int octSolutionsFound = 0;
            string tohit = "1288";

            
            while (!solved)
            {
                BigInteger hexagonalNum = hexagonalNumber(n);
                BigInteger heptagonalNum = heptagonalNumber(n);
                BigInteger octagonalNum = octagonalNumber(n);

                string hexStr = hexagonalNum.ToString();
                hexStr = String.Concat(hexStr.OrderBy(c => c));
                string heptStr = heptagonalNum.ToString();
                heptStr = String.Concat(heptStr.OrderBy(c => c));
                string octStr = octagonalNum.ToString();
                octStr = String.Concat(octStr.OrderBy(c => c));
                if (hexStr == tohit)
                {
                    hexSolutionsFound = n;
                    Console.WriteLine($"Hexagonal solution found: {hexagonalNum} for n={n}");
                }
                if (heptStr == tohit)
                {
                    heptSolutionsFound = n;
                    Console.WriteLine($"Heptagonal solution found: {heptagonalNum} for n={n}");
                }
                if (octStr == tohit)
                {
                    octSolutionsFound = n;
                    Console.WriteLine($"Octagonal solution found: {octagonalNum} for n={n}");
                }
                n++;
                if (hexSolutionsFound > 0 && heptSolutionsFound > 0 && octSolutionsFound > 0)
                {
                    solved = true;
                }
                else if (n > limit)
                {
                    Console.WriteLine("No solution found within bounds.");
                    break;
                }
            }
            solved = false;
            n=1;
            while(!solved)
            {
                BigInteger octagonalNum = octagonalNumber(n);
                Console.WriteLine($"Testing octagonal number: {octagonalNum} for n={n}");
                if (octagonalNum > 8821)
                {
                    Console.WriteLine("Exceeded upper limit without finding solution.");
                    break;
                }
                n++;
            }

            

        }



        static BigInteger triangleNumber(int n)
        {
            return n * (n + 1) / 2;
        }
        static BigInteger squareNumber(int n)
        {
            return n * n;
        }
        static BigInteger pentagonalNumber(int n)
        {
            return n * (3 * n - 1) / 2;
        }
        static BigInteger hexagonalNumber(int n)
        {
            return n * (2 * n - 1);
        }
        static BigInteger heptagonalNumber(int n)
        {
            return n * (5 * n - 3) / 2;
        }
        static BigInteger octagonalNumber(int n)
        {
            return n * (3 * n - 2);
        }
    }
}