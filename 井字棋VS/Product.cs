using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace ProductsApp.Models
{
    public class ChessBoard
    {
        public int[,] XYCoordinate = { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
        readonly bool PlayerIsComputer = true;

        public bool IsBlank(int x, int y)
        {
            if (XYCoordinate[x, y] == 0)
                return true;
            else
                return false;
        }

        public int GetRandomMove()
        {
            Random ra = new Random(unchecked((int)DateTime.Now.Ticks));
            int x = ra.Next(0, 2);
            return x;
        }

        void RecordMove(int x, int y, bool player)
        {
            //Computer=1 Man=0
            if (player)
            {
                XYCoordinate[x, y] = 1;
            }
            else
                XYCoordinate[x, y] = -1;
        }

        public void EasyMove()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (IsBlank(i, j))
                    {
                        XYCoordinate[i, j] = 1;
                        RecordMove(i, j, PlayerIsComputer);
                        return;
                    }
                }
            }           
        }

        public void FillTheOnlyBlankInLine(ChessBoard Board, int Line)
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