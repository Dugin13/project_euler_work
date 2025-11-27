internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        int n = 100;
        int sumOfSquares = 0;
        int sum = 0;
        for (int i = 1; i <= n; i++)
        {
            sumOfSquares += i * i;
            sum += i;
        }
        int squareOfSum = sum * sum;
        int difference = squareOfSum - sumOfSquares;
        Console.WriteLine("squareOfSum: " + squareOfSum);
        Console.WriteLine("sumOfSquares: " + sumOfSquares);
        Console.WriteLine($"Difference: {difference}");
    }
}