using System.Collections.Generic;
using System.Numerics;

internal class Program
{
    private static void Main(string[] args)
    {
        int digitsTarget = 1000;
        List<BigInteger> bigNumbers = new List<BigInteger>();
        bigNumbers.Add(BigInteger.Parse("1"));
        bigNumbers.Add(BigInteger.Parse("1"));
        int i = 2;
        bool found = false;

        while (!found)
        {
            BigInteger nextNumber = bigNumbers[i - 1] + bigNumbers[i - 2];
            bigNumbers.Add(nextNumber);

            if (nextNumber.ToString().Length >= digitsTarget)
            {
                System.Console.WriteLine(i + 1); // +1 for 1-based index
                found = true;
            }
            i++;
        }

    }
}