using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Defend
    {
        public static bool Do(ChessBoard Board)
        {
            for (int i = 0; i < 3; i++)
            {
                int count = 0;
                for (int j = 0; j < 3; j++)
                {
                    count += Board.XYCoordinate[i, j];
                }
                if (count == -2)
                {
                    FillTheOnlyBlankInLine.Do(Board, i);
                    return true;
                }
            }
            for (int i = 0; i < 3; i++)
            {
                int count = 0;
                for (int j = 0; j < 3; j++)
                {
                    count += Board.XYCoordinate[j, i];
                }
                if (count == -2)
                {
                    FillTheOnlyBlankInLine.Do(Board, i + 4);
                    return true;
                }
            }
            if (Board.XYCoordinate[0, 0] + Board.XYCoordinate[1, 1] + Board.XYCoordinate[2, 2] == -2)
            {
                FillTheOnlyBlankInLine.Do(Board, 7);
                return true;
            }
            if (Board.XYCoordinate[0, 2] + Board.XYCoordinate[1, 1] + Board.XYCoordinate[2, 0] == -2)
            {
                FillTheOnlyBlankInLine.Do(Board, 8);
                return true;
            }
            return false;
        }
    }
}
