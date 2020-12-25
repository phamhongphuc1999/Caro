// Copyright (c) Microsoft. All Rights Reserved.
//  License under the Apache License, Version 2.0.
//  Owner: Pham Hong Phuc

using CaroGame.Configuration;
using CaroGame.SaveGameManagement;
using System;
using System.Windows.Forms;
using CaroGame.Presentaion;
using CaroGame.Presentation;
using CaroGame.CaroManagement;
using CaroGame.LANManagement;
using CaroGame.SoundManagement;
using System.Drawing;

namespace CaroGame
{
    static class Program
    {
        public static CaroManager caroManager;
        public static LANManager lanManager;
        public static SoundManager soundManager;

        public static MainForm mainForm;
        public static SettingForm settingForm;
        public static AboutForm aboutForm;

        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Config.InitializeConfiguration();

            //init manager
            caroManager = new CaroManager();
            lanManager = new LANManager();
            soundManager = new SoundManager();
            if (Config.IS_PLAY_MUSIC)
            {
                soundManager.IsLoop = true;
                soundManager.Volume = Config.VOLUME_SIZE;
                soundManager.Play("su-thanh-hoa.wav");
            }
            CaroManager.lanManager = lanManager;

            //load save game
            SaveGameHelper.LoadGame();

            //init screen
            Icon mainIcon = new Icon("../../../Resources/Image/caro.ico");
            Icon settingIcon = new Icon("../../../Resources/Image/setting.ico");
            Icon aboutIcon = new Icon("../../../Resources/Image/about.ico");
            mainForm = new MainForm(Config.NAME.GAME_MODE, mainIcon);
            settingForm = new SettingForm(Config.NAME.SETTING, settingIcon);
            aboutForm = new AboutForm(Config.NAME.ABOUT, aboutIcon);

            caroManager.txtPlayer = mainForm.txtPlayer;
            caroManager.pnlCaroBoard = mainForm.pnlCaroBoard;
            caroManager.lblTime = mainForm.lblTime;
            Application.Run(mainForm);
        }
    }
}
