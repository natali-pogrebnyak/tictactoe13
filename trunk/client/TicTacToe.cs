using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Client
{
    public partial class TicTacToe : Form
    {
        public TicTacToe()
        {
            InitializeComponent();
        }

        private void game_ii_Click(object sender, EventArgs e)
        {
            GameII game = new GameII();
            game.ShowDialog();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            TicTacToe.ActiveForm.Close();
        }

        private void authors_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Version 1.0.0\r\n\r\nАвторы:\r\nНовоселов Алексей Николаевич\r\nИльин Антон Александрович", "About");
        }
    }
}
