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
using CaroGame.Views;
using CaroGame.Views.Components.SettingComponents;
using System;

namespace CaroGame.Routers
{
    public class SettingRoutes : BaseRoutes
    {
        public MainSettingPanel MainSettingView
        {
            get; set;
        }
        public PlayerSettingPanel PlayerSettingView
        {
            get; set;
        }
        public SizeSettingPanel SizeSettingView
        {
            get; set;
        }
        public LanguageSettingPanel LanguageSettingView
        {
            get; set;
        }
        public SoundSettingPanel SoundSettingView
        {
            get; set;
        }
        public TimeSettingPanel TimeSettingView
        {
            get; set;
        }
        public GameModeSettingPanel GameModeSettingView
        {
            get; set;
        }
        public AppearanceSettingPanel AppearanceSettingView
        {
            get; set;
        }

        private static SettingRoutes settingRoutes;

        private SettingRoutes(SettingForm viewForm) : base()
        {
            MainSettingView = new MainSettingPanel(false, true) { Visible = false };
            PlayerSettingView = new PlayerSettingPanel(false, true) { Visible = false };
            SizeSettingView = new SizeSettingPanel(false, true) { Visible = false };
            LanguageSettingView = new LanguageSettingPanel(false, true) { Visible = false };
            SoundSettingView = new SoundSettingPanel(false, true) { Visible = false };
            TimeSettingView = new TimeSettingPanel(false, true) { Visible = false };
            GameModeSettingView = new GameModeSettingPanel(false, false) { Visible = false };
            AppearanceSettingView = new AppearanceSettingPanel(false, true) { Visible = false };
            viewForm.Controls.Add(MainSettingView);
            viewForm.Controls.Add(PlayerSettingView);
            viewForm.Controls.Add(SizeSettingView);
            viewForm.Controls.Add(LanguageSettingView);
            viewForm.Controls.Add(SoundSettingView);
            viewForm.Controls.Add(TimeSettingView);
            viewForm.Controls.Add(GameModeSettingView);
            viewForm.Controls.Add(AppearanceSettingView);
        }

        public void Routing(string router)
        {
            if (router.Equals(Constants.MAIN_SETTING)) SetCurrentControl(MainSettingView);
            else if (router.Equals(Constants.PLAYER_SETTING)) SetCurrentControl(PlayerSettingView);
            else if (router.Equals(Constants.SIZE_SETTING)) SetCurrentControl(SizeSettingView);
            else if (router.Equals(Constants.LANGUAGE_SETTING)) SetCurrentControl(LanguageSettingView);
            else if (router.Equals(Constants.SOUND_SETTING)) SetCurrentControl(SoundSettingView);
            else if (router.Equals(Constants.TIME_SETTING)) SetCurrentControl(TimeSettingView);
            else if (router.Equals(Constants.GAME_MODE)) SetCurrentControl(GameModeSettingView);
            else if (router.Equals(Constants.APPEARANCE_SETTING)) SetCurrentControl(AppearanceSettingView);
            else throw new Exception();
        }

        public static SettingRoutes GetInstance(SettingForm viewForm)
        {
            if (settingRoutes == null) settingRoutes = new SettingRoutes(viewForm);
            return settingRoutes;
        }
    }
}
