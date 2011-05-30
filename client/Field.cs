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
        delegate int Deleg(int win, int i, int j, object tag, int their,int q1,int q2);
        static Deleg test;
        static int key;
        
        static int countheight = 20;
        static int countwidth = 20;

        static Dictionary<int, Button> but = new Dictionary<int, Button>();
        static List<int> lin = new List<int>();
        const int lim = 10000;
        
        public Field()
        {
            InitializeComponent();
        }

        public static int win_func(int wind, int i, int j, object tag, int their, int q1,int q2)
        {
            if ("" + but[i * lim + j].Tag == "" + tag)
            {
                wind++;
                if (wind == 5)
                {
                    if ((int)tag==their)
                        MessageBox.Show("Вы победили!!!");
                    else
                        MessageBox.Show("Победил противник!!!");
                    return 1000;
                }
                return wind;
            }
            else
                return 0;
        }

        public static void four_numb(int i, int j, int q1, int q2, int one, int two, int three, int four)
        {
            if (""+but[(i + q1) * lim + (j + q2)].Tag == "")
            {
                if (but[(i + q1) * lim + (j + q2)].Text == "")
                    but[(i + q1) * lim + (j + q2)].Text = "0";
                but[(i + q1) * lim + (j + q2)].Text = (int.Parse(but[(i + q1) * lim + (j + q2)].Text) + three).ToString();
            }
            if (""+but[(i + q1 + q1) * lim + (j + q2 + q2)].Tag == "")
            {
                if (but[(i + q1 + q1) * lim + (j + q2 + q2)].Text == "")
                    but[(i + q1 + q1) * lim + (j + q2 + q2)].Text = "0";
                but[(i + q1 + q1) * lim + (j + q2 + q2)].Text = (int.Parse(but[(i + q1 + q1) * lim + (j + q2 + q2)].Text) + four).ToString();
            }
            if (""+but[(i - q1) * lim + (j - q2)].Tag == "")
            {
                if (but[(i - q1) * lim + (j - q2)].Text == "")
                    but[(i - q1) * lim + (j - q2)].Text = "0";
                but[(i - q1) * lim + (j - q2)].Text = (int.Parse(but[(i - q1) * lim + (j - q2)].Text) + two).ToString();
            }
            if (""+but[(i - q1 - q1) * lim + (j - q2 - q2)].Tag == "")
            {
                if (but[(i - q1 - q1) * lim + (j - q2 - q2)].Text == "")
                    but[(i - q1 - q1) * lim + (j - q2 - q2)].Text = "0";
                but[(i - q1 - q1) * lim + (j - q2 - q2)].Text = (int.Parse(but[(i - q1 - q1) * lim + (j - q2 - q2)].Text) + one).ToString();
            }
        }

        public static int line(int wind, int i, int j, object tag, int enemy,int q1,int q2)
        {
            if ("" + but[i * lim + j].Tag == "" + tag)
            {
                four_numb(i, j, q1, q2, 1, 1, 1, 1);
                lin.Add((int)tag);
                return ++wind;
            }

            /*if ("" + but[i * lim + j].Tag == "" + enemy && wind == 2)
            {
                four_numb(i, j, q1, q2, 1, 1);
                return wind;
            }
            */
            else
                return 0;
        }

        public Button max()
        {
            Random rnd = new Random();

            List<Button> list = new List<Button>();
            List<int> keys = new List<int>();
            int temp=0;
            int fig = 0;

            for (int i = 0; i < countheight; i++)
                for (int j = 0; j < countwidth; j++)
                {
                    if (but[i*lim+j].Text != "")
                        if (int.Parse(but[i * lim + j].Text) > temp)
                        {
                            list.Clear();
                            keys.Clear();
                            temp = int.Parse(but[i * lim + j].Text);
                            list.Add(but[i * lim + j]);
                            keys.Add(i * lim + j);
                        }
                        else
                            if (int.Parse(but[i * lim + j].Text) == temp)
                            {
                                temp = int.Parse(but[i * lim + j].Text);
                                list.Add(but[i * lim + j]);
                                keys.Add(i * lim + j);
                            }
                }
            fig=rnd.Next(list.Count - 1);
            key = keys[fig];
            return list[fig];
        }

        public bool control(object tag, int their)
        {
            //проверка по горизонтали
            int win = 0;
            for (int i = 0; i < countheight; i++)
            {
                win = 0;
                for (int j = 0; j < countwidth; j++)
                    win = test(win, i, j, tag, their,0,1);
            }
            
            //проверка по вертикали
            for (int j = 0; j < countwidth; j++)
            {
                win = 0;
                for (int i = 0; i < countheight; i++)
                    win = test(win, i, j, tag, their,1,0);
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
                    win = test(win, ii, jj, tag,their,1,1);
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
                    win = test(win, ii, jj, tag,their,1,-1);
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
            int width = this.Width / countwidth;
            int height = this.Height / countwidth;
            
            for (int i = 0; i < countheight; i++)
                for (int j = 0; j < countwidth; j++)
                {
                    but[i * lim + j] = new Button();
                    but[i * lim + j].Location = new System.Drawing.Point(j * width, i * height);
                    but[i * lim + j].Name = "but" + (i * lim) + j;
                    but[i * lim + j].Size = new System.Drawing.Size(width, height);
                    but[i * lim + j].TabIndex = 0;
                    but[i * lim + j].UseVisualStyleBackColor = true;
                    but[i * lim + j].FlatStyle = System.Windows.Forms.FlatStyle.Popup; 
                    this.Controls.Add(but[i * lim + j]);
                    but[i * lim + j].Click += new System.EventHandler(this.button_Click);
                }
        }

        private void button_Click(object sender, EventArgs e)
        {
            if (((Button)sender).FlatStyle == System.Windows.Forms.FlatStyle.Popup)
            {
                ((Button)sender).FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                /*
                int countheight = this.Height / height;
                int countwidth = this.Width / width;
                int x = ((Button)sender).Left / width;
                int y = ((Button)sender).Top / height;
                */
                ((Button)sender).Tag = figure.id;

                if ((int)((Button)sender).Tag == figure.circle)
                    ((Button)sender).Image = Client.Properties.Resources.circle;
                else ((Button)sender).Image = Client.Properties.Resources.cross;

                Field.test = new Deleg(Field.win_func);
                control(((Button)sender).Tag, figure.id);

                Field.test = new Deleg(Field.line);
                control(((Button)sender).Tag, figure.id);
                ii();
                MessageBox.Show(key.ToString());
                for (int i = 0; i < countheight; i++)
                    for (int j = 0; j < countwidth; j++)
                        but[i * lim + j].Text = "";
            }
        }

        public void ii()
        {
            
            but[key] = max();
            but[key].Text = "";
            /*for (int i = 0; i < countheight; i++)
                for (int j = 0; j < countwidth; j++)
                    but[i * lim + j].Text = "";
            */
            but[key].FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            but[key].Tag = -figure.id;
            
                       
            if ((int)but[key].Tag == figure.circle)
                but[key].Image = Client.Properties.Resources.circle;
            else but[key].Image = Client.Properties.Resources.cross;
            
            Field.test = new Deleg(Field.win_func);
            control(but[key].Tag, figure.id);

            
    
        }
    }
}
