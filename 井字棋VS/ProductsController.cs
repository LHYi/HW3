using ProductsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace ProductsApp.Controllers
{
    public class ProductsController : ApiController
    {
        ChessBoard Board = new ChessBoard();
        readonly bool PlayerIsComputer = true;
        public string Level = "0";

        public void PutRenew()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Board.XYCoordinate[i, j]=0;
                }
            }
        }

        public void PutSetLevel(string Choice)
        {
            string Level = Choice;
        }

        public int GetIsWin()
        {           
            int ComputerWin = 1;
            int ManWin = 2;
            int Draw = 0;
            int GoOn = 3;
            for (int i = 0; i < 3; i++)
            {
                int count = 0;
                for (int j = 0; j < 3; j++)
                {
                    count += Board.XYCoordinate[i, j];
                }
                if (count == 3)
                    return ComputerWin;
                else if (count == -3)
                    return ManWin;
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
                    if (Board.IsBlank(i,j))
                    {
                        return GoOn;
                    }
                }
            }
            return Draw;
        }

        public void PutRecordMove(string[] Move)
        {
            int x;
            int.TryParse(Move[0], out x);
            int y;
            int.TryParse(Move[1], out y);            
            Board.XYCoordinate[x, y] = -1;
        }                                                       
        
        public void PutMove()
        {
            if(Level=="0")
            {
                Board.EasyMove();
            }
            else if(Level=="1")
            {
                HardMove();
            }
            else if(Level=="2")
            {
                HellMove();
            }
        }

        public int[] GetBoard()
        {
            int[] TempBoard = Transform();
            return TempBoard;
        }

        bool Defense()
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
                    Board.FillTheOnlyBlankInLine(Board, i);
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
                    Board.FillTheOnlyBlankInLine(Board, 2-i);
                    return true;
                }
            }
            if (Board.XYCoordinate[0, 0] + Board.XYCoordinate[1, 1] + Board.XYCoordinate[2, 2] == -2)
            {
                Board.FillTheOnlyBlankInLine(Board, 7);
                return true;
            }
            if (Board.XYCoordinate[0, 2] + Board.XYCoordinate[1, 1] + Board.XYCoordinate[2, 0] == -2)
            {
                Board.FillTheOnlyBlankInLine(Board, 8);
                return true;
            }
            return false;
        }

        bool Attack()
        {
            for (int i = 0; i < 3; i++)
            {
                int count = 0;
                for (int j = 0; j < 3; j++)
                {
                    count += Board.XYCoordinate[i, j];
                }
                if (count == 2)
                {
                    Board.FillTheOnlyBlankInLine(Board, i);
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
                if (count == 2)
                {
                    Board.FillTheOnlyBlankInLine(Board, 2-i);
                    return true;
                }
            }
            if (Board.XYCoordinate[0, 0] + Board.XYCoordinate[1, 1] + Board.XYCoordinate[2, 2] == 2)
            {
                Board.FillTheOnlyBlankInLine(Board, 7);
                return true;
            }
            if (Board.XYCoordinate[0, 2] + Board.XYCoordinate[1, 1] + Board.XYCoordinate[2, 0] == 2)
            {
                Board.FillTheOnlyBlankInLine(Board, 8);
                return true;
            }
            return false;
        }

        public void HardMove()
        {
            if (Attack())
            {
                return;
            }
            else if (Defense())
            {
                return;
            }
            else
            {
                Board.EasyMove();
            }
        }

        public int[] Transform()
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

        void InvertTransform(int[] TempBoard)
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

        public void HellMove()
        {
            int[] Angle = { 0, 2, 6, 8 };
            int[] Side = { 1, 3, 5, 7 };

            if (Attack())
            {
                return;
            }
            else if (Defense())
            {
                return;
            }
            else
            {
                int[] TempBoard = Transform();
                for (int i = 0; i < 4; i++)
                {
                    if (TempBoard[Angle[i]] == 0)
                    {
                        TempBoard[Angle[i]] = 1;
                        InvertTransform(TempBoard);
                        return;
                    }
                }
                if (TempBoard[4] == 0)
                {
                    TempBoard[4] = 1;
                    InvertTransform(TempBoard);
                }
                for (int i = 0; i < 4; i++)
                {
                    if (TempBoard[Side[i]] == 0)
                    {
                        TempBoard[Side[i]] = 1;
                        InvertTransform(TempBoard);
                        return;
                    }
                }
            }
        }

    }
}