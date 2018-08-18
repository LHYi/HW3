using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class ChessBoard
    {
        public int[,] XYCoordinate = { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
        public int InputX;
        public int InputY;

        public void SetMove(int x, int y, ChessBoard Board, bool Player)
        {
            if(Player == true)
            {
                Board.XYCoordinate[x, y] = 1;
            }
            else
            {
                Board.XYCoordinate[x, y] = -1;
            }            
        }



    }
}
