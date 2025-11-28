# Project Euler 52: Permuted Multiples

## Problem Description

It can be seen that the number, 125874, and its double, 251748, contain exactly the same digits, but in a different order.

Find the smallest positive integer, x, such that 2x, 3x, 4x, 5x, and 6x contain the same digits.

## Solution

This C# console application solves Project Euler problem 52 by:

1. Starting with x = 1 and incrementing
2. For each x, checking if x, 2x, 3x, 4x, 5x, and 6x all contain the same digits
3. Using digit sorting to compare if numbers are permutations of each other
4. Returning the first x that satisfies the condition

## Answer

The solution is **142857**.

### Verification:
- 1x: 142857 → sorted digits: 124578
- 2x: 285714 → sorted digits: 124578
- 3x: 428571 → sorted digits: 124578
- 4x: 571428 → sorted digits: 124578
- 5x: 714285 → sorted digits: 124578
- 6x: 857142 → sorted digits: 124578

## How to Run

### Prerequisites
- .NET 10.0 or later

### Running the Application

1. **Build the project:**
   ```bash
   dotnet build
   ```

2. **Run the project:**
   ```bash
   dotnet run
   ```

3. **Using VS Code tasks:**
   - Press `Ctrl+Shift+P` to open command palette
   - Type "Tasks: Run Task" and select it
   - Choose either "build" or "run" task

### Debugging

1. Open the project in VS Code
2. Set breakpoints in `Program.cs` if desired
3. Press `F5` to start debugging
4. Or use the Run and Debug panel in VS Code

## Project Structure

```
projecteuler052/
├── .github/
│   └── copilot-instructions.md
├── .vscode/
│   ├── launch.json          # Debug configuration
│   └── tasks.json           # Build and run tasks
├── bin/                     # Build output (generated)
├── obj/                     # Build artifacts (generated)
├── Program.cs               # Main solution code
├── projecteuler052.csproj   # Project file
└── README.md               # This file
```

## Algorithm Complexity

- **Time Complexity:** O(n × m × log m) where n is the answer and m is the average number of digits
- **Space Complexity:** O(m) for digit sorting

The algorithm is brute force but efficient enough for this problem since the answer is relatively small (142857).