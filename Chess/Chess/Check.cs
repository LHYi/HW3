using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    public class Check
    {
        public static bool CanClick(ChessBoard Board, int x, int y)
        {
            if (Board.XYCoordinate[x, y] != 0)
            {
                Print.ShowWrong();
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool IsBlank(ChessBoard Board, int x, int y)
        {
            if (Board.XYCoordinate[x, y] == 0)
                return true;
            else
                return false;
        }

        public static int IsWin(ChessBoard Board)
        {
            int Draw = 0;
            int ComputerWin = 1;
            int ManWin = 2;
            int GoOn = 3;
            for (int i = 0; i < 3; i++)
            {
                int count = 0;
                for (int j = 0; j < 3; j++)
                {
                    count += Board.XYCoordinate[i, j];
                }
                if (count == 3)
                {
                    return ComputerWin;
                }
                else if (count == -3)
                {
                    return ManWin;
                }
            }
            for (int i = 0; i < 3; i++)
            {
                int count = 0;
                for (int j = 0; j < 3; j++)
                {
                    count += Board.XYCoordinate[j, i];
                }
                if (count == 3)
                    return ComputerWin;
                else if (count == -3)
                    return ManWin;
            }
            if (Board.XYCoordinate[0, 2] + Board.XYCoordinate[1, 1] + Board.XYCoordinate[2, 0] == 3 || Board.XYCoordinate[0, 0] + Board.XYCoordinate[1, 1] + Board.XYCoordinate[2, 2] == 3)
                return ComputerWin;
            else if (Board.XYCoordinate[0, 2] + Board.XYCoordinate[1, 1] + Board.XYCoordinate[2, 0] == -3 || Board.XYCoordinate[0, 0] + Board.XYCoordinate[1, 1] + Board.XYCoordinate[2, 2] == -3)
                return ManWin;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (IsBlank(Board, i, j))
                    {
                        return GoOn;
                    }
                }
            }
            return Draw;
        }



    }

}
