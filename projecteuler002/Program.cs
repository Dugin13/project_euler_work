internal class Program
{
    private static void Main(string[] args)
    {
        uint sum = 0, number1 = 1, number2 = 1;
        bool condition = true;
        while (condition)
        {
            uint nextNumber = number1 + number2;
            number1 = number2;
            number2 = nextNumber;

            if (nextNumber % 2 == 0)
            {
                sum += nextNumber;
            }
            if (nextNumber >= 4000000)
            {
                condition = false;
            }
        }
        Console.WriteLine(sum);
    }
}