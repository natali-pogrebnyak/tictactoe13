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
        struct trace
        {
            public static int one;
            public static int two;
            public static int three;
            public static int four;
        }

        delegate int Deleg(int win, int i, int j, object tag, int their,int q1,int q2);
        static Deleg test;
        static int key;
        
        static Dictionary<int, Button> but = new Dictionary<int, Button>();
        static List<int> lin = new List<int>();
        
        public Field()
        {
            InitializeComponent();
        }

        public static int win_func(int wind, int i, int j, object tag, int their, int q1,int q2)
        {
            string temp;
            if ("" + but[i * param.lim + j].Tag == "" + tag)
            {
                wind++;
                if (wind == 5)
                {
                    for (int ii = 0; ii < param.countheight; ii++)
                        for (int jj = 0; jj < param.countwidth; jj++)
                            but[ii * param.lim + jj].Text = "";

                    if ((int)tag == their)
                    {
                        temp = "Вы победили!!!";
                        param.win++;
                    }
                    else
                    {
                        temp = "Победил противник!!!";
                        param.los++;
                    }
                    if ((MessageBox.Show(temp + " Хотите еще раз?", "Результат", MessageBoxButtons.YesNo).ToString() == "Yes"))
                    {
                        GameII.ActiveForm.Close();
                        GameII game = new GameII();
                        game.ShowDialog();
                    }
                    else
                        GameII.ActiveForm.Close();
                    return 1000;
                }
                return wind;
            }
            else
                return 0;
        }

        public static void four_numb(int i, int j, int q1, int q2, int back, int one, int two, int three, int four)
        {
            if (i + q1 > 0 && j + q2 > 0 && "" + but[(i + q1) * param.lim + (j + q2)].Tag == "")
            {
                if (but[(i + q1) * param.lim + (j + q2)].Text == "")
                    but[(i + q1) * param.lim + (j + q2)].Text = "0";
                but[(i + q1) * param.lim + (j + q2)].Text = (int.Parse(but[(i + q1) * param.lim + (j + q2)].Text) + three).ToString();
            }
            if (i + q1 + q1 > 0 && j + q2 + q2 > 0 && "" + but[(i + q1 + q1) * param.lim + (j + q2 + q2)].Tag == "")
            {
                if (but[(i + q1 + q1) * param.lim + (j + q2 + q2)].Text == "")
                    but[(i + q1 + q1) * param.lim + (j + q2 + q2)].Text = "0";
                but[(i + q1 + q1) * param.lim + (j + q2 + q2)].Text = (int.Parse(but[(i + q1 + q1) * param.lim + (j + q2 + q2)].Text) + four).ToString();
            }
            if (i - q1 * back > 0 && j - q2 * back > 0 && "" + but[(i - q1 * back) * param.lim + (j - q2 * back)].Tag == "")
            {
                if (but[(i - q1 * back) * param.lim + (j - q2 * back)].Text == "")
                    but[(i - q1 * back) * param.lim + (j - q2 * back)].Text = "0";
                but[(i - q1 * back) * param.lim + (j - q2 * back)].Text = (int.Parse(but[(i - q1 * back) * param.lim + (j - q2 * back)].Text) + two).ToString();
            }
            if (i - q1 * back - q1 > 0 && j - q2 * back - q2 > 0 && "" + but[(i - q1 * back - q1) * param.lim + (j - q2 * back - q2)].Tag == "")
            {
                if (but[(i - q1 * back - q1) * param.lim + (j - q2 * back - q2)].Text == "")
                    but[(i - q1 * back - q1) * param.lim + (j - q2 * back - q2)].Text = "0";
                but[(i - q1 * back - q1) * param.lim + (j - q2 * back - q2)].Text = (int.Parse(but[(i - q1 * back - q1) * param.lim + (j - q2 * back - q2)].Text) + one).ToString();
            }
            trace.one = one;
            trace.two = two;
            trace.three = three;
            trace.four = four;
        }
        
        public static int line(int wind, int i, int j, object tag, int enemy,int q1,int q2)
        {
            int shift = ++wind;
            if ("" + but[i * param.lim + j].Tag != "")
                lin.Add((int)but[i * param.lim + j].Tag);
            if ("" + but[i * param.lim + j].Tag == "" && lin.Count > 0)
                lin.Clear();

            if (lin.Count > 5)
            {
                int koef = 1;
                int temp = lin[0];
                for (int ii = 1; ii < lin.Count - 1; ii++)
                    if (temp == lin[ii])
                        koef++;

                if (koef < lin.Count)
                    wind = koef;
            }

            if ("" + but[i * param.lim + j].Tag != "" && wind == 5)
            {
                if (lin[0] != enemy && lin[1] == enemy && lin[2] == enemy && lin[3] == enemy && (int)but[i * param.lim + j].Tag == enemy)
                    four_numb(i, j, q1, q2, wind, 0, 1, 50, 0);
                if (lin[0] == enemy && lin[1] == enemy && lin[2] == enemy && lin[3] == enemy && (int)but[i * param.lim + j].Tag != enemy)
                    four_numb(i, j, q1, q2, wind, 0, 50, 1, 0);
                if (lin[0] == enemy && lin[1] == enemy && lin[2] == enemy && lin[3] != enemy && (int)but[i * param.lim + j].Tag != enemy)
                    four_numb(i, j, q1, q2, wind, 1, 3, 2, 1);
                if (lin[0] != enemy && lin[1] != enemy && lin[2] == enemy && lin[3] == enemy && (int)but[i * param.lim + j].Tag == enemy)
                    four_numb(i, j, q1, q2, wind, 1, 2, 3, 1);
                if (lin[0] == enemy && lin[1] == enemy && lin[2] != enemy && lin[3] != enemy && (int)but[i * param.lim + j].Tag != enemy)
                    four_numb(i, j, q1, q2, wind, 1, 2, 4, 2);
                if (lin[0] != enemy && lin[1] != enemy && lin[2] != enemy && lin[3] == enemy && (int)but[i * param.lim + j].Tag == enemy)
                    four_numb(i, j, q1, q2, wind, 2, 4, 2, 1);
                if (lin[0] != enemy && lin[1] != enemy && lin[2] != enemy && lin[3] != enemy && (int)but[i * param.lim + j].Tag == enemy)
                    four_numb(i, j, q1, q2, wind, 1, 100, 1, 1);
                if (lin[0] == enemy && lin[1] != enemy && lin[2] != enemy && lin[3] != enemy && (int)but[i * param.lim + j].Tag != enemy)
                    four_numb(i, j, q1, q2, wind, 1, 1, 100, 1);
            }

            if ("" + but[i * param.lim + j].Tag != "" && wind == 4)
            {
                if (lin[0] == enemy && lin[1] == enemy && lin[2] == enemy && (int)but[i * param.lim + j].Tag == enemy)
                    four_numb(i, j, q1, q2, wind, 1, 3, 3, 1);
                if (lin[0] == enemy && lin[1] == enemy && lin[2] == enemy && (int)but[i * param.lim + j].Tag != enemy)
                    four_numb(i, j, q1, q2, wind, 1, 3, 1, 0);
                if (lin[0] != enemy && lin[1] == enemy && lin[2] == enemy && (int)but[i * param.lim + j].Tag == enemy)
                    four_numb(i, j, q1, q2, wind, 0, 1, 3, 1);
                if (lin[0] == enemy && lin[1] == enemy && lin[2] != enemy && (int)but[i * param.lim + j].Tag != enemy)
                    four_numb(i, j, q1, q2, wind, 1, 2, 2, 1);
                if (lin[0] != enemy && lin[1] != enemy && lin[2] == enemy && (int)but[i * param.lim + j].Tag == enemy)
                    four_numb(i, j, q1, q2, wind, 1, 2, 2, 1);
                if (lin[0] != enemy && lin[1] != enemy && lin[2] != enemy && (int)but[i * param.lim + j].Tag == enemy)
                    four_numb(i, j, q1, q2, wind, 2, 4, 1, 0);
                if (lin[0] == enemy && lin[1] != enemy && lin[2] != enemy && (int)but[i * param.lim + j].Tag != enemy)
                    four_numb(i, j, q1, q2, wind, 0, 1, 4, 2);
                if (lin[0] != enemy && lin[1] != enemy && lin[2] != enemy && (int)but[i * param.lim + j].Tag != enemy)
                    four_numb(i, j, q1, q2, wind, 0, 100, 100, 0);
            }

            if ("" + but[i * param.lim + j].Tag != "" && wind == 3)
            {
                four_numb(i, j, q1, q2, wind, -trace.one, -trace.two, 0, 0);
                if (lin[0] == enemy)
                    if (lin[1] == enemy)
                        if ((int)but[i * param.lim + j].Tag == enemy)
                            four_numb(i, j, q1, q2, wind, 3, 10, 10, 3);
                        else
                            four_numb(i, j, q1, q2, wind, 1, 2, 1, 0);
                    else
                        if ((int)but[i * param.lim + j].Tag == enemy)
                            four_numb(i, j, q1, q2, wind, 1, 1, 1, 1);
                        else
                            four_numb(i, j, q1, q2, wind, 0, 1, 2, 1);
                else
                    if (lin[1] == enemy)
                        if ((int)but[i * param.lim + j].Tag == enemy)
                            four_numb(i, j, q1, q2, wind, 0, 1, 2, 1);
                        else
                            four_numb(i, j, q1, q2, wind, 1, 1, 1, 1);
                    else
                        if ((int)but[i * param.lim + j].Tag == enemy)
                            four_numb(i, j, q1, q2, wind, 1, 2, 1, 0);
                        else
                            four_numb(i, j, q1, q2, wind, 3, 20, 20, 3);
            }
            
            if ("" + but[i * param.lim + j].Tag != "" && wind == 2)
            {
                four_numb(i, j, q1, q2, wind, -trace.one, -trace.two, -trace.three, 0);
                if (lin[0] == enemy)
                    if ((int)but[i * param.lim + j].Tag == enemy)
                        four_numb(i, j, q1, q2, wind, 0, 3, 3, 0);
                    else
                        four_numb(i, j, q1, q2, wind, 0, 1, 1, 1);
                else
                    if ((int)but[i * param.lim + j].Tag == enemy)
                        four_numb(i, j, q1, q2, wind, 1, 1, 1, 0);
                    else
                        four_numb(i, j, q1, q2, wind, 2, 3, 3, 2);
            }
            
            if ("" + but[i * param.lim + j].Tag != "" && wind == 1)
                four_numb(i, j, q1, q2, wind, 1, 1, 1, 1);
            
            if ("" + but[i * param.lim + j].Tag != "")
                return shift;
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

            for (int i = 0; i < param.countheight; i++)
                for (int j = 0; j < param.countwidth; j++)
                {
                    if (but[i*param.lim+j].Text != "")
                        if (int.Parse(but[i * param.lim + j].Text) > temp)
                        {
                            list.Clear();
                            keys.Clear();
                            temp = int.Parse(but[i * param.lim + j].Text);
                            list.Add(but[i * param.lim + j]);
                            keys.Add(i * param.lim + j);
                        }
                        else
                            if (int.Parse(but[i * param.lim + j].Text) == temp)
                            {
                                temp = int.Parse(but[i * param.lim + j].Text);
                                list.Add(but[i * param.lim + j]);
                                keys.Add(i * param.lim + j);
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
            for (int i = 0; i < param.countheight; i++)
            {
                win = 0;
                lin.Clear();
                for (int j = 0; j < param.countwidth; j++)
                    win = test(win, i, j, tag, their,0,1);
            }
            
            //проверка по вертикали
            for (int j = 0; j < param.countwidth; j++)
            {
                win = 0;
                lin.Clear();
                for (int i = 0; i < param.countheight; i++)
                    win = test(win, i, j, tag, their,1,0);
            }
            
            //проверка по главной диагонали
            int ii = 0;
            int jj = param.countwidth-1;
            int count = 1;
            int n = 0;
            int curj = jj;
            int curi = ii;

            while (param.countwidth * param.countheight > n)
            {
                curj = jj;
                win = 0;
                lin.Clear();
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
                if (param.countwidth>=param.countheight && curj==0)
                    count--;
                else
                    if (param.countwidth < param.countheight && ii > param.countheight - param.countwidth && curj == 0)
                        count--;
                    else
                        if (count < Math.Min(param.countheight, param.countwidth))
                            count++;
            }

            //проверка по побочной диагонали
            ii = 0;
            jj = 0;
            count = 1;
            n = 0;
            curj = jj;
            curi = ii;

            while (param.countwidth * param.countheight > n)
            {
                curj = jj;
                win = 0;
                lin.Clear();
                for (int e = 0; e < count; e++)
                {
                    win = test(win, ii, jj, tag,their,1,-1);
                    ii++;
                    jj--;
                    n++;
                }
                jj = curj + 1;
                if (curj == param.countwidth-1)
                {
                    jj = param.countwidth-1;
                    curi++;
                }
                ii = curi;
                if (param.countwidth >= param.countheight && curj == param.countwidth-1)
                    count--;
                else
                    if (param.countwidth < param.countheight && ii > param.countheight - param.countwidth && curj == param.countwidth-1)
                        count--;
                    else
                        if (count < Math.Min(param.countheight, param.countwidth))
                            count++;
            }

            return false;
        }
        
        public void Field_Activated(object sender, EventArgs e)
        {
            int width = this.Width / param.countwidth;
            int height = this.Height / param.countwidth;
            
            for (int i = 0; i < param.countheight; i++)
                for (int j = 0; j < param.countwidth; j++)
                {
                    but[i * param.lim + j] = new Button();
                    but[i * param.lim + j].Location = new System.Drawing.Point(j * width, i * height);
                    but[i * param.lim + j].Name = "but" + (i * param.lim) + j;
                    but[i * param.lim + j].Size = new System.Drawing.Size(width, height);
                    but[i * param.lim + j].TabIndex = 0;
                    but[i * param.lim + j].UseVisualStyleBackColor = true;
                    but[i * param.lim + j].FlatStyle = System.Windows.Forms.FlatStyle.Popup; 
                    this.Controls.Add(but[i * param.lim + j]);
                    but[i * param.lim + j].Click += new System.EventHandler(this.button_Click);
                }
        }

        private void button_Click(object sender, EventArgs e)
        {
            if (((Button)sender).FlatStyle == System.Windows.Forms.FlatStyle.Popup)
            {
                ((Button)sender).FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                /*
                int param.countheight = this.Height / height;
                int param.countwidth = this.Width / width;
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
                
                for (int i = 0; i < param.countheight; i++)
                    for (int j = 0; j < param.countwidth; j++)
                        but[i * param.lim + j].Text = "";
            }
        }

        public void ii()
        {
            but[key] = max();
            but[key].Text = "";
            but[key].FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            but[key].Tag = -figure.id;

            if ((int)but[key].Tag == figure.circle)
                but[key].Image = Client.Properties.Resources.circle;
            else but[key].Image = Client.Properties.Resources.cross;
            but[key].Focus();

            Field.test = new Deleg(Field.win_func);
            control(but[key].Tag, figure.id);
            
        }
    }
}
