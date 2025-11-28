using System.Numerics;

internal class Program
{
    private static void Main(string[] args)
    {
        BigInteger sum = BigInteger.Zero;
        int target = 1000;
        int digitLimit = 10;
        for (int i = 1; i <= target; i++)
        {
            sum += BigInteger.Pow(i, i);
            sum %= BigInteger.Pow(10, digitLimit);
        }
        string result = sum.ToString().Substring(0, digitLimit);
        Console.WriteLine(result);
    }
}