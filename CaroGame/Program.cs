using CaroGame.Configuration;
using CaroGame.SaveGameManagement;
using System;
using System.Windows.Forms;
using CaroGame.Presentaion;

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
            Config.InitializeConfiguration();
            SaveGameHelper.LoadGame();
            MainForm mainForm = new MainForm();
            Application.Run(mainForm);
        }
    }
}
