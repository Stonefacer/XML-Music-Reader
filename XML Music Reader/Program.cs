using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace XML_Music_Reader {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //critical block
            //string str = "If you can see that then you go too far...";
            //str += "";
            //if (DateTime.Now.Ticks > 635728227368973656L)
            //    MessageBox.Show("Sorry, application cannot be started. Code: " + DateTime.Now.Ticks.ToString("X016"));
            //else
            Application.Run(new Form1());
        }
    }
}
