

namespace TicTacToe
{
    internal class Connect4: Grid
    {
        public Connect4(int height, int width) : base(height, width)
        {
        }

        public bool check_column(int column)
        {
            column = column - 1;
            if (grid[0, column] == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void put_coin(int player, int column)
        {
            column = column - 1;
            for (int n = 0; n < height_grid; n++)
            {
                if (grid[n, column] == 0)
                {
                    if (n + 1 < height_grid)
                    {
                        if (grid[n + 1, column] != 0)
                        {
                            grid[n, column] = player;
                        }
                    }
                }
            }
            if (grid[height_grid - 1, column] == 0)
            {
                grid[height_grid - 1, column] = player;
            }
        }

        public bool full_line(int player, int line)
        {
            int validator = 0;
            for (int n = 0; n < width_grid; n++)
            {
                if (grid[line, n] == player)
                {
                    validator++;
                }
                else
                {
                    validator = 0;
                }
                if (validator == 4)
                {
                    return true;
                }
            }
            return false;
        }

        public bool full_column(int player, int column)
        {
            int validator = 0;
            for (int n = 0; n < height_grid; n++)
            {
                if (grid[n, column] == player)
                {
                    validator++;
                }
                else
                {
                    validator = 0;
                }
                if (validator == 4)
                {
                    return true;
                }
            }
            return false;
        }

        public bool full_diagonal(int player)
        {
            for (int n = 0; n < boxes; n++)
            {
                int line = n / width_grid;
                int column = n % width_grid;
                int first_diagonal_validator = 0;
                int scd_diagonal_validator = 0;
                if (grid[line, column] == player)
                {
                    first_diagonal_validator++;
                    scd_diagonal_validator++;
                }
                for (int j = 1; j <= 4; j++)
                {
                    if (line + j < height_grid && column + j < width_grid)
                    {
                        if (grid[line + j, column + j] == player)
                        {
                            first_diagonal_validator++;
                        }
                    }
                    if (line - j >= 0 && column + j < width_grid)
                    {
                        if (grid[line - j, column + j] == player)
                        {
                            scd_diagonal_validator++;
                        }
                    }
                }
                if (first_diagonal_validator == 4 || scd_diagonal_validator == 4)
                {
                    return true;
                }
                first_diagonal_validator= 0;
                scd_diagonal_validator = 0;
            }
            return false;
        }

        public bool win(int player)
        {
            for (int n = 0; n < height_grid; n++)
            {
                if (full_line(player, n))
                {
                    return true;
                }
            }
            for (int n = 0; n < width_grid; n++)
            {
                if (full_column(player, n))
                {
                    return true;
                }
            }
            if (full_diagonal(player))
            {
                return true;
            }
            return false;
        }
    }
}