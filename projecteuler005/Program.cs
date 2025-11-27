
internal class Program
{
    private static void Main(string[] args)
    {
        int max = 20;
        long lcm = 1;
        for (int i = 2; i <= max; i++)
        {
            lcm = LCM(lcm, i);
        }
        Console.WriteLine($"Smallest positive number evenly divisible by all numbers from 1 to {max}: {lcm}");

        long LCM(long a, long b)
        {
            return a * b / GCD(a, b);
        }

        long GCD(long a, long b)
        {
            while (b != 0)
            {
                long temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
    }
}