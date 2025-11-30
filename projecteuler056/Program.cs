using System.Numerics;

internal class Program
{
    // Project Euler Problem 56 Task:
    // "Consider natural numbers of the form a^b, where a, b < 100. What is the maximum digital sum?"
    private static void Main(string[] args)
    {
        int limit = 100;
        int maxSum = 0;
        int a = 0;
        int b = 0;
        for (int i = 1; i < limit; i++)
        {
            for (int x = 1; x < limit; x++)
            {
                var bigNum = BigInteger.Pow(i, x);
                int digitSum = bigNum.ToString().Select(c => c - '0').Sum();
                if (digitSum > maxSum)
                {
                    maxSum = digitSum;
                    a = i;
                    b = x;
                }
            }
        }
        Console.WriteLine($"Maximum digital sum: {maxSum} for a = {a} and b = {b}");
    }
}