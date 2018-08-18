using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Transform
    {
        public static int[] Trans(ChessBoard Board)
        {
            int[] TempBoard = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int counter = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    TempBoard[counter] = Board.XYCoordinate[i, j];
                    counter++;
                }
            }
            return TempBoard;
        }
        public static void Invert(int[] TempBoard, ChessBoard Board)
        {
            int counter = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Board.XYCoordinate[i, j] = TempBoard[counter];
                    counter++;
                }
            }
        }
    }
}
