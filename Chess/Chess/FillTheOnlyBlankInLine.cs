using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class FillTheOnlyBlankInLine
    {
        public static void Do(ChessBoard Board, int Line)
        {
            if (Line == 1 || Line == 2 || Line == 3)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (Board.XYCoordinate[Line, i] == 0)
                    {
                        Board.XYCoordinate[Line, i] = 1;
                    }
                }
            }
            if (Line == 4 || Line == 5 || Line == 6)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (Board.XYCoordinate[i, Line - 4] == 0)
                    {
                        Board.XYCoordinate[i, Line - 4] = 1;
                    }
                }
            }
            if (Line == 7)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (Board.XYCoordinate[i, i] == 0)
                    {
                        Board.XYCoordinate[i, i] = 1;
                    }
                }
            }
            if (Line == 8)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (Board.XYCoordinate[i, 2 - i] == 0)
                    {
                        Board.XYCoordinate[i, 2 - i] = 1;
                    }
                }
            }
        }
    }
}
