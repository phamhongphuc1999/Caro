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

using CaroGame.Configuration;
using CaroGame.Presentation;
using CaroGame.SoundManagement;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CaroGame
{
    static class Program
    {
        public static MainForm mainForm;
        public static SettingForm settingForm;
        public static AboutForm aboutForm;

        public static SoundManager soundManager;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Icon mainIcon = new Icon($"../../..//Resources/Image/caro.ico");
            Icon settingIcon = new Icon("../../../Resources/Image/setting.ico");
            Icon aboutIcon = new Icon("../../../Resources/Image/about.ico");

            mainForm = new MainForm(Config.NAME.OVERVIEW, mainIcon);
            settingForm = new SettingForm(Config.NAME.SETTING, settingIcon);
            aboutForm = new AboutForm(Config.NAME.ABOUT, aboutIcon);

            soundManager = new SoundManager();
            soundManager.StartConfig();

            Application.Run(settingForm);
        }
    }
}
