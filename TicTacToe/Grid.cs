using System;

namespace TicTacToe
{
    internal abstract class Grid
    {
        protected int[,] grid;
        public static int height_grid;
        public static int width_grid;
        public static int boxes;

        public Grid(int height, int width)
        {
            grid = new int[height , width];
            height_grid = height;
            width_grid = width;
            boxes = grid.Length;
        }

        public void display_grid()
        {
            for (int i = 0; i < height_grid; i++)
            {
                for (int y = 0; y < width_grid; y++)
                {
                    Console.Write(grid[i, y] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}