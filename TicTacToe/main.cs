using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class main
    {
        static void Main(String[] args)
        {
            GameChoice party = new GameChoice();
            party.PlayConnect4();
        }
    }
}