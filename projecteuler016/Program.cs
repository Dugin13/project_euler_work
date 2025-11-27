internal class Program
{
    private static void Main(string[] args)
    {
        int power = 1000;
        int value = 2;
        System.Numerics.BigInteger sum = 0, subResult=0;
        subResult = System.Numerics.BigInteger.Pow(value, power);
        string valueString = subResult.ToString();
        for (int i = 0; i < valueString.Length; i++)
        {
            sum += System.Numerics.BigInteger.Parse(valueString[i].ToString());
        }
        System.Console.WriteLine(sum);
    }
}