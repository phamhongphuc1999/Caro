// --------------------CARO  GAME-----------------
//
//
// Copyright (c) Microsoft. All Rights Reserved.
// License under the Apache License, Version 2.0.
//
//
// Product by: Pham Hong Phuc
//
//
// ------------------------------------------------------

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
        public static MainForm mainForm;
        public static SettingForm settingForm;
        public static AboutForm aboutForm;

        public static PlayerManager playerManager;
        public static CaroBoardManager caroBoardManager;
        public static WinnerManager winnerManager;
        public static ActionManager actionManager;
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
            caroBoardManager = new CaroBoardManager();
            winnerManager = new WinnerManager();
            actionManager = new ActionManager();
            soundManager = new SoundManager();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            mainForm = new MainForm(Constants.OVERVIEW, mainIcon);
            settingForm = new SettingForm(Constants.MAIN_SETTING, settingIcon);
            aboutForm = new AboutForm(Constants.ABOUT, aboutIcon);

            Application.Run(settingForm);
        }
    }
}
