# Project Euler 007 - C# Console Application

This is a C# console application designed to solve Project Euler Problem 007.

## Problem Statement

By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that the 6th prime is 13.

**What is the 10,001st prime number?**

## Project Structure

- `Program.cs` - Main entry point with the solution implementation
- `projecteuler007.csproj` - Project configuration file
- `.vscode/` - VS Code configuration files
  - `tasks.json` - Build and run tasks
  - `launch.json` - Debug configuration
- `.github/copilot-instructions.md` - GitHub Copilot instructions

## Getting Started

### Prerequisites

- [.NET 10.0 SDK](https://dotnet.microsoft.com/download) or later
- [Visual Studio Code](https://code.visualstudio.com/) with C# extension

### Building and Running

1. **Build the project:**
   ```bash
   dotnet build
   ```

2. **Run the application:**
   ```bash
   dotnet run
   ```

3. **Debug in VS Code:**
   - Press `F5` or use the "Run and Debug" panel
   - Set breakpoints in `Program.cs` as needed

### Using VS Code Tasks

- **Build:** `Ctrl+Shift+P` → "Tasks: Run Task" → "build"
- **Run:** `Ctrl+Shift+P` → "Tasks: Run Task" → "run"

## Solution Implementation

The current implementation includes:
- A placeholder for the prime number finding algorithm
- Proper console output formatting
- Ready-to-implement `FindNthPrime(int n)` method

**TODO:** Implement the actual algorithm to find the 10,001st prime number.

## Notes

- Focus on algorithm efficiency for finding large prime numbers
- Consider implementing the Sieve of Eratosthenes or similar optimization
- Test with smaller values (e.g., 6th prime = 13) before running the full solution