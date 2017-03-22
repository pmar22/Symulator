using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Symulator
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

            GetRequest gr = new GetRequest("http://www.weszlo.com");
            gr.SetParameters("gl", "PL");
            gr.SetParameters("hl", "PL");
            Console.WriteLine(gr.GetFullUrl());
            //gr.Execute();
        }
    }
}
