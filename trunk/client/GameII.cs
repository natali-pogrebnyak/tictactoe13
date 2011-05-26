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
    public partial class GameII : Form
    {
        public GameII()
        {
            InitializeComponent();
        }

        private void GameII_FormClosed(object sender, FormClosedEventArgs e)
        {
            TicTacToe.ActiveForm.Close();
        }

        private void button_circle_Click(object sender, EventArgs e)
        {
            figure.id = figure.circle;
            label_circle.Text = "Вы";
            label_cross.Text = "Противник";
        }

        private void button_cross_Click(object sender, EventArgs e)
        {
            figure.id = figure.cross;
            label_circle.Text = "Противник";
            label_cross.Text = "Вы";
        }

        private void Start_Click(object sender, EventArgs e)
        {
            Field field = new Field();
            field.MdiParent = this;
            field.Show();
            Menu.Enabled = false;

       }
    }
}
