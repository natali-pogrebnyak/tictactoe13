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
        delegate int Deleg(int win, int i, int j, object tag);
        static Deleg test;

        static Dictionary<int, Button> but = new Dictionary<int, Button>();
        const int lim = 10000;
        int cross = 1;
        int circle = 2;
        int width = 30;
        int height = 30;
            
        public Field()
        {
            InitializeComponent();
        }

        public static int winu(int wind, int i, int j, object tag)
        {
            if ("" + but[i * lim + j].Tag == "" + tag)
            {
                wind++;
                if (wind == 5)
                {
                    MessageBox.Show("Йа победил!!!");
                    return 1000;
                }
                return wind;
            }
            else
                return 0;
        }

        public bool control(object tag)
        {
            //проверка по горизонтали
            int countheight = this.Height / height;
            int countwidth = this.Width / width;
            
            int win = 0;
            for (int i = 0; i < countheight; i++)
            {
                win = 0;
                for (int j = 0; j < countwidth; j++)
                    win = test(win, i, j, tag);
            }
            
            //проверка по вертикали
            for (int j = 0; j < countwidth; j++)
            {
                win = 0;
                for (int i = 0; i < countheight; i++)
                    win = test(win, i, j, tag);
            }
            
            //проверка по главной диагонали
            int ii = 0;
            int jj = countwidth-1;
            int count = 1;
            int n = 0;
            int curj = jj;
            int curi = ii;

            while (countwidth * countheight > n)
            {
                curj = jj;
                win = 0;
                for (int e = 0; e < count; e++)
                {
                    win = test(win, ii, jj, tag);
                    ii++;
                    jj++;
                    n++;
                }
                jj = curj - 1;
                if (curj == 0)
                {
                    jj = 0;
                    curi++;
                }
                ii = curi;
                if (countwidth>=countheight && curj==0)
                    count--;
                else
                    if (countwidth < countheight && ii > countheight - countwidth && curj == 0)
                        count--;
                    else
                        if (count < Math.Min(countheight, countwidth))
                            count++;
            }

            //проверка по побочной диагонали
            ii = 0;
            jj = 0;
            count = 1;
            n = 0;
            curj = jj;
            curi = ii;

            while (countwidth * countheight > n)
            {
                curj = jj;
                win = 0;
                for (int e = 0; e < count; e++)
                {
                    win = test(win, ii, jj, tag);
                    ii++;
                    jj--;
                    n++;
                }
                jj = curj + 1;
                if (curj == countwidth-1)
                {
                    jj = countwidth-1;
                    curi++;
                }
                ii = curi;
                if (countwidth >= countheight && curj == countwidth-1)
                    count--;
                else
                    if (countwidth < countheight && ii > countheight - countwidth && curj == countwidth-1)
                        count--;
                    else
                        if (count < Math.Min(countheight, countwidth))
                            count++;
            }

            return false;
        }
        
        public void Field_Activated(object sender, EventArgs e)
        {
            int countheight = this.Height / height;
            int countwidth = this.Width / width;

            for (int i = 0; i < countheight; i++)
                for (int j = 0; j < countwidth; j++)
                {
                    but[i * lim + j] = new Button();
                    but[i * lim + j].Location = new System.Drawing.Point(j * width, i * height);
                    but[i * lim + j].Name = "but" + i * lim + j;
                    but[i * lim + j].Size = new System.Drawing.Size(width, height);
                    but[i * lim + j].TabIndex = 0;
                    but[i * lim + j].UseVisualStyleBackColor = true;
                    but[i * lim + j].FlatStyle = System.Windows.Forms.FlatStyle.Flat; 
                    this.Controls.Add(but[i * lim + j]);
                    but[i * lim + j].Click += new System.EventHandler(this.button_Click);
                }
        }

        private void button_Click(object sender, EventArgs e)
        {
            int countheight = this.Height / height;
            int countwidth = this.Width / width;
            int x = ((Button)sender).Left / width;
            int y = ((Button)sender).Top / height;
            
            ((Button)sender).Tag = circle;

            if ((int)((Button)sender).Tag == circle)
                ((Button)sender).Image = Client.Properties.Resources.circle;
            else ((Button)sender).Image = Client.Properties.Resources.cross;

            Field.test = new Deleg(Field.winu);
            control(((Button)sender).Tag);
        }
    }
}
