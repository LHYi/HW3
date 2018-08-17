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
        public class ChessBoard
        {
            public int[,] XYCoordinate = { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
        }
        ChessBoard Board = new ChessBoard();
        ChessBoard Name = new ChessBoard();
        bool PlayerIsComputer = true;
        private void button1_Click(object sender, EventArgs e)
        {
            if (Board.XYCoordinate[0, 0] != 0)
            {
                MessageBox.Show("点错地方啦！");
                return;
            }
            Board.XYCoordinate[0, 0] = -1;
            button1.Text = "X";
            if (IsWin() == 3)
            {
                ComputerMove();
            }
            else ShowResult();

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (Board.XYCoordinate[0, 1] != 0)
            {
                MessageBox.Show("点错地方啦！");
                return;
            }
            Board.XYCoordinate[0, 1] = -1;
            button2.Text = "X";
            if (IsWin() == 3)
            {
                ComputerMove();
            }
            else ShowResult();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (Board.XYCoordinate[0, 2] != 0)
            {
                MessageBox.Show("点错地方啦！");
                return;
            }
            Board.XYCoordinate[0, 2] = -1;
            button3.Text = "X";
            if (IsWin() == 3)
            {
                ComputerMove();
            }
            else ShowResult();

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            if (Board.XYCoordinate[1,0] != 0)
            {
                MessageBox.Show("点错地方啦！");
                return;
            }
            Board.XYCoordinate[1, 0] = -1;
            button4.Text = "X";
            if (IsWin() == 3)
            {
                ComputerMove();
            }
            else ShowResult();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            if (Board.XYCoordinate[1, 1] != 0)
            {
                MessageBox.Show("点错地方啦！");
                return;
            }
            Board.XYCoordinate[1, 1] = -1;
            button5.Text = "X";
            if (IsWin() == 3)
            {
                ComputerMove();
            }
            else ShowResult();
        }
        private void button6_Click_1(object sender, EventArgs e)
        {
            if (Board.XYCoordinate[1, 2] != 0)
            {
                MessageBox.Show("点错地方啦！");
                return;
            }
            Board.XYCoordinate[1, 2] = -1;
            button6.Text = "X";
            if (IsWin() == 3)
            {
                ComputerMove();
            }
            else ShowResult();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            if (Board.XYCoordinate[2,0] != 0)
            {
                MessageBox.Show("点错地方啦！");
                return;
            }
            Board.XYCoordinate[2, 0] = -1;
            button7.Text = "X";
            if (IsWin() == 3)
            {
                ComputerMove();
            }
            else ShowResult();
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            if (Board.XYCoordinate[2, 1] != 0)
            {
                MessageBox.Show("点错地方啦！");
                return;
            }
            Board.XYCoordinate[2, 1] = -1;
            button8.Text = "X";
            if (IsWin() == 3)
            {
                ComputerMove();
            }
            else ShowResult();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (Board.XYCoordinate[2, 2] != 0)
            {
                MessageBox.Show("点错地方啦！");
                return;
            }
            Board.XYCoordinate[2, 2] = -1;
            button9.Text = "X";
            if (IsWin() == 3)
            {
                ComputerMove();
            }
            else ShowResult();
        }
        bool IsBlank(int x, int y)
        {
            if (Board.XYCoordinate[x, y] == 0)
                return true;
            else
                return false;
        }

        void ComputerMove()
        {
            if(Choice.Get()==1)
            {
                EasyMove();                
            }
            else if(Choice.Get()==2 )
            {
                HardMove();
            }
            else
            {
                HellMove();
            }
            if (IsWin() == 3)
            {
                return;
            }
            else
            {
                ShowResult();
            }
        }

        int GetRandomMove()
        {
            Random ra = new Random(unchecked((int)DateTime.Now.Ticks));
            int x = ra.Next(0, 2);
            return x;
        }

        void EasyMove()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if(IsBlank(i,j))
                    {
                        Board.XYCoordinate[i, j] = 1;
                        ComputerPlayChangeButton(i, j);
                        return;
                    }
                }
            }
        }

        void FillTheOnlyBlankInLine(ChessBoard Board, int Line)//Man即将赢，下一步防守
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

            bool Defense()//下一步是否需要防守
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
                    FillTheOnlyBlankInLine(Board, i);
                    for(int k = 0; k < 3; k++)
                    {
                        if(Board.XYCoordinate[i,k]==1)
                        {
                            ComputerPlayChangeButton(i,k);
                        }
                    }
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
                    FillTheOnlyBlankInLine(Board, i+4);
                    for (int k = 0; k < 3; k++)
                    {
                        if (Board.XYCoordinate[k, i] == 1)
                        {
                            ComputerPlayChangeButton(k, i);
                        }
                    }
                    return true;
                }
            }
            if (Board.XYCoordinate[0, 0] + Board.XYCoordinate[1, 1] + Board.XYCoordinate[2, 2] == -2)
            {
                FillTheOnlyBlankInLine(Board, 7);
                for (int k = 0; k < 3; k++)
                {
                    if (Board.XYCoordinate[k, k] == 1)
                    {
                        ComputerPlayChangeButton(k, k);
                    }
                }
                return true;
            }
            if (Board.XYCoordinate[0, 2] + Board.XYCoordinate[1, 1] + Board.XYCoordinate[2, 0] == -2)
            {
                FillTheOnlyBlankInLine(Board, 8);
                for (int k = 0; k < 3; k++)
                {
                    if (Board.XYCoordinate[2-k, k] == 1)
                    {
                        ComputerPlayChangeButton(2-k, k);
                    }
                }
                return true;
            }
            return false;
        }
        bool Attack()//下一步是否进攻
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
                    FillTheOnlyBlankInLine(Board, i);
                    for (int k = 0; k < 3; k++)
                    {                       
                            ComputerPlayChangeButton(i, k);                      
                    }
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
                    FillTheOnlyBlankInLine(Board, i+4);
                    for (int k = 0; k < 3; k++)
                    {
                        ComputerPlayChangeButton(k, i);
                    }
                    return true;
                }
            }
            if (Board.XYCoordinate[0, 0] + Board.XYCoordinate[1, 1] + Board.XYCoordinate[2, 2] == 2)
            {
                FillTheOnlyBlankInLine(Board,7);
                for (int k = 0; k < 3; k++)
                {
                    ComputerPlayChangeButton(k, k);
                }
                return true;
            }
            if (Board.XYCoordinate[0, 2] + Board.XYCoordinate[1, 1] + Board.XYCoordinate[2, 0] == 2)
            {
                FillTheOnlyBlankInLine(Board,8);
                for (int k = 0; k < 3; k++)
                {
                    ComputerPlayChangeButton(2-k, k);
                }
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
                return;
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
        void HellMove()//最高难度级别电脑判定如何下棋
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
                        for (int x = 0; x < 3; x++)
                        {
                            for (int y = 0; y < 3; y++)
                            {
                                if(Board.XYCoordinate[x,y]==1)
                                {
                                    ComputerPlayChangeButton(x, y);
                                }
                            }
                        }


                        return;
                    }
                }
                if (TempBoard[4] == 0)
                {
                    TempBoard[4] = 1;
                    InvertTransform(TempBoard);
                    ComputerPlayChangeButton(2, 2);
                }
                for (int i = 0; i < 4; i++)
                {
                    if (TempBoard[Side[i]] == 0)
                    {
                        TempBoard[Side[i]] = 1;
                        InvertTransform(TempBoard);
                        for (int x = 0; x < 3; x++)
                        {
                            for (int y = 0; y < 3; y++)
                            {
                                if (Board.XYCoordinate[x, y] == 1)
                                {
                                    ComputerPlayChangeButton(x, y);
                                }
                            }
                        }
                        return;
                    }
                }
            }
        }

       // void Refresh()

        void ComputerPlayChangeButton(int i, int j)//电脑下棋后改变棋盘数组及按钮显示
        {
            switch  (i)
            {
                case 0:
                    switch (j)
                    {
                        case 0:
                            Board.XYCoordinate[0, 0] = 1;
                            button1.Text = "O";
                            break;
                        case 1:
                            Board.XYCoordinate[0,1] = 1;
                            button2.Text = "O";
                            break;
                        case 2:
                            Board.XYCoordinate[0, 2] = 1;
                            button3.Text = "O";
                            break;
                    }
                    break;
                case 1:
                    switch (j)
                    {
                        case 0:
                            Board.XYCoordinate[1, 0] = 1;
                            button4.Text = "O";
                            break;
                        case 1:
                            Board.XYCoordinate[1, 1] = 1;
                            button5.Text = "O";
                            break;
                        case 2:
                            Board.XYCoordinate[1, 2] = 1;
                            button6.Text = "O";
                            break;
                    }
                    break;
                case 2:
                    switch (j)
                    {
                        case 0:
                            Board.XYCoordinate[2, 0] = 1;
                            button7.Text = "O";
                            break;
                        case 1:
                            Board.XYCoordinate[2, 1] = 1;
                            button8.Text = "O";
                            break;
                        case 2:
                            Board.XYCoordinate[2, 2] = 1;
                            button9.Text = "O";
                            break;
                    }
                    break;
            }
        }
       public int IsWin()
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
                {
                    return ComputerWin;
                }
                else if (count == -3)
                {
                    return ManWin;
                }
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
                    if (IsBlank(i, j))
                    {
                        return GoOn;
                    }
                }
            }
            return Draw;
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
            ComputerMove();
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
            System.Windows.Forms.Application.Restart();
        }

        public void ShowResult()
        {
            if (IsWin() == 1)
            {
                MessageBox.Show("Clever Dude  !");
                Write("输啦\r\n");
            }
            if (IsWin() == 2)
            {
                MessageBox.Show("WinnerWinner  ChickenDinner ！");
                Write("赢咯\r\n");
            }
            if (IsWin() == 0)
            {
                MessageBox.Show("Almost Won !");
                Write("打平了\r\n");
            }

        }
        public void Write(string text)
        {
            FileStream fs = new FileStream("W:\\JinChess\\Chess\\GameResults.txt", FileMode.Append);
            StreamWriter sw = new StreamWriter(fs, Encoding.UTF8 );
            sw.Write(text);
            sw.Close();
            fs.Close();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            //  OpenFileDialog ofd = new OpenFileDialog();
            //  ofd.ShowDialog();
            //  string path = ofd.FileName;
            textBox1.Text = File.ReadAllText("W:\\JinChess\\Chess\\GameResults.txt");   
        }
    }
}
