using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class ComputerMove
    {
        public static void Move(ChooseLevel Choice, ChessBoard Board)
        {
            if (Choice.Get() == 1)
            {
                EasyMove.Move(Board);
            }
            else if (Choice.Get() == 2)
            {
                HardMove.Move(Board);
            }
            else
            {
                HellMove.Move(Board);
            }
        }
    }
}
