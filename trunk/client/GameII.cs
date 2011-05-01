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

        private void GameII_Load(object sender, EventArgs e)
        {
            Field field = new Field();
            field.MdiParent=this;
            field.Show();
        }
    }
}
