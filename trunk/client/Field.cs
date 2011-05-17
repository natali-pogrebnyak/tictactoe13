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
        Dictionary<int, Button> but = new Dictionary<int, Button>();
        const int lim = 10000;
        int cross = 1;
        int circle = 2;
        bool f;
        int width = 30;
        int height = 20;
            
        public Field()
        {
            InitializeComponent();
        }

        public bool win(object tag)
        {
            int countheight = this.Height / height;
            int countwidth = this.Width / width;
            
            int q = 0;
            for (int i = 0; i < countheight; i++)
                for (int j = 0; j < countwidth; j++)
                    if (""+but[i * lim + j].Tag == ""+tag)
                    {
                        q++;
                        if (q == 5)
                            return true;
                    }
                    else
                        q = 0;
            
            q = 0;
            for (int j = 0; j < countwidth; j++)
                for (int i = 0; i < countheight; i++)
                    if (""+but[i * lim + j].Tag == ""+tag)
                    {
                        q++;
                        if (q == 5)
                            return true;
                    }
                    else
                        q = 0;
            int w = 0;

           /* while (ii - jj != countheight - 1)
            {
                w=
                for (ii = 0; ii < countheight-jj; ii++)
                {
                    but[ii * lim + w].BackColor = System.Drawing.SystemColors.ActiveCaption;
                    if ("" + but[ii * lim + w].Tag == "" + tag)
                    {
                        q++;
                        if (q == 5)
                            return true;
                    }
                    else
                        q = 0;
                    w++;
                    
                }
            }
            */
           
            for (int i = 0; i < countheight; i++)
            {
                w=0;
                for (int j = countwidth-i; j < countwidth; j++)
                {
                    //MessageBox.Show("W");
                    but[w * lim + j].BackColor = System.Drawing.SystemColors.ActiveCaption;
                    if ("" + but[w * lim + i].Tag == "" + tag)
                    {
                        q++;
                        if (q == 5)
                            return true;
                    }
                    else
                        q = 0;
                    w++;
                }
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

            //but[y * lim + x] = ((Button)sender);

            f=win(((Button)sender).Tag);
            if (f)
                MessageBox.Show("Йа победил!!!");
        }
    }
}
