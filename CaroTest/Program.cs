using CaroTest.Setting;
using System;
using System.Windows.Forms;

namespace CaroTest
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            CONST.ReadCONST();
            Application.Run(new Form1());
        }
    }
}
