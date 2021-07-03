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
using CaroGame.Routers;
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

        public static Routes routes;
        public static SettingRoutes settingRoutes;

        public static PlayerManager playerManager;
        public static CaroBoardManager caroBoardManager;
        public static WinnerManager winnerManager;
        public static ActionManager actionManager;
        public static SoundManager soundManager;
        public static StorageManager storageManager;
        public static TimerManager timerManager;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Icon mainIcon = new Icon("../../Resources/Images/caro.ico");
            Icon settingIcon = new Icon("../../Resources/Images/setting.ico");
            Icon aboutIcon = new Icon("../../Resources/Images/about.ico");

            timerManager = new TimerManager();
            caroBoardManager = new CaroBoardManager();
            playerManager = new PlayerManager();
            winnerManager = new WinnerManager();
            actionManager = new ActionManager();
            soundManager = new SoundManager();
            storageManager = new StorageManager();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Initliaze form
            mainForm = new MainForm(Constants.OVERVIEW, mainIcon);
            settingForm = new SettingForm(Constants.MAIN_SETTING, settingIcon);
            aboutForm = new AboutForm(Constants.ABOUT, aboutIcon);

            // Initliaze routers
            routes = Routes.GetInstance(mainForm);
            routes.RoutingEvent += (sender, e) =>
            {
                Control control = sender as Control;
                if (control != null)
                {
                    mainForm.Text = e.title;
                }
            };
            routes.MainViewEvent += (sender, e) =>
            {
                caroBoardManager.CreateNewGame(playerManager.Turn);
            };
            routes.Routing(Constants.OVERVIEW);
            caroBoardManager.InitMainView(routes.MainView);
            playerManager.InitMainView(routes.MainView);

            // Initiliaze setting routes
            settingRoutes = SettingRoutes.GetInstance(settingForm);
            settingRoutes.RoutingEvent += (sender, e) =>
            {
                Control control = sender as Control;
                if (control != null)
                {
                    settingForm.Text = e.title;
                }
            };
            settingRoutes.Routing(Constants.MAIN_SETTING);

            Application.Run(mainForm);
        }
    }
}
