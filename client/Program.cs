using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Client
{
    struct figure
    {
        public static int id {get; set;}
        public const int circle = 1;
        public const int cross = -1;
        public const int empty = 0;
    }

    struct param
    {
        public static int countheight = 20;
        public static int countwidth = 20;
        public static int lim = 10000;
        public static bool easy = true;
        public static int win;
        public static int los;
    }

    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            figure.id = figure.circle;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TicTacToe());
        }
    }
}
