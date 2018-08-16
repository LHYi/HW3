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
        bool PlayerIsComputer = true;

        bool IsBlank(int x, int y)
        {
            if (Board.XYCoordinate[x, y] == 0)
                return true;
            else
                return false;
        }

        int IsWin()
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
                    if (IsBlank(i,j))
                    {
                        return GoOn;
                    }
                }
            }
            return Draw;
        }

        void RecordMove(int x, int y,bool player)
        {
            //Computer=1 Man=0
            if (player)
            {
                Board.XYCoordinate[x, y] = 1;
            }
            else
                Board.XYCoordinate[x, y] = -1;
        }

        int GetRandomMove()
        {
            Random ra = new Random(unchecked((int)DateTime.Now.Ticks));
            int x = ra.Next(0, 2);
            return x;
        }

        void EasyMove()
        {
            
            int x = 0;
            int y = 0;
            while(true)
            {
                x = GetRandomMove();
                y = GetRandomMove();
                if (IsBlank(x, y, Board.XYCoordinate))
                {
                    Board.XYCoordinate[x, y] = 1;
                    break;
                }
            }
            RecordMove(x, y, PlayerIsComputer);
        }

        void FillTheOnlyBlankInLine(int a, int b, int c)
        {
            if (a != 0 && b != 0 && c == 0)
            {
                c = 1;
            }
            else if (a != 0 && b == 0 && c != 0)
            {
                b = 1;
            }
            else if (a == 0 && b != 0 && c != 0)
            {
                a = 1;
            }
        }

        bool Defense()
        {           
            for(int i = 0; i < 3; i++)
            {
                int count = 0;
                for (int j = 0; j < 3; j++)
                {
                    count += Board.XYCoordinate[i, j];
                }
                if(count == -2)
                {
                    FillTheOnlyBlankInLine(Board.XYCoordinate[i, 0], Board.XYCoordinate[i, 1], Board.XYCoordinate[i, 2]);
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
                    FillTheOnlyBlankInLine(Board.XYCoordinate[0,i], Board.XYCoordinate[1,i], Board.XYCoordinate[2,i]);
                    return true;
                }
            }
            if(Board.XYCoordinate[0,0] + Board.XYCoordinate[1,1] + Board.XYCoordinate[2,2] == -2)
            {
                FillTheOnlyBlankInLine(Board.XYCoordinate[0, 0], Board.XYCoordinate[1, 1], Board.XYCoordinate[2, 2]);
                return true;
            }
            if (Board.XYCoordinate[0, 2] + Board.XYCoordinate[1, 1] + Board.XYCoordinate[2, 0] == -2)
            {
                FillTheOnlyBlankInLine(Board.XYCoordinate[0, 2], Board.XYCoordinate[1, 1], Board.XYCoordinate[2, 0]);
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
                    FillTheOnlyBlankInLine(Board.XYCoordinate[i, 0], Board.XYCoordinate[i, 1], Board.XYCoordinate[i, 2]);
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
                    FillTheOnlyBlankInLine(Board.XYCoordinate[0, i], Board.XYCoordinate[1, i], Board.XYCoordinate[2, i]);
                    return true;
                }
            }
            if (Board.XYCoordinate[0, 0] + Board.XYCoordinate[1, 1] + Board.XYCoordinate[2, 2] == 2)
            {
                FillTheOnlyBlankInLine(Board.XYCoordinate[0, 0], Board.XYCoordinate[1, 1], Board.XYCoordinate[2, 2]);
                return true;
            }
            if (Board.XYCoordinate[0, 2] + Board.XYCoordinate[1, 1] + Board.XYCoordinate[2, 0] == 2)
            {
                FillTheOnlyBlankInLine(Board.XYCoordinate[0, 2], Board.XYCoordinate[1, 1], Board.XYCoordinate[2, 0]);
                return true;
            }
            return false;
        }

        void HardMove()
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
                EasyMove();
            }
        }

        int[] Transform()
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

        void InvertTransform( int[] TempBoard)
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
        void HellMove()
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