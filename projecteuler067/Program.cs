using System;
using System.IO;
using System.Numerics;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections.Generic;

namespace projecteuler067
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Project Euler 067: Maximum Path Sum II");

            // Load triangle from file
            int[][] triangle = LoadTriangleFromFile("0067_triangle.txt");

            Console.WriteLine($"Triangle loaded successfully with {triangle.Length} rows");
            
            // Display the triangle in pyramid shape
            DrawTrianglePyramid(triangle, maxRows: 100, filename: "triangle_pyramid.png");
            
            int[][] maxPathTriangle = MakePath(triangle);
            int[] maxPathColumns = FindMaxPathCoordinates(triangle, maxPathTriangle);
            int[] maxPath = FindMaxPath(triangle, maxPathColumns);
            
            // Create image with highlighted maximum path
            DrawTrianglePyramid(triangle, maxRows: 100, filename: "triangle_with_path.png", pathColumns: maxPathColumns);
            DrawTrianglePyramid(maxPathTriangle, filename: "max_path_triangle_pyramid.png", maxRows: 100, pathColumns: maxPathColumns);
            
            Console.WriteLine($"Maximum path: {string.Join(" -> ", maxPath)}");
            BigInteger sum = SumOfMaxPath(maxPath);
            Console.WriteLine($"Maximum path sum: {sum}");
        }

        static int[][] LoadTriangleFromFile(string filename)
        {
            string[] lines = File.ReadAllLines(filename);
            int[][] triangle = new int[lines.Length][];

            for (int i = 0; i < lines.Length; i++)
            {
                string[] numbers = lines[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                triangle[i] = new int[numbers.Length];

                for (int j = 0; j < numbers.Length; j++)
                {
                    triangle[i][j] = int.Parse(numbers[j]);
                }
            }

            return triangle;
        }

        static int[][] MakePath(int[][] triangle)
        {
            int rows = triangle.Length;
            int[][] result = new int[rows][];
            for (int i = 0; i < rows; i++)
            {
                result[i] = new int[triangle[i].Length];
                Array.Copy(triangle[i], result[i], triangle[i].Length);
            }

            for (int row = rows - 2; row >= 0; row--)
            {
                for (int col = 0; col < triangle[row].Length; col++)
                {
                    result[row][col] += Math.Max(
                        result[row + 1][col],
                        result[row + 1][col + 1]);
                }
            }
            return result;
        }

        static BigInteger SumOfMaxPath(int[] maxPath)
        {
            BigInteger sum = 0;
            foreach (var num in maxPath)
            {
                sum += num;
            }
            return sum;
        }
        static int[] FindMaxPathCoordinates(int[][] triangle, int[][] path)
        {
            int rows = triangle.Length;
            int[] result = new int[rows]; // result[row] = col
            int col = 0;
            for (int row = 0; row < rows; row++)
            {
                result[row] = col;
                if (row < rows - 1)
                {
                    if (path[row + 1][col] < path[row + 1][col + 1])
                    {
                        col++;
                    }
                }
            }
            return result;
        }

        static int[] FindMaxPath(int[][] triangle, int[] pathColumns)
        {
            int[] result = new int[pathColumns.Length];
            for (int row = 0; row < pathColumns.Length; row++)
            {
                result[row] = triangle[row][pathColumns[row]];
            }
            return result;
        }

        static void DrawTrianglePyramid(int[][] triangle, int maxRows = 25, string filename = "triangle_pyramid.png", int[] pathColumns = null)
        {
            Console.WriteLine($"\nCreating triangle pyramid image: {filename}");
            
            // Limit the display to prevent overwhelming output
            int rowsToShow = Math.Min(triangle.Length, maxRows);
            
            // Image settings
            int cellSize = 40;  // Size of each number cell
            int fontSize = 10;
            int imageWidth = rowsToShow * cellSize + 100;  // Extra padding
            int imageHeight = rowsToShow * cellSize + 100;
            
            using (Bitmap bitmap = new Bitmap(imageWidth, imageHeight))
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                // Set background color
                graphics.Clear(Color.White);
                
                // Set up font and brushes
                Font font = new Font("Arial", fontSize, FontStyle.Bold);
                Brush textBrush = new SolidBrush(Color.Black);
                Brush cellBrush = new SolidBrush(Color.LightBlue);
                Brush highlightBrush = new SolidBrush(Color.Gold);
                Pen cellPen = new Pen(Color.DarkBlue, 1);
                Pen highlightPen = new Pen(Color.Red, 3);
                
                // Center the triangle in the image
                int startX = imageWidth / 2;
                int startY = 50;
                
                // Build path coordinates for highlighting
                HashSet<(int row, int col)> pathCoords = null;
                if (pathColumns != null)
                {
                    pathCoords = new HashSet<(int row, int col)>();
                    for (int row = 0; row < Math.Min(pathColumns.Length, rowsToShow); row++)
                    {
                        pathCoords.Add((row, pathColumns[row]));
                    }
                }
                
                for (int row = 0; row < rowsToShow; row++)
                {
                    // Calculate starting position for this row to center it
                    int rowWidth = triangle[row].Length * cellSize;
                    int rowStartX = startX - (rowWidth / 2);
                    int rowY = startY + (row * cellSize);
                    
                    for (int col = 0; col < triangle[row].Length; col++)
                    {
                        int cellX = rowStartX + (col * cellSize);
                        int cellY = rowY;
                        
                        // Check if this cell is in the highlighted path
                        bool isHighlighted = pathCoords != null && pathCoords.Contains((row, col));
                        
                        // Draw cell background
                        Rectangle cellRect = new Rectangle(cellX, cellY, cellSize, cellSize);
                        graphics.FillRectangle(isHighlighted ? highlightBrush : cellBrush, cellRect);
                        graphics.DrawRectangle(isHighlighted ? highlightPen : cellPen, cellRect);
                        
                        // Draw number text
                        string numberText = triangle[row][col].ToString();
                        SizeF textSize = graphics.MeasureString(numberText, font);
                        float textX = cellX + (cellSize - textSize.Width) / 2;
                        float textY = cellY + (cellSize - textSize.Height) / 2;
                        
                        graphics.DrawString(numberText, font, textBrush, textX, textY);
                    }
                }
                
                // Add title
                Font titleFont = new Font("Arial", 16, FontStyle.Bold);
                string title = $"Project Euler 067 - Triangle Pyramid (Rows 1-{rowsToShow})";
                SizeF titleSize = graphics.MeasureString(title, titleFont);
                float titleX = (imageWidth - titleSize.Width) / 2;
                graphics.DrawString(title, titleFont, textBrush, titleX, 10);
                
                // Add info at bottom if there are more rows
                if (triangle.Length > maxRows)
                {
                    string infoText = $"... showing {rowsToShow} of {triangle.Length} total rows ...";
                    SizeF infoSize = graphics.MeasureString(infoText, font);
                    float infoX = (imageWidth - infoSize.Width) / 2;
                    float infoY = startY + (rowsToShow * cellSize) + 20;
                    graphics.DrawString(infoText, font, textBrush, infoX, infoY);
                }
                
                // Clean up resources
                font.Dispose();
                titleFont.Dispose();
                textBrush.Dispose();
                cellBrush.Dispose();
                highlightBrush.Dispose();
                cellPen.Dispose();
                highlightPen.Dispose();
                
                // Save the image
                bitmap.Save(filename, ImageFormat.Png);
            }
            
            Console.WriteLine($"Triangle pyramid image saved as: {filename}");
        }


    }
}
