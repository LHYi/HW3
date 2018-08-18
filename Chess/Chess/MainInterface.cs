using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    public partial class MainInterface : Form
    {

        public MainInterface()
        {
            InitializeComponent();
        }

        private void 井字棋_Load(object sender, EventArgs e)
        {

        }
        GameInterface Start = new GameInterface();

        public ChooseLevel Choice = new ChooseLevel ();
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
        private void StartButton_Click(object sender, EventArgs e)
        {
            Start.Show();
            this.Hide();

        }


    }
}
