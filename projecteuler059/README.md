# Project Euler 59: XOR Decryption

This C# console application solves Project Euler problem 59 by decrypting a message that was encrypted using XOR encryption with a 3-character lowercase key.

## Problem Description

Each character on a computer is assigned a unique code and the preferred standard is ASCII. For example, uppercase A = 65, asterisk (*) = 42, and lowercase k = 107.

A modern encryption method is to take a text file, convert the bytes to ASCII, then XOR each byte with a given value, taken from a secret key. The advantage with the XOR function is that using the same encryption key on the cipher text, restores the plain text.

The encryption key consists of three lower case characters. Using the cipher text provided in `0059_cipher.txt`, find the original message and calculate the sum of the ASCII values in the original text.

## Solution

The program:

1. Loads the encrypted ASCII values from `0059_cipher.txt`
2. Tries all possible 3-character lowercase keys (26³ = 17,576 combinations)
3. For each key, decrypts the message using XOR
4. Evaluates which decryption looks most like English text by counting common English words
5. Returns the best decryption and calculates the sum of ASCII values

## Answer

The decrypted message is an extract from Euler's paper "De summis serierum reciprocarum" about the Basel problem.

**Sum of ASCII values: 129448**

## Usage

```bash
dotnet run
```

The program will automatically:
- Load the cipher text from `0059_cipher.txt`
- Decrypt the message
- Display the decrypted text
- Calculate and display the sum of ASCII values