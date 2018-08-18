using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class HardMove
    {
        public static void Move(ChessBoard Board)
        {
            if (Attack.Do(Board))
            {
                return;
            }
            else if (Defend.Do(Board))
            {
                return;
            }
            else
            {
                EasyMove.Move(Board);
                return;
            }
        }
    }
}
