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
            TicTacToe.ActiveForm.Hide();
            GameII game = new GameII();
            game.Show();
        }
    }
}
