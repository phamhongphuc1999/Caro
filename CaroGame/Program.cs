// Copyright (c) Microsoft. All Rights Reserved.
//  License under the Apache License, Version 2.0.
//  Owner: Pham Hong Phuc

using CaroGame.Configuration;
using CaroGame.SaveGameManagement;
using System;
using System.Windows.Forms;
using CaroGame.Presentaion;
using CaroGame.Presentation;

namespace CaroGame
{
    static class Program
    {
        public static MainForm mainForm;
        public static SettingForm settingForm;

        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Config.InitializeConfiguration();

            //load save game
            SaveGameHelper.LoadGame();

            //init screen
            mainForm = new MainForm();
            settingForm = new SettingForm();

            Application.Run(settingForm);
        }
    }
}
