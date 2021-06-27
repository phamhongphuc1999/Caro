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

        public SettingRoutes(SettingForm viewForm) : base()
        {
            MainSettingView = new MainSettingPanel { Visible = false };
            PlayerSettingView = new PlayerSettingPanel { Visible = false };
            SizeSettingView = new SizeSettingPanel { Visible = false };
            LanguageSettingView = new LanguageSettingPanel { Visible = false };
            SoundSettingView = new SoundSettingPanel { Visible = false };
            TimeSettingView = new TimeSettingPanel { Visible = false };
            GameModeSettingView = new GameModeSettingPanel { Visible = false };
            viewForm.Controls.Add(MainSettingView);
            viewForm.Controls.Add(PlayerSettingView);
            viewForm.Controls.Add(SizeSettingView);
            viewForm.Controls.Add(LanguageSettingView);
            viewForm.Controls.Add(SoundSettingView);
            viewForm.Controls.Add(TimeSettingView);
            viewForm.Controls.Add(GameModeSettingView);
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
            else throw new Exception();
        }
    }
}
