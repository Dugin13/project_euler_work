using System.Numerics;

internal struct NameValue
{
    public string Name { get; }
    public int AlphabeticalValue { get; }

    public NameValue(string name, int alphabeticalValue)
    {
        Name = name;
        AlphabeticalValue = alphabeticalValue;
    }
}

internal class Program
{
    private static async Task Main(string[] args)
    {
        // Load names from file into array
        string filePath = "0022_names.txt";
        string fileContent = File.ReadAllText(filePath);
        string[] names = fileContent.Split(',').Select(n => n.Trim('"')).ToArray();

        Console.WriteLine($"Loaded {names.Length} names");
        Console.WriteLine("Original first 10 names:");
        for (int i = 0; i < 10 && i < names.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {names[i]}");
        }

        // Sort names using async divide and conquer merge sort
        Console.WriteLine("\nSorting names using async divide and conquer...");
        string[] sortedNames = await AsyncMergeSort(names);

        Console.WriteLine("\nSorted first 10 names:");
        for (int i = 0; i < 10 && i < sortedNames.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {sortedNames[i]}");
        }
        Console.WriteLine($"\nTotal names: {sortedNames.Length}");
        // Calculate total name scores
        BigInteger totalScore = 0;
        List<NameValue> nameValues = new List<NameValue>();
        for (int i = 0; i < sortedNames.Length; i++)
        {
            int alphaValue = AlphabeticalValue(sortedNames[i]);
            nameValues.Add(new NameValue(sortedNames[i], alphaValue));
            BigInteger nameScore = (i + 1) * alphaValue;
            totalScore += nameScore;
        }

        Console.WriteLine($"\nTotal score: {totalScore}");
    }

    private static async Task<string[]> AsyncMergeSort(string[] array)
    {
        if (array.Length <= 1)
            return array;

        // For small arrays, use regular sort to avoid overhead
        if (array.Length < 100)
        {
            var result = new string[array.Length];
            Array.Copy(array, result, array.Length);
            Array.Sort(result);
            return result;
        }

        int mid = array.Length / 2;
        string[] left = new string[mid];
        string[] right = new string[array.Length - mid];

        Array.Copy(array, 0, left, 0, mid);
        Array.Copy(array, mid, right, 0, array.Length - mid);

        // Sort both halves asynchronously
        Task<string[]> leftTask = AsyncMergeSort(left);
        Task<string[]> rightTask = AsyncMergeSort(right);

        string[] sortedLeft = await leftTask;
        string[] sortedRight = await rightTask;

        return Merge(sortedLeft, sortedRight);
    }

    private static string[] Merge(string[] left, string[] right)
    {
        string[] result = new string[left.Length + right.Length];
        int leftIndex = 0, rightIndex = 0, resultIndex = 0;

        while (leftIndex < left.Length && rightIndex < right.Length)
        {
            if (string.Compare(left[leftIndex], right[rightIndex], StringComparison.Ordinal) <= 0)
            {
                result[resultIndex] = left[leftIndex];
                leftIndex++;
            }
            else
            {
                result[resultIndex] = right[rightIndex];
                rightIndex++;
            }
            resultIndex++;
        }

        // Copy remaining elements
        while (leftIndex < left.Length)
        {
            result[resultIndex] = left[leftIndex];
            leftIndex++;
            resultIndex++;
        }

        while (rightIndex < right.Length)
        {
            result[resultIndex] = right[rightIndex];
            rightIndex++;
            resultIndex++;
        }

        return result;
    }

    private static int AlphabeticalValue(string name)
    {
        int value = 0;
        foreach (char c in name)
        {
            value += c - 'A' + 1;
        }
        return value;
    }
}