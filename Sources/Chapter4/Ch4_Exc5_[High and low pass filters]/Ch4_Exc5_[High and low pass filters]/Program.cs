using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Ch4_Exc5__High_and_low_pass_filters_
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
