using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class EasyMove
    {
        public static void Move(ChessBoard Board)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (Check.IsBlank(Board, i, j))
                    {
                        Board.XYCoordinate[i, j] = 1;                        
                        return;
                    }
                }
            }
        }
    }
}
