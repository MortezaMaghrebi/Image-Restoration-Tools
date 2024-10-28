using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Ch4_Exc4__Change_abs_or_angle_
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
