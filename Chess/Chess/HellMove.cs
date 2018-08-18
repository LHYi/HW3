using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class HellMove
    {
        public static void Move(ChessBoard Board)
        {
            int[] Angle = { 0, 2, 6, 8 };
            int[] Side = { 1, 3, 5, 7 };
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
                int[] TempBoard = Transform.Trans(Board);
                for (int i = 0; i < 4; i++)
                {
                    if (TempBoard[Angle[i]] == 0)
                    {
                        TempBoard[Angle[i]] = 1;
                        Transform.Invert(TempBoard,Board);
                        return;
                    }
                }
                if (TempBoard[4] == 0)
                {
                    TempBoard[4] = 1;
                    Transform.Invert(TempBoard,Board);
                }
                for (int i = 0; i < 4; i++)
                {
                    if (TempBoard[Side[i]] == 0)
                    {
                        TempBoard[Side[i]] = 1;
                        Transform.Invert(TempBoard,Board);
                        return;
                    }
                }
            }
        }
    }
}
