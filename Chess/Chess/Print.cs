using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    public class Print
    {
        public static void ShowWrong()
        {
            MessageBox.Show("点错地方啦！");
        }

        public static void ShowResult(ChessBoard Board)
        {
            if (Check.IsWin(Board) == 1)
            {
                MessageBox.Show("Clever Dude  !");
                History.Save("输啦\r\n");
            }
            if (Check.IsWin(Board) == 2)
            {
                MessageBox.Show("WinnerWinner  ChickenDinner ！");
                History.Save("赢咯\r\n");
            }
            if (Check.IsWin(Board) == 0)
            {
                MessageBox.Show("Almost Won !");
                History.Save("打平了\r\n");
            }
            return;
        }

    }
}
