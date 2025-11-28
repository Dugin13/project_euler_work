using System.Numerics;

internal class Program
{
    private static void Main(string[] args)
    {
        bool found = false;
        int t=285, p=165, h=143;
        t++;
        while (!found)
        {
            BigInteger triangleNumber = calTriangleNumber(t);
            BigInteger pentagonalNumber = calPentagonalNumber(p);
            BigInteger hexagonalNumber = calHexagonalNumber(h);

            if (triangleNumber == pentagonalNumber && pentagonalNumber == hexagonalNumber)
            {
                Console.WriteLine($"Found number: {triangleNumber} at T={t}, P={p}, H={h}");
                found = true;
            }
            else
            {
                if (triangleNumber <= pentagonalNumber && triangleNumber <= hexagonalNumber)
                {
                    t++;
                }
                else if (pentagonalNumber <= triangleNumber && pentagonalNumber <= hexagonalNumber)
                {
                    p++;
                }
                else
                {
                    h++;
                }
            }
        }
    }

    private static BigInteger calTriangleNumber(int n)
    {
        return (BigInteger)n * (n + 1) / 2;
    }
    
    private static BigInteger calPentagonalNumber(int n)
    {
        return (BigInteger)n * (3 * n - 1) / 2;
    }

    private static BigInteger calHexagonalNumber(int n)
    {
        return (BigInteger)n * (2 * n - 1);
    }
}