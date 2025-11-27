internal class Program
{
    private static void Main(string[] args)
    {
        long number = 600851475143;
        long largestPrimeFactor = FindLargestPrimeFactor(number);
        
        Console.WriteLine($"The largest prime factor of {number} is: {largestPrimeFactor}");
    }
    
    static long FindLargestPrimeFactor(long n)
    {
        long largestFactor = -1;
        
        // Handle factor 2
        while (n % 2 == 0)
        {
            largestFactor = 2;
            n = n / 2;
        }
        
        // Check odd factors from 3 onwards
        for (long i = 3; i * i <= n; i += 2)
        {
            while (n % i == 0)
            {
                largestFactor = i;
                n = n / i;
            }
        }
        
        // If n is still greater than 2, then it's a prime number
        if (n > 2)
        {
            largestFactor = n;
        }
        
        return largestFactor;
    }
}