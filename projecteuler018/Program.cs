internal class Program
{
    private static void Main(string[] args)
    {
        // Project Euler Problem 18: Maximum path sum I
        int[,] triangle = {
            {75, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            {95, 64, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            {17, 47, 82, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            {18, 35, 87, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            {20, 04, 82, 47, 65, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            {19, 01, 23, 75, 03, 34, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            {88, 02, 77, 73, 07, 63, 67, 0, 0, 0, 0, 0, 0, 0, 0},
            {99, 65, 04, 28, 06, 16, 70, 92, 0, 0, 0, 0, 0, 0, 0},
            {41, 41, 26, 56, 83, 40, 80, 70, 33, 0, 0, 0, 0, 0, 0},
            {41, 48, 72, 33, 47, 32, 37, 16, 94, 29, 0, 0, 0, 0, 0},
            {53, 71, 44, 65, 25, 43, 91, 52, 97, 51, 14, 0, 0, 0, 0},
            {70, 11, 33, 28, 77, 73, 17, 78, 39, 68, 17, 57, 0, 0, 0},
            {91, 71, 52, 38, 17, 14, 91, 43, 58, 50, 27, 29, 48, 0, 0},
            {63, 66, 04, 68, 89, 53, 67, 30, 73, 16, 69, 87, 40, 31, 0},
            {04, 62, 98, 27, 23, 09, 70, 98, 73, 93, 38, 53, 60, 04, 23}
        };

        var result = FindMaxPathSum(triangle);
        Console.WriteLine($"Maximum path sum: {result.MaxSum}");
        Console.WriteLine($"Path: {string.Join(" -> ", result.Path)}");
    }

    private static PathResult FindMaxPathSum(int[,] triangle)
    {
        int rows = triangle.GetLength(0);
        
        // Create a copy to avoid modifying the original
        int[,] dp = new int[rows, triangle.GetLength(1)];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < triangle.GetLength(1); j++)
            {
                dp[i, j] = triangle[i, j];
            }
        }

        // Work from bottom to top
        for (int row = rows - 2; row >= 0; row--)
        {
            for (int col = 0; col <= row; col++)
            {
                dp[row, col] = triangle[row, col] + Math.Max(dp[row + 1, col], dp[row + 1, col + 1]);
            }
        }

        // Trace back the optimal path
        List<int> path = new List<int>();
        int currentRow = 0, currentCol = 0;
        
        while (currentRow < rows)
        {
            path.Add(triangle[currentRow, currentCol]);
            
            if (currentRow == rows - 1) break;
            
            // Choose the path that led to the maximum
            if (currentCol < rows - 1 && dp[currentRow + 1, currentCol + 1] > dp[currentRow + 1, currentCol])
            {
                currentCol++;
            }
            currentRow++;
        }

        return new PathResult { MaxSum = dp[0, 0], Path = path };
    }

    public class PathResult
    {
        public int MaxSum { get; set; }
        public List<int> Path { get; set; } = new List<int>();
    }
}