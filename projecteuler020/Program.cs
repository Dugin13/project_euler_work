using System.Numerics;
// AI gave this as a freebie, did some minor edits.
/// <summary>
/// Project Euler Problem 020: Factorial digit sum
/// 
/// n! means n × (n − 1) × ... × 3 × 2 × 1
/// 
/// For example, 10! = 10 × 9 × ... × 3 × 2 × 1 = 3628800,
/// and the sum of the digits of 10! is 3 + 6 + 2 + 8 + 8 + 0 + 0 = 27.
/// 
/// Find the sum of the digits of 100!.
/// </summary>

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Project Euler Problem 020: Factorial digit sum");
        Console.WriteLine("Finding the sum of the digits of 100!");
        Console.WriteLine();

        // Calculate 100! using BigInteger to handle large numbers
        BigInteger factorial = CalculateFactorial(100);
        Console.WriteLine($"100! = {factorial}");

        // Calculate the sum of digits
        BigInteger digitSum = CalculateDigitSum(factorial);
        Console.WriteLine($"Sum of digits of 100! = {digitSum}");
    }

    /// <summary>
    /// Calculates the factorial of a given number
    /// </summary>
    /// <param name="n">The number to calculate factorial for</param>
    /// <returns>The factorial as a BigInteger</returns>
    private static BigInteger CalculateFactorial(int n)
    {
        if (n <= 1) return 1;
        
        BigInteger result = 1;
        for (int i = 2; i <= n; i++)
        {
            result *= i;
        }
        return result;
    }

    /// <summary>
    /// Calculates the sum of digits in a BigInteger
    /// </summary>
    /// <param name="number">The number to sum digits for</param>
    /// <returns>The sum of all digits</returns>
    private static BigInteger CalculateDigitSum(BigInteger number)
    {
        string numberString = number.ToString();
        BigInteger sum = 0;
        for(int i = 0; i < numberString.Length; i++)
        {
            BigInteger value;
            bool success = BigInteger.TryParse(numberString[i].ToString(), out value);
            if (success)
            {
                sum += value;
            }
        }
        /*
        foreach (char digit in numberString)
        {
            sum += (digit - '0'); // Convert char to int
        }
        */
        
        return sum;
    }
}