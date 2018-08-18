using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Chess
{

    public partial class GameInterface : Form
    {
        public GameInterface()
        {
            InitializeComponent();
        }
        public ChooseLevel Choice = new ChooseLevel();
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Choice.Set(1);
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Choice.Set(2);
        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            Choice.Set(3);
        }
        ChessBoard Board = new ChessBoard();
        ChessBoard Name = new ChessBoard();
        private void button1_Click(object sender, EventArgs e)
        {

            if(Check.CanClick(Board, 0, 0))
            {
                Board.XYCoordinate[0, 0] = -1;
                Refresh(Board);
                if (Check.IsWin(Board) == 3)
                {
                    ComputerMove.Move(Choice, Board);
                    Refresh(Board);
                    Print.ShowResult(Board);
                }
                else Print.ShowResult(Board);
            }                                    

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (Check.CanClick(Board, 0, 1))
            {
                Board.XYCoordinate[0, 1] = -1;
                Refresh(Board);
                if (Check.IsWin(Board) == 3)
                {
                    ComputerMove.Move(Choice, Board);
                    Refresh(Board);
                    Print.ShowResult(Board);
                }
                else Print.ShowResult(Board);
            }            
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (Check.CanClick(Board, 0, 2))
            {
                Board.XYCoordinate[0, 2] = -1;
                Refresh(Board);
                if (Check.IsWin(Board) == 3)
                {
                    ComputerMove.Move(Choice, Board);
                    Refresh(Board);
                    Print.ShowResult(Board);
                }
                else Print.ShowResult(Board);
            }

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            if (Check.CanClick(Board, 1, 0))
            {
                Board.XYCoordinate[1, 0] = -1;
                Refresh(Board);
                if (Check.IsWin(Board) == 3)
                {
                    ComputerMove.Move(Choice, Board);
                    Refresh(Board);
                    Print.ShowResult(Board);
                }
                else Print.ShowResult(Board);
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            if (Check.CanClick(Board, 1, 1))
            {
                Board.XYCoordinate[1, 1] = -1;
                Refresh(Board);
                if (Check.IsWin(Board) == 3)
                {
                    ComputerMove.Move(Choice, Board);
                    Refresh(Board);
                    Print.ShowResult(Board);
                }
                else Print.ShowResult(Board);
            }
        }
        private void button6_Click_1(object sender, EventArgs e)
        {
            if (Check.CanClick(Board, 1, 2))
            {
                Board.XYCoordinate[1, 2] = -1;
                Refresh(Board);
                if (Check.IsWin(Board) == 3)
                {
                    ComputerMove.Move(Choice, Board);
                    Refresh(Board);
                    Print.ShowResult(Board);
                }
                else Print.ShowResult(Board);
            }
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            if (Check.CanClick(Board, 2, 0))
            {
                Board.XYCoordinate[2, 0] = -1;
                Refresh(Board);
                if (Check.IsWin(Board) == 3)
                {
                    ComputerMove.Move(Choice, Board);
                    Refresh(Board);
                    Print.ShowResult(Board);
                }
                else Print.ShowResult(Board);
            }
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            if (Check.CanClick(Board, 2, 1))
            {
                Board.XYCoordinate[2, 1] = -1;
                Refresh(Board);
                if (Check.IsWin(Board) == 3)
                {
                    ComputerMove.Move(Choice, Board);
                    Refresh(Board);
                    Print.ShowResult(Board);
                }
                else Print.ShowResult(Board);
            }            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (Check.CanClick(Board, 2, 2))
            {
                Board.XYCoordinate[2, 2] = -1;
                Refresh(Board);
                if (Check.IsWin(Board) == 3)
                {
                    ComputerMove.Move(Choice, Board);
                    Refresh(Board);
                    Print.ShowResult(Board);
                }
                else Print.ShowResult(Board);
            }
        }     

        public void ShowX(int i, int j)
        {
            switch (i)
            {
                case 0:
                    switch (j)
                    {
                        case 0:
                            button1.Text = "X";
                            break;
                        case 1:
                            button2.Text = "X";
                            break;
                        case 2:
                            button3.Text = "X";
                            break;
                    }
                    break;
                case 1:
                    switch (j)
                    {
                        case 0:
                            button4.Text = "X";
                            break;
                        case 1:
                            button5.Text = "X";
                            break;
                        case 2:
                            button6.Text = "X";
                            break;
                    }
                    break;
                case 2:
                    switch (j)
                    {
                        case 0:
                            button7.Text = "X";
                            break;
                        case 1:
                            button8.Text = "X";
                            break;
                        case 2:
                            button9.Text = "X";
                            break;
                    }
                    break;
            }
        }

        public void ShowO(int i, int j)
        {
            switch (i)
            {
                case 0:
                    switch (j)
                    {
                        case 0:
                            button1.Text = "O";
                            break;
                        case 1:
                            button2.Text = "O";
                            break;
                        case 2:
                            button3.Text = "O";
                            break;
                    }
                    break;
                case 1:
                    switch (j)
                    {
                        case 0:
                            button4.Text = "O";
                            break;
                        case 1:
                            button5.Text = "O";
                            break;
                        case 2:
                            button6.Text = "O";
                            break;
                    }
                    break;
                case 2:
                    switch (j)
                    {
                        case 0:
                            button7.Text = "O";
                            break;
                        case 1:
                            button8.Text = "O";
                            break;
                        case 2:
                            button9.Text = "O";
                            break;
                    }
                    break;
            }
        }

        public void Refresh (ChessBoard Board)
        {
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    if(Board.XYCoordinate[i,j]==1)
                    {
                        ShowO(i, j);
                    }
                    else if(Board.XYCoordinate[i,j]==-1)
                    {
                        ShowX(i, j);
                    }
                }
            }
        }        

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (Board.XYCoordinate[i, j] == 1 || Board.XYCoordinate[i, j] == -1)
                        return;
                }
            }
            ComputerMove.Move(Choice, Board);
            Refresh(Board);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            InitializeComponent();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Board.XYCoordinate[i, j] = 0;
                }
            }
        }
        private void button14_Click(object sender, EventArgs e)
        {
            MainInterface Back = new MainInterface();
            //System.Windows.Forms.Application.Restart();
            Back.Show();
            this.Hide();
        }
        
        private void button15_Click(object sender, EventArgs e)
        {
            //  OpenFileDialog ofd = new OpenFileDialog();
          //   ofd.ShowDialog();
            //  string path = ofd.FileName;
            textBox1.Text = History.Load();
        }

        private void GameInterface_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
