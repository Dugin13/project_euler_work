using System;
using System.Numerics;
using System.Threading.Tasks;

internal class Program
{
    private static async Task Main(string[] args)
    {
        int gridSize = 20;
        BigInteger totalRoutes = CalculateLatticeRoutes(gridSize);

        //Task<int> cal = ownRoute(gridSize, gridSize);
        //await cal;
        //BigInteger totalRoutes = cal.Result;

        Console.WriteLine($"Total routes through a {gridSize}x{gridSize} grid: {totalRoutes}");
    }

    static BigInteger CalculateLatticeRoutes(int gridSize)
    {
        // For an n×n grid, we need to calculate (2n choose n)
        // This equals (2n)! / (n! × n!)
        // We can optimize this calculation to avoid overflow
        
        BigInteger result = 1;
        for (int i = 1; i <= gridSize; i++)
        {
            result = result * (gridSize + i) / i;
        }
        return result;
    }
    static async Task<int> ownRoute(int x, int y)
    {
        int routes = 0;
        Task<int> one = null, two =null;

        if (x == 0 && y == 0)
        {
            return 1;
        }

        if (x > 0)
        {
            one = ownRoute(x - 1, y);
        }

        if (y > 0)
        {
            two = ownRoute(x, y - 1);
        }
        if (one != null)
        { 
            await one;
            routes += one.Result;
        }
        if (two != null) 
        { 
            await two;
            routes += two.Result;
        }
        return routes;

    }
}