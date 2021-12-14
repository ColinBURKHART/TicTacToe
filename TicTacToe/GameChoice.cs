using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class GameChoice
    {
        public void start_playing()
        {
        }



        // -------------------------------------------------TicTacToe--------------------------------------------------
        public void PlayTicTacToe()
        {
            TicTacToe game = new TicTacToe(3, 3);
            int turn = 0;
            int player_turn = 1;
            int location;
            while (!game.win(1) && !game.win(2) && turn < TicTacToe.boxes)
            {
                game.display_grid();
                Console.WriteLine("Player " + player_turn);
                while (!int.TryParse(Console.ReadLine(), out location))
                {
                    Console.WriteLine("Choose a number");
                }

                while ((location < 1 || location > TicTacToe.boxes) || !game.empty_box(location))
                {
                    if (location < 1 || location > TicTacToe.boxes)
                    {
                        while (!int.TryParse(Console.ReadLine(), out location))
                        {
                            Console.WriteLine("Choose a box");
                        }
                    }
                    else
                    {
                        while (!int.TryParse(Console.ReadLine(), out location))
                        {
                            Console.WriteLine("Choose a empty box");
                        }
                    }

                }

                game.put_coin(player_turn, location);
                if (player_turn == 1)
                {
                    player_turn = 2;
                }
                else
                {
                    player_turn = 1;
                }

                turn++;

            }

            if (game.win(1))
            {
                game.display_grid();
                Console.WriteLine("Player 1 won");
            }
            else if (game.win(2))
            {
                game.display_grid();
                Console.WriteLine("Player 2 won");
            }
            else
            {
                game.display_grid();
                Console.WriteLine("draw");
            }
        }


        // ------------------------------------------------Connect4--------------------------------------------
        public void PlayConnect4()
        {
            Connect4 game = new Connect4(4, 7);
            int turn = 0;
            int player_turn = 1;
            int location;
            while (!game.win(1) && !game.win(2) && turn < Connect4.boxes)
            {
                game.display_grid();
                Console.WriteLine("Player " + player_turn);
                while (!int.TryParse(Console.ReadLine(), out location))
                {
                    Console.WriteLine("Choose a number");
                }

                while ((location < 1 || location > Connect4.width_grid) || !game.check_column(location))
                {
                    if (location < 1 || location > Connect4.width_grid)
                    {
                        while (!int.TryParse(Console.ReadLine(), out location))
                        {
                            Console.WriteLine("Choose a number");
                        }
                    }
                    else
                    {
                        while (!int.TryParse(Console.ReadLine(), out location))
                        {
                            Console.WriteLine("Choose a number");
                        }
                    }

                }

                game.put_coin(player_turn, location);
                if (player_turn == 1)
                {
                    player_turn = 2;
                }
                else
                {
                    player_turn = 1;
                }

                turn++;

            }

            if (game.win(1))
            {
                game.display_grid();
                Console.WriteLine("Player 1 win");
            }
            else if (game.win(2))
            {
                game.display_grid();
                Console.WriteLine("Player 2 win");
            }
            else
            {
                game.display_grid();
                Console.WriteLine("Draw");
            }
        }
    }
}

    
