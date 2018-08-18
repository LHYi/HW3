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
            int[] Angle = { 0, 8, 6, 2 };
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
                int count1 = 0;
                int count2 = 0;
                for (int i = 0; i < 3; i++)
                {
                    if (Board.XYCoordinate[i, i] == 1)
                    {
                        count1 += 100;
                    }
                    else if (Board.XYCoordinate[i, i] == -1)
                    {
                        count1 -= 200;
                    }
                    else if (Board.XYCoordinate[i, i] == 0)
                    {
                        ;
                    }
                    if (Board.XYCoordinate[i, 2 - i] == 1)
                    {
                        count2 += 100;
                    }
                    else if (Board.XYCoordinate[i, 2 - i] == -1)
                    {
                        count2 -= 200;
                    }
                    else if (Board.XYCoordinate[i, 2 - i] == 0)
                    {
                        ;
                    }
                    else if (Board.XYCoordinate[i, 0] == 0)
                    {
                        ;
                    }
                }
                if (count1 + count2 < 0)
                {
                    if (TempBoard[4] == 0)
                    {
                        TempBoard[4] = 1;
                        Transform.Invert(TempBoard, Board);
                        return;
                    }
                }
                else if (TempBoard[0] == 1 && TempBoard[1] == -1 && TempBoard[2] == 0)
                {
                    if (TempBoard[6] == 0)
                    {
                        TempBoard[6] = 1;
                        Transform.Invert(TempBoard, Board);
                        return;
                    }
                }
                else if (TempBoard[3] == -1)
                {
                    if (TempBoard[2] == 0)
                    {
                        TempBoard[2] = 1;
                        Transform.Invert(TempBoard, Board);
                        return;
                    }
                }
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
                    return;
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
