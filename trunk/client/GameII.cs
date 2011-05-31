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

        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            ListBox lb=sender as ListBox;
            e.DrawBackground();
            e.DrawFocusRectangle();
            if (e.Index < 0) return;
            StringFormat frm = new StringFormat();
            frm.Alignment = StringAlignment.Center;
            frm.LineAlignment = StringAlignment.Center;
            Brush brush=new SolidBrush(e.ForeColor);
            string text=lb.GetItemText(lb.Items[e.Index]);
            Rectangle rc=lb.GetItemRectangle(e.Index);
            e.Graphics.DrawString(text, e.Font, brush, rc, frm);
            frm.Dispose();
            brush.Dispose();
        }

        private void GameII_Load(object sender, EventArgs e)
        {
            listBox1.Items.Add(param.win + " : " + param.los);
        }
    }
}
