using CaroGame.Config;
using System;
using System.Windows.Forms;

namespace CaroGame
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            CONST.ReadCONST();
            CONST.LoadGame();
            Application.Run(new Form1());
        }
    }
}
