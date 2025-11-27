# Project Euler Problem 4: Largest Palindrome Product

## Problem Description

A palindromic number reads the same both ways. The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 × 99.

**Find the largest palindrome made from the product of two 3-digit numbers.**

## Solution

This C# console application solves Project Euler Problem 4 by:

1. Iterating through all possible products of two 3-digit numbers (100-999)
2. Checking if each product is a palindrome
3. Keeping track of the largest palindrome found

### Algorithm Optimization

- Start from the largest 3-digit numbers (999) and work downward
- Use early termination: if the current product is smaller than the largest palindrome found, break the inner loop
- Only check combinations where j ≤ i to avoid duplicate calculations

## Getting Started

### Prerequisites

- .NET SDK (version 10.0 or later)
- Visual Studio Code (recommended)

### Running the Application

1. **Using dotnet CLI:**
   ```bash
   dotnet run
   ```

2. **Using VS Code:**
   - Press `Ctrl+Shift+P` to open the command palette
   - Type "Tasks: Run Task"
   - Select "build" to build the project
   - Or simply press `F5` to run with debugging

3. **Building the project:**
   ```bash
   dotnet build
   ```

## Expected Output

```
Project Euler Problem 4: Largest Palindrome Product
Finding the largest palindrome made from the product of two 3-digit numbers...
Found palindrome: 580085 = 995 × 583
Found palindrome: 906609 = 993 × 913
The largest palindrome is: 906609
```

## Solution Explanation

The answer is **906609**, which is the product of 993 × 913.

## Project Structure

```
projecteuler004/
├── Program.cs           # Main application code
├── projecteuler004.csproj # Project configuration
├── README.md           # This file
└── .github/
    └── copilot-instructions.md # Copilot workspace instructions
```

## Development

This project was created as a .NET console application to solve Project Euler Problem 4. The solution uses an efficient algorithm that finds the answer quickly by starting from the largest possible numbers and using early termination optimization.