internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        // Load cipher text from file into a List<int>
        var cipherPath = "0059_cipher.txt";
        var cipherText = new List<int>();
        if (File.Exists(cipherPath))
        {
            var content = File.ReadAllText(cipherPath);
            cipherText = content.Split(',')
                .Select(s => int.Parse(s.Trim()))
                .ToList();
            Console.WriteLine($"Loaded {cipherText.Count} cipher numbers.");
        }
        else
        {
            Console.WriteLine($"File not found: {cipherPath}");
        }

        if (cipherText.Count > 0)
        {
            Console.WriteLine("Cipher text loaded successfully.");
            
            // Project Euler 59: XOR decryption with 3-character lowercase key
            string decryptedMessage = DecryptXorCipher(cipherText);
            Console.WriteLine("Decrypted message:");
            Console.WriteLine(decryptedMessage);
            
            // Calculate sum of ASCII values in decrypted message
            int sum = decryptedMessage.Sum(c => (int)c);
            Console.WriteLine($"\nSum of ASCII values: {sum}");
        }
    }
    
    static string DecryptXorCipher(List<int> cipherText)
    {
        string bestDecryption = "";
        string bestKey = "";
        int maxCommonWords = 0;
        
        // Try all possible 3-character lowercase keys (a-z)
        for (char a = 'a'; a <= 'z'; a++)
        {
            for (char b = 'a'; b <= 'z'; b++)
            {
                for (char c = 'a'; c <= 'z'; c++)
                {
                    string key = $"{a}{b}{c}";
                    string decrypted = DecryptWithKey(cipherText, key);
                    
                    // Check if this looks like English text
                    int commonWords = CountCommonWords(decrypted);
                    if (commonWords > maxCommonWords)
                    {
                        maxCommonWords = commonWords;
                        bestDecryption = decrypted;
                        bestKey = key;
                    }
                }
            }
        }
        
        Console.WriteLine($"Cipher key found: {bestKey}");
        return bestDecryption;
    }
    
    static string DecryptWithKey(List<int> cipherText, string key)
    {
        var result = new List<char>();
        
        for (int i = 0; i < cipherText.Count; i++)
        {
            int keyChar = key[i % key.Length];
            int decryptedChar = cipherText[i] ^ keyChar;
            result.Add((char)decryptedChar);
        }
        
        return new string(result.ToArray());
    }
    
    static int CountCommonWords(string text)
    {
        // Common English words to look for
        string[] commonWords = { " the ", " and ", " that ", " have ", " for ", " not ", " with ", " you ", " this ", " but ", " his ", " from " };
        
        string lowerText = text.ToLower();
        int count = 0;
        
        foreach (string word in commonWords)
        {
            int index = 0;
            while ((index = lowerText.IndexOf(word, index)) != -1)
            {
                count++;
                index += word.Length;
            }
        }
        
        return count;
    }
}