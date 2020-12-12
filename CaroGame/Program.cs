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

namespace CaroGame
{
    static class Program
    {
        public static CaroManager caroManager;
        public static LANManager lanManager;
        public static SoundManager soundManager;

        public static MainForm mainForm;
        public static SettingForm settingForm;

        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Config.InitializeConfiguration();

            //init screen
            mainForm = new MainForm();
            settingForm = new SettingForm();

            //init  manager
            caroManager = new CaroManager(mainForm.txtPlayer, mainForm.pnlCaroBoard, mainForm.lblTime);
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

            Application.Run(settingForm);
        }
    }
}
