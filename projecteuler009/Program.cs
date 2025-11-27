internal class Program
{
    private static void Main(string[] args)
    {
        // Find Pythagorean triplet (a, b, c) such that a + b + c = 1000 and a^2 + b^2 = c^2
        int sum = 1000;
        for (int a = 1; a < sum / 3; a++)
        {
            for (int b = a + 1; b < sum / 2; b++)
            {
                int c = sum - a - b;
                if (a * a + b * b == c * c)
                {
                    Console.WriteLine($"a={a}, b={b}, c={c}");
                    Console.WriteLine($"Product: {a * b * c}");
                    return;
                }
            }
        }
    }
}