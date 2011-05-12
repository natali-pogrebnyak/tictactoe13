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
    public partial class Field : Form
    {
        List<Button> b = new List<Button>();
        
        public Field()
        {
            InitializeComponent();
        }

        private void Field_Activated(object sender, EventArgs e)
        {
            int width = 30;
            int height = 30;
            Button[,] buto = new Button[30,30];
            Button buton = new Button();
            
            for (int i = 0; i < (this.Height / height); i++)
                for (int j = 0; j < (this.Width / width); j++)
                {
                    buto[i, j] = new Button();
                    buto[i, j].Location = new System.Drawing.Point(j * width, i * height);
                    buto[i, j].Name = "but" + i + j;
                    buto[i, j].Size = new System.Drawing.Size(width, height);
                    buto[i, j].TabIndex = 0;
                    //buto[i, j].Text = "" + i + j;
                    buto[i, j].UseVisualStyleBackColor = true;
                    //b.Add(buto[i, j]);
                    this.Controls.Add(buto[i,j]);
                    buto[i,j].Click += new System.EventHandler(this.button_Click);
            
                }

        }

        private void button_Click(object sender, EventArgs e)
        {
            MessageBox.Show("текст"+sender.ToString());
        }
    }
}

