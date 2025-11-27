/*
 * Project Euler Problem 007
 * By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that the 6th prime is 13.
 * What is the 10,001st prime number?
 */

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Project Euler Problem 007 - Find the 10,001st prime number");

        // TODO: Implement the solution to find the 10,001st prime number
        long nthPrime = FindNthPrime(10001);
        Console.WriteLine($"The 10,001st prime number is: {nthPrime}");

        static long FindNthPrime(int n)
        {
            List<long> primeNumbers = new List<long>() { 2 };
            for (long i = 3; i < long.MaxValue; i += 2)
            {
                if (!primeNumbers.Any(p => (i % p) == 0))
                {
                    primeNumbers.Add(i);
                    if (primeNumbers.Count == n)
                    {
                        break;
                    }
                }
            }
            return primeNumbers.Last();
        }
    }
}