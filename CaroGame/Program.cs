using CaroGame.Configuration;
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
            Config.ReadCONST();
            Config.LoadGame();
            Application.Run(new MainForm());
        }
    }
}
