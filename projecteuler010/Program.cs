internal class Program
{
    private static void Main(string[] args)
    {
        const int limit = 2000000;
        long sum = SieveOfEratosthenes(limit);
        Console.WriteLine($"Sum of all primes below {limit}: {sum}");
    }
    
    static long SieveOfEratosthenes(int limit)
    {
        bool[] isPrime = new bool[limit];
        for (int i = 2; i < limit; i++)
            isPrime[i] = true;

        for (int i = 2; i * i < limit; i++)
        {
            if (isPrime[i])
            {
                for (int j = i * i; j < limit; j += i)
                    isPrime[j] = false;
            }
        }

        long sum = 0;
        for (int i = 2; i < limit; i++)
        {
            if (isPrime[i])
                sum += i;
        }
        return sum;
    }
}

/*
 * Project Euler Problem 010
 * The sum of the primes below two million.

     private static void Main(string[] args)
    {
        const int limit = 2000000;
        long sum = 0;
        List<long> primes = FindPrimeUnder(limit);
        foreach (long prime in primes)
        {
            sum += prime;
        }
        //Console.WriteLine("Primes found:");
        //Console.WriteLine(string.Join(", ", primes));
        Console.WriteLine($"Sum of all primes below {limit}: {sum}");
    }
    static List<long> FindPrimeUnder(int n)
    {
        List<long> primeNumbers = new List<long>() { 2 };
        for (long i = 3; i < n; i += 2)
        {
            if (!primeNumbers.Any(p => (i % p) == 0))
            {
                primeNumbers.Add(i);
            }
        }
        return primeNumbers;
    }
 */