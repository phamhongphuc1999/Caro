using CaroGame.Configuration;
using CaroGame.Views;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CaroGame
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Icon mainIcon = new Icon("../../Resources/Images/caro.ico");
            Icon settingIcon = new Icon("../../Resources/Images/setting.ico");
            Icon aboutIcon = new Icon("../../Resources/Images/about.ico");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(Constants.OVERVIEW, mainIcon));
        }
    }
}
