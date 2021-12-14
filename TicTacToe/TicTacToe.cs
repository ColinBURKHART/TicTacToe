using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class TicTacToe : Grid
    {
        public TicTacToe(int height, int width) : base(height, width)
        {
        }

        public bool empty_box(int box_location)
        {
            box_location = box_location - 1;
            if (grid[box_location / width_grid, box_location % width_grid] == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void put_coin(int player, int box_nb)
        {
            box_nb = box_nb - 1;
            grid[box_nb / width_grid, box_nb % width_grid] = player;
        }

        public bool full_line(int player, int line)
        {
            for (int n = 0; n < width_grid; n++)
            {
                if (grid[line, n] != player)
                {
                    return false;
                }
            }

            return true;
        }

        public bool full_column(int player, int column)
        {
            for (int n = 0; n < height_grid; n++)
            {
                if (grid[n, column] != player)
                {
                    return false;
                }
            }

            return true;
        }

        public bool full_diagonal(int player, int diagonal)
        {
            if (diagonal == 1)
            {
                if ((grid[0, 0] == player) && (grid[1, 1] == player) && (grid[2, 2] == player))
                {
                    return true;
                }

                return false;
            }
            else
            {
                if ((grid[2, 2] == player) && (grid[1, 1] == player) && (grid[0, 0] == player))
                {
                    return true;
                }

                return false;
            }
        }

        public bool win(int player)
        {
            for (int n = 0; n < width_grid; n++)
            {
                if (full_line(player, n))
                {
                    return true;
                }
            }

            for (int n = 0; n < height_grid; n++)
            {
                if (full_diagonal(player, n))
                {
                    return true;
                }
            }

            if (full_diagonal(player, 1) || full_diagonal(player, 2))
            {
                return true;
            }

            return false;
        }
    }
}
