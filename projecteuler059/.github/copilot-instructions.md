This project is a C# console application that solves Project Euler problem 59.

## Project Overview
- **Type**: C# Console Application
- **Problem**: Project Euler 59 - XOR Decryption  
- **Language**: C#
- **Framework**: .NET

## Implementation Details
The application decrypts a message that was encrypted using XOR with a 3-character lowercase key by:
1. Loading encrypted ASCII values from `0059_cipher.txt`
2. Trying all possible 3-character lowercase keys
3. Evaluating decryptions by counting common English words
4. Returning the best decryption and calculating sum of ASCII values

## Files
- `Program.cs`: Main application with decryption logic
- `0059_cipher.txt`: Encrypted data file
- `README.md`: Project documentation

## Usage
Run with: `dotnet run`

The answer to Project Euler 59 is **129448** (sum of ASCII values in decrypted message).
