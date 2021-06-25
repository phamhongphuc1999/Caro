using CaroGame.CaroManagement;
using CaroGame.Configuration;
using CaroGame.PlayerManagement;
using CaroGame.Views;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CaroGame
{
    static class Program
    {
        public static PlayerManager playerManager;
        public static CaroManager caroManager;
        public static CaroBoardManager caroBoardManager;
        public static SoundManager soundManager;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Icon mainIcon = new Icon("../../Resources/Images/caro.ico");
            Icon settingIcon = new Icon("../../Resources/Images/setting.ico");
            Icon aboutIcon = new Icon("../../Resources/Images/about.ico");

            playerManager = new PlayerManager();
            caroManager = new CaroManager();
            caroBoardManager = new CaroBoardManager();
            soundManager = new SoundManager();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(Constants.OVERVIEW, mainIcon));
        }
    }
}
