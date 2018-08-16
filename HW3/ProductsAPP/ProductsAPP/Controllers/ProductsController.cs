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
        public int Level = 0;

        void PutRenew()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Board.XYCoordinate[i, j]=0;
                }
            }
        }

        void PutSetLevel(int Choice)
        {
            Level = Choice;
        }

        int GetIsWin()
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

        void PutRecordMove(int x, int y)
        {            
            Board.XYCoordinate[x, y] = -1;
        }                                                       
        
        void PutMove()
        {
            if(Level==0)
            {
                Board.EasyMove();
            }
            else if(Level==1)
            {
                Board.HardMove();
            }
            else if(Level==2)
            {
                Board.HellMove();
            }
        }

    }
}